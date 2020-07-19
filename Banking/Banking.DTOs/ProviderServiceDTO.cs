using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.DTOs
{
    public class ProviderServiceDTO
    {
        public Guid Id { get; set; }
        public Guid ServiceProviderId { get; set; }
        public Guid BankCardId { get; set; }
        public decimal Amount { get; set; }
    }
}
