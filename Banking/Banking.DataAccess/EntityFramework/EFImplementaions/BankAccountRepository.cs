using Banking.DataAccess.Interfaces;
using Banking.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banking.DataAccess.EntityFramework.EFImplementaions
{
    public class BankAccountRepository : IRepository<BankAccount>
    {
        private readonly BankingContext _context;
        private readonly ILogger<BankAccountRepository> _logger;

        public BankAccountRepository(BankingContext context, ILogger<BankAccountRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public bool Add(BankAccount entity)
        {
            try
            {
                _context.BankAccounts.Add(entity);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public bool Delete(BankAccount entity)
        {
            try
            {
                _context.BankAccounts.Remove(entity);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public bool Edit(BankAccount entity)
        {
            try
            {
                _context.BankAccounts.Update(entity);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public BankAccount Get(Guid id)
        {
            return _context.BankAccounts.Include(x => x.User).Include(x => x.BankCards).FirstOrDefault(x => x.Id == id);
        }

        public IList<BankAccount> GetAll()
        {
            return _context.BankAccounts.Include(x => x.User).Include(x => x.BankCards).ToList();
        }
    }
}
