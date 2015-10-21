using Json2Config.Net.Models;
using Newtonsoft.Json;
using System.IO;

namespace Json2Config.Net
{
    public class ConfigManager
    {
        private const string DEFAULT_CONFIG_NAME = "config";
        private const bool DEFAULT_CONFIG_AUTOCREATE = true;
        private const Formatting DEFAULT_CONFIG_JSON_FORMATTING = Formatting.Indented;

        private JsonSerializer serializer;

        public Config ConfigFile { get; set; }
        public bool ConfigWasCreated { get; set; }

        public ConfigManager(string applicationName)
            : this(applicationName, DEFAULT_CONFIG_NAME)
        {

        }
        public ConfigManager(string applicationName, string configFileName)
            : this(applicationName, configFileName, DEFAULT_CONFIG_AUTOCREATE)
        {
            
        }
        public ConfigManager(string applicationName, bool CreateConfigIfNotExists)
            : this(applicationName, DEFAULT_CONFIG_NAME, CreateConfigIfNotExists)
        {

        }
        public ConfigManager(string applicationName, string configFileName, bool CreateConfigIfNotExists)
            : this(applicationName, configFileName, CreateConfigIfNotExists, DEFAULT_CONFIG_JSON_FORMATTING)
        {
            
        }

        public ConfigManager(
            string applicationName,
            string configFileName,
            bool CreateConfigIfNotExists,
            Formatting jsonFormat)
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
        public void CreateAndSave<T>(T obj)
        {
            CreateConfig();
            SaveConfig<T>(obj);
        }
    }
}
