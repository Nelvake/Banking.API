using Banking.DataAccess.Interfaces;
using Banking.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.DataAccess.EntityFramework.EFImplementaions
{
    public class ServiceProviderRepository : IRepository<ServiceProvider>
    {
        public bool Add(ServiceProvider entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(ServiceProvider entity)
        {
            throw new NotImplementedException();
        }

        public bool Edit(ServiceProvider entity)
        {
            throw new NotImplementedException();
        }

        public ServiceProvider Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IList<ServiceProvider> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
