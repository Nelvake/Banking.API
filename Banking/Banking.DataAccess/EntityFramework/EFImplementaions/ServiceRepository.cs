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
    public class ServiceRepository : IRepository<Service>
    {
        private readonly BankingContext _context;
        private readonly ILogger<ServiceRepository> _logger;

        public ServiceRepository(BankingContext context, ILogger<ServiceRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public bool Add(Service entity)
        {
            try
            {
                _context.Services.Add(entity);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public bool Delete(Service entity)
        {
            try
            {
                _context.Services.Remove(entity);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public bool Edit(Service entity)
        {
            try
            {
                _context.Services.Update(entity);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public Service Get(Guid id)
        {
            return _context.Services.Include(x => x.BankCard).Include(x => x.ServiceProvider).FirstOrDefault(x => x.Id == id);
        }

        public IList<Service> GetAll()
        {
            return _context.Services.Include(x => x.BankCard).Include(x => x.ServiceProvider).ToList();
        }
    }
}
