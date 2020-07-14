using Banking.DataAccess.Interfaces;
using Banking.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.DataAccess.EntityFramework.EFImplementaions
{
    public class ServiceRepository : IRepository<Service>
    {
        public bool Add(Service entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Service entity)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Service entity)
        {
            throw new NotImplementedException();
        }

        public Service Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IList<Service> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
