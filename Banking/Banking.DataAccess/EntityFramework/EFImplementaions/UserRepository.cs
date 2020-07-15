using Banking.DataAccess.Interfaces;
using Banking.Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banking.DataAccess.EntityFramework.EFImplementaions
{
    public class UserRepository : IRepository<User>
    {
        private readonly BankingContext _context;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(BankingContext context, ILogger<UserRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public bool Add(User entity)
        {
            try
            {
                _context.Users.Add(entity);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public bool Delete(User entity)
        {
            try
            {
                _context.Users.Remove(entity);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public bool Edit(User entity)
        {
            try
            {
                _context.Users.Update(entity);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public User Get(Guid id)
        {
            try
            {
                return _context.Users.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public IList<User> GetAll()
        {
            return _context.Users.ToList();
        }
    }
}
