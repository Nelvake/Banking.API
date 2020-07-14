using Banking.DataAccess.Interfaces;
using Banking.Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using static BCrypt.Net.BCrypt;

namespace Banking.Services
{
    public class AuthManager
    {
        private readonly IUnitOfWork _context;
        private readonly ILogger<AuthManager> _logger;

        public AuthManager(IUnitOfWork context, ILogger<AuthManager> logger)
        {
            _context = context;
            _logger = logger;
        }

        private List<Claim> CreateClaims(string email, Guid id)
        {
            return new List<Claim>
            {
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Sid, id.ToString()),
            };
        }

        public ClaimsIdentity SignUp(string email, string password)
        {
            var existingUser = _context.Users.GetAll().Where(x => x.Email == email);
            if (existingUser != null) return null;

            var newUser = new User
            {
                Email = email,
                Password = HashPassword(password),
            };

            _context.Users.Add(newUser);
            _context.Save();

            return new ClaimsIdentity(CreateClaims(email, newUser.Id),
                JwtBearerDefaults.AuthenticationScheme);
        }

        public ClaimsIdentity SignIn(User user)
        {
            if (user.IsBlocked) return null;

            return new ClaimsIdentity(CreateClaims(user.Email.ToLower(), user.Id),
                JwtBearerDefaults.AuthenticationScheme);
        }


        public User Authenticate(string email, string password)
        {
            var user = _context.Users.GetAll().SingleOrDefault(x => x.Email.ToLower() == email);

            return user == null || user.Password == null || !Verify(password, user.Password) ? null : user;
        }

    }
}
