using System;
using System.IO;

namespace Json2Config.Net.Models
{
    public class Config
    {
        public readonly string Name;
        public readonly string ApplicationConfigFolder;  

        public string FullName
        {
            get
            {
                return Path.Combine(ApplicationConfigFolder, Name);
            }
        }

        public Config(string applicationName, string configName)
        {
            this.Name = string.Format("{0}.json", configName);
            this.ApplicationConfigFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), applicationName);

        }

        public bool Exists()
        {
            return File.Exists(FullName);
        }

        internal void CreateDirectory()
        {
            Directory.CreateDirectory(ApplicationConfigFolder);
        }
        internal void CreateConfig()
        {
            File.Create(this.FullName);
        }
        internal string RawJson()
        {
            using (StreamReader sr = new StreamReader(FullName))
            {
                return sr.ReadToEnd();
            }
        }

    }
}
