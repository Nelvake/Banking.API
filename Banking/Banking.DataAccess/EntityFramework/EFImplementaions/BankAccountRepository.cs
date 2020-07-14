using Banking.DataAccess.Interfaces;
using Banking.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.DataAccess.EntityFramework.EFImplementaions
{
    public class BankAccountRepository : IRepository<BankAccount>
    {
        public bool Add(BankAccount entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(BankAccount entity)
        {
            throw new NotImplementedException();
        }

        public bool Edit(BankAccount entity)
        {
            throw new NotImplementedException();
        }

        public BankAccount Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IList<BankAccount> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
