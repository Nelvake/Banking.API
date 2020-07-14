using Banking.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<BankAccount> BankAccounts { get; set; }
        IRepository<BankCard> BankCards { get; set; }
        IRepository<User> Users { get; set; }
        IRepository<Service> Services { get; set; }
        IRepository<ServiceProvider> ServiceProviders { get; set; }

        void Save();

        void BeginTransaction();

        void Commit();

        void Rollback();
    }
}
