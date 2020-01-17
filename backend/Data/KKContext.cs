using kelolakeuangan.Models;
using Microsoft.EntityFrameworkCore;

namespace kelolakeuangan.Data
{
    public class KKContext : DbContext
    {
        public KKContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Account>().ToTable("Account");
            builder.Entity<Income>().ToTable("Income");
            builder.Entity<Wallet>().ToTable("Wallet");
            builder.Entity<Spending>().ToTable("Spending");

            ////Define Column
            //builder.Entity<Account>(eb =>
            //        {
            //            eb.Property(b => b.Username).HasColumnType("varchar(20)");
            //            eb.Property(b => b.Password).HasColumnType("varchar(20)");
            //            eb.Property(b => b.Name).HasColumnType("varchar(50)");
            //            eb.Property(b => b.DOB).HasColumnType("date");
            //            eb.Property(b => b.Email).HasColumnType("varchar(50)");
            //            eb.Property(b => b.Id_Family).HasColumnType("int");
            //        });
            ////Setting Key
            //builder.Entity<Account>().HasKey(c => c.Id_Account);
            //builder.Entity<Income>().HasKey(c => c.Id_Income);
            //builder.Entity<Wallet>().HasKey(c => c.Id_Wallet);
            //builder.Entity<Spending>().HasKey(c => c.Id_Spending);

            ////Setting Not Null
            //builder.Entity<Account>().Property(b => b.Username).IsRequired();
            //builder.Entity<Account>().Property(b => b.Password).IsRequired();
            //builder.Entity<Account>().Property(b => b.Name).IsRequired();
            //builder.Entity<Account>().Property(b => b.Email).IsRequired();
            ////Add Default Value
            //builder.Entity<Account>().Property(b => b.DOB).HasDefaultValueSql("getdate()");
            ////Indexing
            //builder.Entity<Account>().HasIndex(p => new { p.Name, p.Email });

            //Account 1...* Income
            //builder.Entity<Income>()
            //    .HasOne<Account>()
            //    .WithMany()
            //    .HasForeignKey(p => p.Id_Account);

            //Account 1...* Spending
            //builder.Entity<Spending>()
            //   .HasOne<Account>()
            //   .WithMany()
            //   .HasForeignKey(p => p.Id_Account);

            //Account 1...* Wallet
            //builder.Entity<Wallet>()
            //   .HasOne<Account>()
            //   .WithMany()
            //   .HasForeignKey(p => p.Id_Account);

            //Seed Data
            //builder.Entity<Account>().HasData(
            //    new Account() { Id_Account = 1, Username = "user1", Password = "123", Name = "User 1", DOB = DateTime.Now, Email = "user1@gmail.com",
            //    },
            //    new Account() { Id_Account = 2, Username = "user2", Password = "123", Name = "User 2", DOB = DateTime.Now, Email = "user2@gmail.com" },
            //    new Account() { Id_Account = 3, Username = "user3", Password = "123", Name = "User 3", DOB = DateTime.Now, Email = "user3@gmail.com" }
            //    );

            //builder.Entity<Income>().HasData(
            //    //new Income() { Id_Account = 1, Id_Income = 1, Amount = 10000000, Date = DateTime.Now, Note = "Salary" },
            //    //new Income() { Id_Account = 1, Id_Income = 2, Amount = 5000000, Date = DateTime.Now, Note = "Gift" },
            //    //new Income() { Id_Account = 1, Id_Income = 3, Amount = 5000000, Date = DateTime.Now, Note = "Allowance" },
            //    //new Income() { Id_Account = 2, Id_Income = 4, Amount = 10000000, Date = DateTime.Now, Note = "Salary" },
            //    //new Income() { Id_Account = 2, Id_Income = 5, Amount = 5000000, Date = DateTime.Now, Note = "Gift" },
            //    //new Income() { Id_Account = 3, Id_Income = 6, Amount = 5000000, Date = DateTime.Now, Note = "Allowance" }

            //    new Income() { Id_Income = 1, Amount = 10000000, Date = DateTime.Now, Note = "Salary" },
            //    new Income() { Id_Income = 2, Amount = 5000000, Date = DateTime.Now, Note = "Gift" },
            //    new Income() { Id_Income = 3, Amount = 5000000, Date = DateTime.Now, Note = "Allowance" },
            //    new Income() { Id_Income = 4, Amount = 10000000, Date = DateTime.Now, Note = "Salary" },
            //    new Income() { Id_Income = 5, Amount = 5000000, Date = DateTime.Now, Note = "Gift" },
            //    new Income() { Id_Income = 6, Amount = 5000000, Date = DateTime.Now, Note = "Allowance" }

            //    );

            //builder.Entity<Wallet>().HasData(
            //    new Wallet() { Id_Wallet = 1, Name = "User 1 Wallet 1", Limit = 5000000},
            //    new Wallet() { Id_Wallet = 2, Name = "User 1 Wallet 2", Limit = 5000000 },
            //    new Wallet() { Id_Wallet = 3, Name = "User 1 Wallet 3", Limit = 5000000 },
            //    new Wallet() { Id_Wallet = 4, Name = "User 2 Wallet 1", Limit = 5000000 },
            //    new Wallet() { Id_Wallet = 5, Name = "User 2 Wallet 2", Limit = 5000000 },
            //    new Wallet() { Id_Wallet = 6, Name = "User 3 Wallet 1", Limit = 5000000 },
            //    new Wallet() { Id_Wallet = 7, Name = "User 3 Wallet 2", Limit = 5000000 }
            //    );

            //builder.Entity<Spending>().HasData(
            //    new Spending() { Id_Account = 1, Id_Wallet = 1, Id_Spending = 1, Note = "User 1 Spending 1", Amount = 500000, Date = DateTime.Now },
            //    new Spending() { Id_Account = 1, Id_Wallet = 2, Id_Spending = 2, Note = "User 1 Spending 2", Amount = 250000, Date = DateTime.Now },
            //    new Spending() { Id_Account = 1, Id_Wallet = 2, Id_Spending = 3, Note = "User 1 Spending 3", Amount = 100000, Date = DateTime.Now },
            //    new Spending() { Id_Account = 2, Id_Wallet = 4, Id_Spending = 4, Note = "User 2 Spending 1", Amount = 500000, Date = DateTime.Now },
            //    new Spending() { Id_Account = 2, Id_Wallet = 5, Id_Spending = 5, Note = "User 2 Spending 2", Amount = 500000, Date = DateTime.Now },
            //    new Spending() { Id_Account = 3, Id_Wallet = 7, Id_Spending = 6, Note = "User 3 Spending 1", Amount = 500000, Date = DateTime.Now },
            //    new Spending() { Id_Account = 3, Id_Wallet = 7, Id_Spending = 7, Note = "User 3 Spending 2", Amount = 500000, Date = DateTime.Now }
            //    );
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Spending> Spendings { get; set; }
        public DbSet<Wallet> Wallets { get; set; }


    }
}
