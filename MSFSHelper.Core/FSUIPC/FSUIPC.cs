using FSUIPCWebSockets.Client;
using FSUIPCWebSockets.JSONDataStructures;
using System.Collections.Concurrent;

namespace MSFSHelper.Core.FSUIPC
{
    public class FSUIPC : IDisposable
    {
        private FSUIPCWebSocket ws;

        private BlockingCollection<(JSONRequest, string)> requestQueue =
            new BlockingCollection<(JSONRequest, string)>();

        private CancellationTokenSource cts = new CancellationTokenSource();
        private Task? socketTask = null;

        private Dictionary<string, ResponseHandler> responseHandlers = new();


        public string Address { get; init; } 
        public int TimeoutMillis { get; set; }


        public FSUIPC()
        {
            Address = "ws://192.168.0.13:2048/fsuipc/";
            TimeoutMillis = 10000;
        }

        public void Initialize()
        {
            ws = new FSUIPCWebSocket();
            ws.StateChanged += Ws_StateChanged;
            ws.Error += Ws_Error;
            ws.ResponseReceived += Ws_ResponseReceived;

            ws.Open(Address);
        }

        private void HandleMessages(CancellationToken token)
        {
            foreach ((JSONRequest request, string identifier) in requestQueue.GetConsumingEnumerable(token))
            {
                token.ThrowIfCancellationRequested();
                ws.Send(request);
                Log($"[Request] Sent {identifier} : {request.command}");
            }
        }

        public async Task<JSONResponse> DeclareOffsetGroup(string varGroupName, params OffsetVar[] declarations)
        {
            OffsetDefinition[] offsets = declarations.Select(it => 
            new OffsetDefinition
            { 
                name = it.Name,
                address = it.Address,
                type = it.Type,
                size = it.Size
            }).ToArray();

            JSONRequest request = new JSONOffsetsRequest
            {
                command = "offsets.declare",
                name = varGroupName,
                offsets = offsets
            };

            return ConvertResponse.offsets.declare(await SendAndAwait(request).ConfigureAwait(false));
        }

        public async Task<JSONOffsetsResponse> ReadOffsetGroup(string varGroupName)
        {
            JSONRequest request = new JSONOffsetsRequest
            {
                command = "offsets.read",
                name = varGroupName
            };

            return ConvertResponse.offsets.read(await SendAndAwait(request).ConfigureAwait(false));
        }

        public async Task<JSONOffsetsResponse> StartOffsetGroupPolling(
            string varGroupName,
            Action<JSONResponse> onUpdate,
            int intervalMillis = 1000)
        {
            JSONRequest request = new JSONOffsetsRequest
            {
                command = "offsets.read",
                name = varGroupName,
                interval = intervalMillis
            };

            var response = ConvertResponse.offsets.read(await SendAndAwait(request).ConfigureAwait(false));
            lock (responseHandlers)
            {
                responseHandlers.Add(varGroupName, new ResponseHandler(onUpdate, false));
            }

            return response;
        }

        // TODO stop offset polling

        public async Task<JSONResponse> DeclareVariableGroup(string varGroupName, params string[] declarations)
        {
            VarDefinition[] varsNames = declarations.Select(it => new VarDefinition { name = it }).ToArray();

            JSONRequest request = new JSONVarsRequest
            {
                command = "vars.declare",
                name = varGroupName,
                vars = varsNames
            };

            return ConvertResponse.vars.declare(await SendAndAwait(request).ConfigureAwait(false));
        }

        public async Task<JSONVarsResponse> ReadVariableGroup(string varGroupName)
        {
            JSONRequest request = new JSONVarsRequest
            {
                command = "vars.read",
                name = varGroupName
            };

            return ConvertResponse.vars.read(await SendAndAwait(request).ConfigureAwait(false));
        }

        public async Task<JSONVarsResponse> StartVariableGroupPolling(
            string varGroupName, 
            int intervalMillis,
            Action<JSONResponse> onUpdate)
        {
            if (responseHandlers.ContainsKey(varGroupName))
            {
                throw new InvalidOperationException($"Already monitoring var group {varGroupName}.");
            }

            JSONRequest request = new JSONVarsRequest
            {
                command = "vars.read",
                name = varGroupName,
                interval = intervalMillis
            };

            var response = ConvertResponse.vars.read(await SendAndAwait(request).ConfigureAwait(false));
            lock (responseHandlers)
            {
                responseHandlers.Add(varGroupName, new ResponseHandler(onUpdate, false));
            }

            return response;
        }

        public async Task<JSONResponse> StopVariableGroupPolling(string varGroupName)
        {
            JSONRequest request = new JSONVarsRequest
            {
                command = "vars.stop",
                name = varGroupName,
            };

            lock(responseHandlers)
            {
                responseHandlers.Remove(varGroupName);
            }

            return ConvertResponse.vars.stop(await SendAndAwait(request).ConfigureAwait(false));
        }

        public async Task<JSONAboutResponse> About()
        {
            JSONRequest request = new JSONRequest()
            {
                command = "about.read"
            };

            return ConvertResponse.about.read(await SendAndAwait(request));
        }

        private async Task<JSONResponse?> SendAndAwait(JSONRequest request)
        {
            SemaphoreSlim semaphoreSlim = new SemaphoreSlim(0, 1);

            JSONResponse response = null;

            string ident = Send(request, _response =>
            {
                response = _response;
                semaphoreSlim.Release();
            });

            Task<bool> task = semaphoreSlim.WaitAsync(TimeoutMillis);
            await task.ConfigureAwait(false);

            if (!task.Result)
            {
                responseHandlers.Remove(ident);
            }

            return response;
        }

        private string Send(JSONRequest request, Action<JSONResponse> responseHandler)
        {
            string identifier = string.IsNullOrEmpty(request.name) ?
                Guid.NewGuid().ToString() : request.name;

            request.name = identifier;

            lock (responseHandlers)
            {
                responseHandlers.Add(identifier, new ResponseHandler(responseHandler));
            }

            requestQueue.Add((request, identifier));

            return identifier;
        }

        private void Ws_ResponseReceived(object? sender, FSUIPCResponseEventArgs e)
        {
            Log($"[Recieved] {e.response.name} : {e.response.command}");

            ResponseHandler? handler = null;

            if (responseHandlers.TryGetValue(e.response.name, out handler))
            {
                if (handler.DeleteOnceHandled)
                {
                    lock (responseHandlers)
                    {
                        responseHandlers.Remove(e.response.name);
                    }
                }
            }
            else
            {
                Log($"No handler for {e.response.name}");
            }

            handler?.HandleResponse.Invoke(e.response);
        }

        private void Ws_Error(object? sender, FSUIPCErrorEventArgs e)
        {
            Log($"[!! SOCKET ERROR !!] : {e}");
        }

        private void Ws_StateChanged(object? sender, EventArgs e)
        {
            Log($"[SOCKET STATE CHANGED] Socket {ws.State}");

            switch (ws.State)
            {
                case System.Net.WebSockets.WebSocketState.Open:
                    
                    if (socketTask != null)
                    {
                        Log("[WARN] Socket was opened previously. Ignoring.");
                        return;
                    }

                    socketTask = Task.Run(() =>
                    {
                        HandleMessages(cts.Token);
                    }, cts.Token);
                    break;

                default:
                    break;
            }
        }

        private void Log(string message)
        {
            //Console.WriteLine($"[WS] {message}");
        }

        public void Dispose()
        {
            cts.Cancel();
        }
    }
}
