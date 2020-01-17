using kelolakeuangan.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace kelolakeuangan.Data
{
    public class DummyData
    {

        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<KKContext>();
                context.Database.EnsureCreated();

                if (context.Accounts != null && context.Accounts.Any())
                {
                    return;
                }


                var incomes = DummyData.GetIncomes().ToArray();
                context.Incomes.AddRange(incomes);
                context.SaveChanges();

                var spendings = DummyData.GetSpendings().ToArray();
                context.Spendings.AddRange(spendings);
                context.SaveChanges();

                var wallets = DummyData.GetWallets(context).ToArray();
                context.Wallets.AddRange(wallets);
                context.SaveChanges();

                var accounts = DummyData.GetAccounts(context).ToArray();
                context.Accounts.AddRange(accounts);
                context.SaveChanges();

            }
        }

        public static List<Income> GetIncomes()
        {
            List<Income> incomes = new List<Income>()
            {
                new Income {Date=DateTime.Now, Amount=10000000, Note="Salary"},
                new Income {Date=DateTime.Now, Amount=20000000, Note="Salary"},
                new Income {Date=DateTime.Now, Amount=30000000, Note="Salary"},
                new Income {Date=DateTime.Now, Amount=30000000, Note="Bonus"}
            };

            return incomes;
        }

        public static List<Wallet> GetWallets(KKContext db)
        {
            List<Wallet> wallets = new List<Wallet>()
            {
                new Wallet {Name="Dompet 1", Limit=5000000},
                new Wallet {Name="Dompet 2", Limit=3000000},
                new Wallet {Name="Dompet 3", Limit=2000000},
                new Wallet {Name="Dompet 4", Limit=15000000},
                new Wallet {Name="Dompet 5", Limit=15000000},
                new Wallet {Name="Dompet 6", Limit=15000000},
                new Wallet {Name="Dompet 7", Limit=15000000}
            };
            return wallets;
        }

        public static List<Spending> GetSpendings()
        {
            List<Spending> spendings = new List<Spending>()
            {
                new Spending {Date=DateTime.Now, Amount=200000, Note="Spending 1" },
                new Spending {Date=DateTime.Now, Amount=400000, Note="Spending 2" },
                new Spending {Date=DateTime.Now, Amount=500000, Note="Spending 3" },
                new Spending {Date=DateTime.Now, Amount=600000, Note="Spending 4" },
                new Spending {Date=DateTime.Now, Amount=700000, Note="Spending 5" },
                new Spending {Date=DateTime.Now, Amount=800000, Note="Spending 6" },
                new Spending {Date=DateTime.Now, Amount=500000, Note="Spending 7" }
            };

            return spendings;
        }

        public static List<Account> GetAccounts(KKContext db)
        {
            List<Account> accounts = new List<Account>()
            {
                new Account
                {
                    Username = "user1",
                    Password = "123",
                    Name = "User 1",
                    DOB = DateTime.Parse("2016-09-01") ,
                    Email = "user1@gmail.com",

                    Incomes = new List<Income>(db.Incomes.OrderBy(i => i.Id_Income).Take(1)),
                    Wallets = new List<Wallet>(db.Wallets.OrderBy(i => i.Id_Wallet).Take(1)),
                    Spendings = new List<Spending>(db.Spendings.OrderBy(i => i.Id_Spending).Take(1))
                },
                new Account
                {
                    Username = "user2",
                    Password = "123",
                    Name = "User 2",
                    DOB = DateTime.Parse("2016-09-01") ,
                    Email = "user2@gmail.com",

                    Incomes = new List<Income>(db.Incomes.OrderBy(i => i.Id_Income).Skip(1).Take(1)),
                    Wallets = new List<Wallet>(db.Wallets.OrderBy(i => i.Id_Wallet).Skip(1).Take(1)),
                    Spendings = new List<Spending>(db.Spendings.OrderBy(i => i.Id_Spending).Skip(1).Take(1))
                },
                new Account
                {
                    Username = "user3",
                    Password = "123",
                    Name = "User 3",
                    DOB = DateTime.Parse("2016-09-01") ,
                    Email = "user3@gmail.com",
                    Id_Family = 1,

                    Incomes = new List<Income>(db.Incomes.OrderBy(i => i.Id_Income).Skip(2).Take(2)),
                    Wallets = new List<Wallet>(db.Wallets.OrderBy(i => i.Id_Wallet).Skip(2).Take(2)),
                    Spendings = new List<Spending>(db.Spendings.OrderBy(i => i.Id_Spending).Skip(2).Take(2))
                }
            };

            return accounts;
        }



    }
}
