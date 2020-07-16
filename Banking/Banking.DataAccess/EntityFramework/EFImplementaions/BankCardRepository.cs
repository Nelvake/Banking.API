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
    public class BankCardRepository : IRepository<BankCard>
    {
        private readonly BankingContext _context;
        private readonly ILogger<BankAccountRepository> _logger;

        public BankCardRepository(BankingContext context, ILogger<BankAccountRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public bool Add(BankCard entity)
        {
            try
            {
                _context.BankCards.Add(entity);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public bool Delete(BankCard entity)
        {
            try
            {
                _context.BankCards.Remove(entity);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public bool Edit(BankCard entity)
        {
            try
            {
                _context.BankCards.Update(entity);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public BankCard Get(Guid id)
        {
            return _context.BankCards.Include(x => x.BankAccount).ThenInclude(x => x.User).FirstOrDefault(x => x.Id == id);
        }

        public IList<BankCard> GetAll()
        {
            return _context.BankCards.Include(x => x.BankAccount).ThenInclude(x => x.User).ToList();
        }
    }
}
