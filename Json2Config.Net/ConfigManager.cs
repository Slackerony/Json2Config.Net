using Json2Config.Net.Models;
using Newtonsoft.Json;
using System.IO;

namespace Json2Config.Net
{
    public class ConfigManager
    {
        private JsonSerializer serializer;

        public Config ConfigFile { get; set; }

        public ConfigManager(
            string applicationName, 
            string configFileName = "config.json", 
            Formatting jsonFormat = Formatting.Indented)
        {
            this.serializer = new JsonSerializer();
            this.ConfigFile = new Config(applicationName, configFileName);

            if (!ConfigFile.Exists())
            {
                ConfigFile.CreateDirectory();
                ConfigFile.CreateConfig();
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
    }
}
