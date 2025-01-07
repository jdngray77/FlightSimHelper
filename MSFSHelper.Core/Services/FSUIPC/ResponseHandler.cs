using FSUIPCWebSockets.JSONDataStructures;

namespace MSFSHelper.Core.FSUIPC
{
    internal class ResponseHandler
    {
        public ResponseHandler()
        {
        }

        public ResponseHandler(Action<JSONResponse> handleResponse)
        {
            HandleResponse = handleResponse;
        }

        public ResponseHandler(Action<JSONResponse> handleResponse, bool oneShot) : this(handleResponse)
        {
            DeleteOnceHandled = oneShot;
        }

        public Action<JSONResponse> HandleResponse { get; set; }

        public bool DeleteOnceHandled { get; set; } = true;
    }
}
