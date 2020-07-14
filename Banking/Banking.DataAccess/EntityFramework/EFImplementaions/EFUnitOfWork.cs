using Banking.DataAccess.Interfaces;
using Banking.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.DataAccess.EntityFramework.EFImplementaions
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly BankingContext _context;
        public IRepository<BankAccount> BankAccounts { get; set; }
        public IRepository<BankCard> BankCards { get; set; }
        public IRepository<User> Users { get; set; }
        public IRepository<Service> Services { get; set; }
        public IRepository<ServiceProvider> ServiceProviders { get; set; }

        public EFUnitOfWork(
             IRepository<BankAccount> bankAccount,
             IRepository<BankCard> bankCard,
             IRepository<User> user,
             IRepository<Service> service,
             IRepository<ServiceProvider> serviceProvider,
             BankingContext context)
        {
            _context = context;
            BankAccounts = bankAccount;
            BankCards = bankCard;
            Services = service;
            Users = user;
            ServiceProviders = serviceProvider;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            if (_context.Database.CurrentTransaction != null)
            {
                _context.Database.CurrentTransaction.Commit();
            }
        }

        public void Rollback()
        {
            if (_context.Database.CurrentTransaction != null)
            {
                _context.Database.CurrentTransaction.Rollback();
            }
        }
    }
}
