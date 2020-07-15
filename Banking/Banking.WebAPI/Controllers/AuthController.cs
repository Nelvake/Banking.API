using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Banking.DTOs;
using Banking.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Banking.WebAPI.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthManager _authManager;
        private readonly ITokenService _tokenService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthManager authManager, ILogger<AuthController> logger, ITokenService tokenService)
        {
            _authManager = authManager;
            _logger = logger;
            _tokenService = tokenService;
        }

        [AllowAnonymous]
        [HttpPost("SignIn")]
        public IActionResult Authorize(AuthDTO authDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning(HttpStatusCode.BadRequest.ToString());
                return BadRequest(HttpStatusCode.BadRequest);
            }

            var user = _authManager.Authenticate(authDto.Email.ToLower(), authDto.Password);

            if (user == null)
            {
                _logger.LogWarning(HttpStatusCode.NotFound.ToString());
                return NotFound(HttpStatusCode.NotFound);
            }

            var claimsIdentity = _authManager.SignIn(user);

            if (claimsIdentity == null)
            {
                _logger.LogWarning(HttpStatusCode.NotFound.ToString());
                return Unauthorized(HttpStatusCode.NotFound);
            }

            var token = _tokenService.CreateAuthToken(claimsIdentity);

            return Ok(new { token });
        }

        [AllowAnonymous]
        [HttpPost("SignUp")]
        public IActionResult SignUp(AuthDTO authDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning(HttpStatusCode.BadRequest.ToString());
                return BadRequest(HttpStatusCode.BadRequest);
            }

            var claimsIdentity = _authManager.SignUp(authDto.Email.ToLower(), authDto.Password);

            if (claimsIdentity == null)
            {
                _logger.LogWarning(HttpStatusCode.BadRequest.ToString());
                return BadRequest(HttpStatusCode.BadRequest);
            }

            return Ok();
        }
    }
}
