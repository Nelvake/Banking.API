using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.Services.Interfaces
{
    public interface IHelperService
    {
        string GenerateAccountNumber();
        string GenerateCardNumber();
    }
}
