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

        public Config(string applicationName)
        {
            this.Name = "config.json";
            this.ApplicationConfigFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), applicationName);

        }

        public bool Exists()
        {
            if (File.Exists(FullName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal void CreateDirectory()
        {
            Directory.CreateDirectory(ApplicationConfigFolder);
        }
        internal void CreateConfig()
        {
            File.Create(this.FullName);
        }
        internal string Json()
        {
            using (StreamReader sr = new StreamReader(FullName))
            {
                return sr.ReadToEnd();
            }
        }

    }
}
