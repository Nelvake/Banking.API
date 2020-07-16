using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Banking.Domain
{
    public class BankAccount : Entity
    {
        public string AccountNumber { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public DateTime ValidPeriod { get; set; } = DateTime.Now.AddYears(5);
        public List<BankCard> BankCards { get; set; } = new List<BankCard>();
    }
}
