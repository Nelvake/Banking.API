using Banking.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Banking.WebAPI.Requests
{
    public class AuthorizeRequest : IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public AuthorizeRequest(AuthDTO authDTO)
        {
            Email = authDTO.Email;
            Password = authDTO.Password;
        }
    }
}
