﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Banking.DTOs;
using Banking.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Banking.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderOperationController : ControllerWithUser
    {
        private readonly IProviderService _providerService;
        private readonly ILogger<ProviderOperationController> _logger;

        public ProviderOperationController(ILogger<ProviderOperationController> logger, IProviderService providerService)
        {
            _logger = logger;
            _providerService = providerService;
        }

        [HttpPost]
        public IActionResult PayForService(PayServiceDTO payServiceDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning(HttpStatusCode.BadRequest.ToString());
                return BadRequest(HttpStatusCode.BadRequest);
            }

            var result = _providerService.PayForService(payServiceDTO);

            if (!result)
            {
                _logger.LogWarning(HttpStatusCode.BadRequest.ToString());
                return BadRequest(HttpStatusCode.BadRequest);
            }

            return Ok();
        }
    }
}
