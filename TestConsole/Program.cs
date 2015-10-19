using Json2Config.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //App name, this is what the folder will be called in Appdata\Local\<appNameSpace>
            string appNamespace = "Json2Config.Net";

            //Creates the config folder & config.json
            ConfigManager burgerCfg = new ConfigManager(appNamespace, "burgerCfg");
            ConfigManager securityCfg = new ConfigManager(appNamespace, "securityCfg");

            //Get the objects ready
            Store myStore = new Store();

            myStore.Name = "Bobs Burgers";
            Product product1 = new Product() { Name = "Cheese Burgers", Price = 7.99 };
            Product product2 = new Product() { Name = "Pizza", Price = 12.49 };
            myStore.Products.Add(product1);
            myStore.Products.Add(product2);

            //Save the objects!
            burgerCfg.SaveConfig(myStore);


            Company myCompany = new Company();

            myCompany.CompanyId = 1;
            myCompany.CompanyName = "Jacks Security Folk";
            Client client1 = new Client() { ClientId = 1, Name = "Bobs Burgers", WebsiteUrl = "BobsBurgers.biz" };
            myCompany.Clients.Add(client1);

            securityCfg.SaveConfig(myCompany);

        }
    }
    class Store
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }

        public Store()
        {
            Products = new List<Product>();
        }
    }
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }

    class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public List<Client> Clients { get; set; }

        public Company()
        {
            Clients = new List<Client>();
        }
    }
    class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string WebsiteUrl { get; set; }
    }
}