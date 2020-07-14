using System;
using System.ComponentModel;

namespace Banking.Domain
{
    public class BankCard : Entity
    {
        public string CardNumber { get; set; }
        public DateTime ValidDate { get; set; }
        public string CardHolder { get; set; }
        public int CVC { get; set; }
        public decimal Amount { get; set; }
        public BankAccount BankAccount { get; set; }
    }
}