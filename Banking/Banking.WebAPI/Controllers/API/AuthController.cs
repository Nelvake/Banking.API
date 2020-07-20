using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Banking.DTOs;
using Banking.Services.Interfaces;
using Banking.WebAPI.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Banking.WebAPI.Controllers.API
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IMediator mediator, ILogger<AuthController> logger)
        {
            _mediator = mediator;
            _logger = logger;
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

            var request = new AuthorizeRequest(authDto);
            var response = _mediator.Send(request).Result;

            return Ok(new { response });
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

            var request = new RegisterRequest(authDto);
            var response = _mediator.Send(request).Result;

            return Ok(new { response });
        }
    }
}
