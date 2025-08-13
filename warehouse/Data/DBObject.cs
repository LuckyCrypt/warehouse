using Microsoft.AspNetCore.Builder;
using Mono.TextTemplating;
using NuGet.Packaging;
using NuGet.Protocol.Core.Types;
using warehouse.Data.Models;

namespace warehouse.Data
{
    public class DBObject
    {
        public static void initial(AppDbContext dbContent)
        { 
            if (!dbContent.Units.Any())
                    dbContent.Units.AddRange(AllUnits.Select(c => c.Value));

            if (!dbContent.Resources.Any())
                dbContent.Resources.AddRange(AllResources.Select(c => c.Value));

            if (!dbContent.Clients.Any())
                dbContent.Clients.AddRange(AllClients.Select(c => c.Value));


            if (!dbContent.StockBalances.Any())
                dbContent.StockBalances.AddRange(AllBalances.Select(c => c.Value));


            dbContent.SaveChanges();
        }

        #region Initialize Units
        private static Dictionary<string, Units> units;

        public static Dictionary<string, Units> AllUnits {
            get 
            {
                if (units == null)
                {
                    var list = new Units[]
                    {
                        new Units { Name = "шт"},
                        new Units { Name = "доллор"},
                        new Units { Name = "кг"},
                        new Units { Name = "тонны"},
                        new Units { Name = "рубли"}
                    };
                    units = new Dictionary<string, Units>();
                    foreach (Units unit in list)
                    {
                        units.Add(unit.Name, unit);
                    }
                }
                return units;
            }
        }
        #endregion

        #region Initialize Resources
        private static Dictionary<string, Resources> resources;

        public static Dictionary<string, Resources> AllResources
        {
            get
            {
                if (resources == null)
                {
                    var list = new Resources[]
                    {
                        new Resources { Name = "Ящик"},
                        new Resources { Name = "Коробка"},
                        new Resources { Name = "Палета"},
                        new Resources { Name = "Еда"},
                        new Resources { Name = "Пакет"}
                    };
                    resources = new Dictionary<string, Resources>();
                    foreach (Resources resource in list)
                    {
                        resources.Add(resource.Name, resource);
                    }
                }
                return resources;
            }
        }
        #endregion

        #region Initialize Clients
        private static Dictionary<string, Clients> clients;

        public static Dictionary<string, Clients> AllClients
        {
            get
            {
                if (clients == null)
                {
                    var list = new Clients[]
                    {
                        new Clients { Name = "AmongUs",Address = "Да да деньги"},
                        new Clients { Name = "NotAmongUs",Address = "Ytn ytn ltymub"}
                    };
                    clients = new Dictionary<string, Clients>();
                    foreach (Clients client in list)
                    {
                        clients.Add(client.Name, client);
                    }
                }
                return clients;
            }
        }
        #endregion

        #region Initialize Balance

        private static Dictionary<string, StockBalance> StockBalances;

        public static Dictionary<string, StockBalance> AllBalances
        {
            get
            {
                if (StockBalances == null)
                {
                    StockBalances = new Dictionary<string, StockBalance>();
                    // Пример заполнения
                    StockBalance balance1 = new StockBalance();
                    balance1.Resource = AllResources["Ящик"];
                    balance1.Unit = AllUnits["шт"];
                    balance1.Quantity = 100;
                    balance1.ResourceId = 1; // Замените на корректный ID
                    balance1.UnitId = 1; // Замените на корректный ID
                    StockBalances.Add(AllResources["Ящик"].Name, balance1);

                    StockBalance balance2 = new StockBalance();
                    balance2.Resource = AllResources["Еда"];
                    balance2.Unit = AllUnits["кг"];
                    balance2.Quantity = 50.5m;
                    balance2.ResourceId = 4; // Замените на корректный ID
                    balance2.UnitId = 3; // Замените на корректный ID
                    StockBalances.Add(AllResources["Еда"].Name,balance2);
                }
                return StockBalances;
            }
        }
        #endregion



    }
}
