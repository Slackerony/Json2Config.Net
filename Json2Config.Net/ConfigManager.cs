using Json2Config.Net.Models;
using Newtonsoft.Json;
using System.IO;

namespace Json2Config.Net
{
    public class ConfigManager
    {
        private JsonSerializer serializer;

        public Config ConfigFile { get; set; }
        public bool ConfigWasCreated { get; set; }

        public ConfigManager(
            string applicationName,
            string configFileName = "config",
            bool CreateConfigIfNotExists = true,
            Formatting jsonFormat = Formatting.Indented)
        {
            this.serializer = new JsonSerializer();
            this.serializer.Formatting = jsonFormat;

            this.ConfigFile = new Config(applicationName, configFileName);

            if (CreateConfigIfNotExists)
            {
                this.ConfigWasCreated = CreateConfig();
            }
        }

        public void SaveConfig<T>(T obj)
        {
            using (StreamWriter file = File.CreateText(ConfigFile.FullName))
            {
                serializer.Serialize(file, obj);
            }
        }
        public T LoadConfig<T>()
        {
            return JsonConvert.DeserializeObject<T>(ConfigFile.RawJson());
        }
        public bool CreateConfig()
        {
            bool created = false;

            if (!ConfigFile.Exists())
            {
                ConfigFile.CreateDirectory();
                ConfigFile.CreateConfig();
                created = true;
            }
            else
            {
                created = false;
            }
            return created;
        }
    }
}
