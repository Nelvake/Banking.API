using Banking.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.DTOs
{
    public class ProviderDTO
    {
        public Guid Id { get; set; }
        public string ServiceName { get; set; }
        public ServiceType ServiceType { get; set; }
    }
}
