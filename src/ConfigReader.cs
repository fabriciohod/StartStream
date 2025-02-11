using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace StartStream
{
    class ProgramsContainer
    {
        public List<ProgramItem>? Programs { get; set; } = new();
    }

    public class ProgramItem
    {
        public string Name { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public string? LaunchOptions { get; set; } = string.Empty;
        public bool RunAsAdmin { get; set; } = false;
    }

    public static class ConfigReader
    {
        public static List<ProgramItem> LoadProgramsFromYaml(string yamlFilePath)
        {
            Logger logger = new Logger("Logs");

            if (!File.Exists(yamlFilePath))
            {
                Console.WriteLine("Programs.yaml not found.");

                logger.Error($"Programs.yaml not found at path: {yamlFilePath}");
                return new List<ProgramItem>();
            }

            try
            {
                string yamlContent = File.ReadAllText(yamlFilePath);
                IDeserializer deserializer = new DeserializerBuilder()
                    .WithNamingConvention(CamelCaseNamingConvention.Instance)
                    .Build();

                ProgramsContainer programsData = deserializer.Deserialize<ProgramsContainer>(yamlContent);
                return programsData.Programs ?? new List<ProgramItem>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro while reading config file: {ex}");
                logger.Error($"Erro while reading config file: {ex}");
                return new List<ProgramItem>();
            }
        }
    }
}