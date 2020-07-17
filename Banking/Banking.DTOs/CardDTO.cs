using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.DTOs
{
    public class CardDTO
    {
        public Guid Id { get; set; }
        public string CardNumber { get; set; }
        public DateTime ValidDate { get; set; }
        public string CardHolder { get; set; }
        public int CVC { get; set; }
        public decimal Amount { get; set; }
    }
}
