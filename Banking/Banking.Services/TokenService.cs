using Banking.Domain.Options;
using Banking.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Banking.Services
{
    public class TokenService : ITokenService
    {
        private readonly IOptions<AppSettingsOptions> _appOptions;
        private readonly ILogger<TokenService> _logger;

        public TokenService(IOptions<AppSettingsOptions> appOptions, ILogger<TokenService> logger)
        {
            _appOptions = appOptions;
            _logger = logger;
        }

        public string CreateAuthToken(ClaimsIdentity claimsIdentity)
        {
            try
            {
                var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appOptions.Value.Secret));
                var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    _appOptions.Value.Issuer,
                    _appOptions.Value.Audience,
                    notBefore: DateTime.Now,
                    claims: claimsIdentity.Claims,
                    expires: DateTime.Now.AddYears(50),
                    signingCredentials: signingCredentials);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }
    }
}
