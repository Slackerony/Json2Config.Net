# Json2Config.Net
An easy to use, library for converting a class into Json and then save it to a local config file.

        static void Main(string[] args)
        {
            //Creates the config folder & config.json
            ConfigManager cfg = new ConfigManager("ConsoleApplication5");

            //Get the class ready
            Repository repo = new Repository();
            //Add some stuff
            repo.Name = "Something Or The Other";
            repo.RepoConfigs.Add(new RepositoryConfig() { Name = "Bubbula01" });
            repo.RepoConfigs.Add(new RepositoryConfig() { Name = "Bubbula02" });
            repo.RepoConfigs.Add(new RepositoryConfig() { Name = "Bubbula03" });

            //Save the class
            cfg.SaveConfig<Repository>(repo);

            //load all the class u just saved
            Repository loadedRepo = cfg.LoadConfig<Repository>();

            //This will tell you where the config file is located
            System.Console.WriteLine(cfg.Config.FullName);

        }
    }

    public class Repository
    {
        public string Name { get; set; }
        public List<RepositoryConfig> RepoConfigs { get; set; }

        public Repository()
        {
            RepoConfigs = new List<RepositoryConfig>();
        }
    }
    public class RepositoryConfig
    {
        public string Name { get; set; }
        public string GitUrl { get; set; }
        public string GitPath { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }