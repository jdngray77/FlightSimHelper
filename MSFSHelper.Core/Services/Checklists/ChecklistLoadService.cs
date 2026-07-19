using System.Xml.Serialization;
using CommunityToolkit.Mvvm.Messaging;
using MSFSHelper.Core.Checklists;

namespace MSFSHelper.Core.Services.Checklists;

public class ChecklistLoadService
{
    private const string ChecklistDirectory = "Data/Checklists/";

    private readonly IMessenger messenger;

    public ChecklistLoadService(IMessenger messenger)
    {
        this.messenger = messenger;
    }

    public List<ChecklistGroup> ChecklistGroups { get; } = new List<ChecklistGroup>();

    public void LoadChecklists()
    {
        Console.WriteLine("Loading checklists...");

        string directory = Path.Combine(AppContext.BaseDirectory, ChecklistDirectory);

        var files = Directory.EnumerateFiles(directory);

        Console.WriteLine($"{files.Count()} files in {directory}.");

        XmlSerializer serializer = new XmlSerializer(typeof(ChecklistGroup));
        
        foreach (var file in files)
        {
            if (!file.EndsWith(".xml"))
            {
                Console.WriteLine($"{file} is not xml; skipping.");
                continue;
            }
            
            Console.WriteLine($"Loading file {file}");

            try
            {
                ChecklistGroup checklistGroup;

                using (FileStream stream = File.OpenRead(file))
                {
                    checklistGroup = (ChecklistGroup)serializer.Deserialize(stream)!;
                } 
                
                ChecklistGroups.Add(checklistGroup);
                Console.WriteLine($"Loaded {file}");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine("Failed to load file " + file);
            }
            
            Console.WriteLine($"Loaded {ChecklistGroups.Count} checklist groups.");
            foreach (var checklistGroup in ChecklistGroups)
            {
                checklistGroup.PostDeserialize();
            }
        }
    }
}