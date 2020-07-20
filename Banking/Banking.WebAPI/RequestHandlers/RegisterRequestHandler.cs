using Banking.Services.Interfaces;
using Banking.WebAPI.Requests;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Banking.WebAPI.RequestHandlers
{
    public class RegisterRequestHandler : IRequestHandler<RegisterRequest, string>
    {
        private readonly IAuthManager _authManager;
        private readonly ITokenService _tokenService;
        private readonly ILogger<RegisterRequestHandler> _logger;

        public RegisterRequestHandler(IAuthManager authManager, ITokenService tokenService, ILogger<RegisterRequestHandler> logger)
        {
            _authManager = authManager;
            _tokenService = tokenService;
            _logger = logger;
        }

        public Task<string> Handle(RegisterRequest request, CancellationToken cancellationToken)
        {
            var claimsIdentity = _authManager.SignUp(request.Email.ToLower(), request.Password);

            if (claimsIdentity == null)
            {
                _logger.LogWarning(HttpStatusCode.BadRequest.ToString());
                return Task.FromResult(HttpStatusCode.BadRequest.ToString());
            }

            return Task.FromResult(_tokenService.CreateAuthToken(claimsIdentity));
        }
    }
}
