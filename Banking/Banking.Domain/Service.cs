using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.Domain
{
    public class Service : Entity
    {
        public Guid ServiceProviderId { get; set; }
        public ServiceProvider ServiceProvider { get; set; }
        public Guid BankCardId { get; set; }
        public BankCard BankCard { get; set; }
        public decimal Amount { get; set; }
    }
}
