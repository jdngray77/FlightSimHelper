using MSFSHelper.Core.Checklists;
using System.Reflection.Metadata.Ecma335;
using System.Xml;
using System.Xml.Serialization;

namespace MSFSHelper.Core.Serialization
{
    public static class Serialization
    {
        public static void SerializeToXml(object obj, string filePath)
        {
            
            XmlSerializer serializer = new XmlSerializer(obj.GetType());

            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                NewLineOnAttributes = false,
                OmitXmlDeclaration = true,
                IndentChars = "\t",
                NewLineChars = Environment.NewLine,
            };

            
            using (XmlWriter writer = XmlWriter.Create(filePath, settings))
            {
                serializer.Serialize(writer, obj);
            }
        }

        public static ChecklistGroup ChecklistsFromDataDir()
        {
            const string DataDir = "./Data/Checklists/";
            List<Checklist> checklists = new();

            if (!Directory.Exists(DataDir))
            {
                throw new Exception("Checklist data directory does not exist");
            }

            string[] files = Directory.GetFiles(DataDir);

            foreach (string file in files) 
            {
                checklists.AddRange(ChecklistsFromFile(file));
            }

            return new ChecklistGroup(checklists.ToArray());
        }

        public static IList<Checklist> ChecklistsFromFile(string filePath)
        {
            try
            {
                return DeserializeChecklistGroupFromXml(filePath).Checklists;
            }
            catch (Exception) { }

            try
            {
                return new List<Checklist>() { DeserializeChecklistFromXml(filePath) };
            }
            catch (Exception) { }

            return new List<Checklist>();
        }

        public static ChecklistGroup DeserializeChecklistGroupFromXml(string filePath)
        {
            return DeserializeFromXml<ChecklistGroup>(filePath);
        }

        public static Checklist DeserializeChecklistFromXml(string filePath)
        {
            return DeserializeFromXml<Checklist>(filePath);
        }

        public static T DeserializeFromXml<T>(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                var x = (T)serializer.Deserialize(fileStream);
                (x as IPostDeserialization)?.PostDeserialize();
                return x;
            }
        }
    }
}
