using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Banking.DTOs;
using Banking.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Banking.WebAPI.Controllers.Admin
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/admin/[controller]")]
    [ApiController]
    public class ProviderController : ControllerWithUser
    {
        private readonly IProviderService _providerService;
        private readonly ILogger<ProviderController> _logger;

        public ProviderController(ILogger<ProviderController> logger, IProviderService providerService)
        {
            _logger = logger;
            _providerService = providerService;
        }

        [HttpPost("provider")]
        public IActionResult CreateProvider(ProviderDTO providerDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning(HttpStatusCode.BadRequest.ToString());
                return BadRequest(HttpStatusCode.BadRequest);
            }

            var provider = _providerService.CreateProvider(providerDTO);

            if (provider == null)
            {
                _logger.LogWarning(HttpStatusCode.BadRequest.ToString());
                return BadRequest(HttpStatusCode.BadRequest);
            }

            return Ok(provider);
        }

        [HttpPost("providerservice")]
        public IActionResult CreateProviderService(ProviderServiceDTO providerServiceDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning(HttpStatusCode.BadRequest.ToString());
                return BadRequest(HttpStatusCode.BadRequest);
            }

            var providerService = _providerService.CreateProviderService(providerServiceDTO);

            if (providerService == null)
            {
                _logger.LogWarning(HttpStatusCode.BadRequest.ToString());
                return BadRequest(HttpStatusCode.BadRequest);
            }

            return Ok(providerService);
        }
    }
}
