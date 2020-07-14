using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.Domain.Options
{
    public class AppSettingsOptions
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
