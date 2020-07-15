using Banking.Domain;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Banking.Services.Interfaces
{
    public interface IAuthManager
    {
        ClaimsIdentity SignUp(string email, string password);
        User Authenticate(string email, string password);
        ClaimsIdentity SignIn(User user);
    }
}
