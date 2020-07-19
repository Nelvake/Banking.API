using Banking.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.DTOs
{
    public class ProviderDTO
    {
        public string ServiceName { get; set; }
        public ServiceType ServiceType { get; set; }
    }
}
