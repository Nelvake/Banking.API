using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.DTOs
{
    public class CardOperationDTO
    {
        public Guid CardId { get; set; }
        public string NumberCardForTransfer { get; set; }
        public decimal Amount { get; set; }
    }
}
