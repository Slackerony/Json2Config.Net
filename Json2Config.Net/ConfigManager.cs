using Json2Config.Net.Models;
using Newtonsoft.Json;
using System.IO;

namespace Json2Config.Net
{
    public class ConfigManager
    {
        public Config Config { get; set; }

        public ConfigManager(string applicationName)
        {
            this.Config = new Config(applicationName);

            if (!Config.Exists())
            {
                Config.CreateDirectory();
                Config.CreateConfig();
            }
            

        }

        public void SaveConfig<T>(T obj)
        {
            using (StreamWriter file = File.CreateText(Config.FullName))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Formatting = Formatting.Indented;

                serializer.Serialize(file, obj);
            }
        }
        public T LoadConfig<T>()
        {
            T value = JsonConvert.DeserializeObject<T>(Config.Json());
            return value;
        }
    }
}
