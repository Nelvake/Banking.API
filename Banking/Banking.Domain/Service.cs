using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.Domain
{
    public class Service : Entity
    {
        public ServiceProvider ServiceProvider { get; set; }
        public BankCard BankCard { get; set; }
        public decimal Amount { get; set; }
    }
}
