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

namespace Banking.WebAPI.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class CardOperationController : ControllerWithUser
    {
        private readonly ICardOperationService _cardOperation;
        private readonly ILogger<CardOperationController> _logger;

        public CardOperationController(ILogger<CardOperationController> logger, ICardOperationService cardOperation)
        {
            _logger = logger;
            _cardOperation = cardOperation;
        }

        [HttpPost("transfer")]
        public IActionResult TransferToCard(CardOperationDTO cardOperationDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning(HttpStatusCode.BadRequest.ToString());
                return BadRequest(HttpStatusCode.BadRequest);
            }

            var result = _cardOperation.TransferToCard(cardOperationDTO.Amount, cardOperationDTO.CardId, cardOperationDTO.NumberCardForTransfer);

            if(!result)
            {
                _logger.LogWarning(HttpStatusCode.BadRequest.ToString());
                return BadRequest(HttpStatusCode.BadRequest);
            }

            return Ok();
        }

        [HttpPost("withdraw")]
        public IActionResult Withdraw(CardOperationDTO cardOperationDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning(HttpStatusCode.BadRequest.ToString());
                return BadRequest(HttpStatusCode.BadRequest);
            }

            var result = _cardOperation.Withdraw(cardOperationDTO.Amount, cardOperationDTO.CardId);

            if (!result)
            {
                _logger.LogWarning(HttpStatusCode.BadRequest.ToString());
                return BadRequest(HttpStatusCode.BadRequest);
            }

            return Ok();
        }

        [HttpPost("topupbalance")]
        public IActionResult TopUpBalance(CardOperationDTO cardOperationDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning(HttpStatusCode.BadRequest.ToString());
                return BadRequest(HttpStatusCode.BadRequest);
            }

            var result = _cardOperation.TopUpBalance(cardOperationDTO.Amount, cardOperationDTO.CardId);

            if (!result)
            {
                _logger.LogWarning(HttpStatusCode.BadRequest.ToString());
                return BadRequest(HttpStatusCode.BadRequest);
            }

            return Ok();
        }
    }
}
