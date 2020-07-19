using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.DTOs
{
    public class PayServiceDTO
    {
        public Guid ServiceId { get; set; }
        public Guid CardId { get; set; }
    }
}
