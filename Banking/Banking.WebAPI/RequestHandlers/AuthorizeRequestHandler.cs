using Banking.DTOs;
using Banking.Services.Interfaces;
using Banking.WebAPI.Requests;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Banking.WebAPI.RequestHandlers
{
    public class AuthorizeRequestHandler : IRequestHandler<AuthorizeRequest, string>
    {
        private readonly IAuthManager _authManager;
        private readonly ITokenService _tokenService;
        private readonly ILogger<AuthorizeRequestHandler> _logger;

        public AuthorizeRequestHandler(IAuthManager authManager, ITokenService tokenService, ILogger<AuthorizeRequestHandler> logger)
        {
            _authManager = authManager;
            _tokenService = tokenService;
            _logger = logger;
        }

        public Task<string> Handle(AuthorizeRequest request, CancellationToken cancellationToken)
        {
            var user = _authManager.Authenticate(request.Email.ToLower(), request.Password);

            var claimsIdentity = _authManager.SignIn(user);

            if (claimsIdentity == null)
            {
                _logger.LogWarning(HttpStatusCode.NotFound.ToString());
                return Task.FromResult(HttpStatusCode.NotFound.ToString());
            }

            return Task.FromResult(_tokenService.CreateAuthToken(claimsIdentity));
        }
    }
}
