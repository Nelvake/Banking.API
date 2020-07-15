using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Banking.Services.Interfaces
{
    public interface ITokenService
    {
        string CreateAuthToken(ClaimsIdentity claimsIdentity);
    }
}
