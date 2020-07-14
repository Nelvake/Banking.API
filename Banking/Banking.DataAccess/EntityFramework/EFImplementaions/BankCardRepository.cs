using Banking.DataAccess.Interfaces;
using Banking.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.DataAccess.EntityFramework.EFImplementaions
{
    public class BankCardRepository : IRepository<BankCard>
    {
        public bool Add(BankCard entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(BankCard entity)
        {
            throw new NotImplementedException();
        }

        public bool Edit(BankCard entity)
        {
            throw new NotImplementedException();
        }

        public BankCard Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IList<BankCard> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
