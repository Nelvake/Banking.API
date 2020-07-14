using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Banking.Domain
{
    public class BankAccount : Entity
    {
        public string AccountNumber { get; set; }
        public User User { get; set; }
        public DateTime ValidPeriod { get; set; }
        public List<BankCard> BankCards { get; set; }
    }
}
