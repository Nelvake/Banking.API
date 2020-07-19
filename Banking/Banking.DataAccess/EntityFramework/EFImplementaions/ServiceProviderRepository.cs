using Banking.DataAccess.Interfaces;
using Banking.Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banking.DataAccess.EntityFramework.EFImplementaions
{
    public class ServiceProviderRepository : IRepository<ServiceProvider>
    {
        private readonly BankingContext _context;
        private readonly ILogger<ServiceProviderRepository> _logger;

        public ServiceProviderRepository(BankingContext context, ILogger<ServiceProviderRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public bool Add(ServiceProvider entity)
        {
            try
            {
                _context.ServiceProviders.Add(entity);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public bool Delete(ServiceProvider entity)
        {
            try
            {
                _context.ServiceProviders.Remove(entity);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public bool Edit(ServiceProvider entity)
        {
            try
            {
                _context.ServiceProviders.Update(entity);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public ServiceProvider Get(Guid id)
        {
            return _context.ServiceProviders.Find(id);
        }

        public IList<ServiceProvider> GetAll()
        {
            return _context.ServiceProviders.ToList();
        }
    }
}
