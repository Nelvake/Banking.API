using Banking.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.DataAccess.EntityFramework
{
    public class BankingContext : DbContext
    {
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<BankCard> BankCards { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceProvider> ServiceProviders { get; set; }

        public BankingContext(DbContextOptions<BankingContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
