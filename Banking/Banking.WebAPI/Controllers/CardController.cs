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
    public class CardController : ControllerWithUser
    {
        private readonly ICardService _cardService;
        private readonly ILogger<CardController> _logger;

        public CardController(ICardService cardService, ILogger<CardController> logger)
        {
            _cardService = cardService;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult CreateCard(CardDTO cardDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning(HttpStatusCode.BadRequest.ToString());
                return BadRequest(HttpStatusCode.BadRequest);
            }

            var card = _cardService.CreateCard(UserId, cardDTO.CardHolder);

            if (card == null)
            {
                _logger.LogWarning(HttpStatusCode.BadRequest.ToString());
                return BadRequest(HttpStatusCode.BadRequest);
            }

            return Ok(card);
        }

        [HttpGet("{id}")]
        public IActionResult GetCardById(Guid id)
        {
            if(id == null)
            {
                _logger.LogWarning(HttpStatusCode.BadRequest.ToString());
                return BadRequest(HttpStatusCode.BadRequest);
            }

            var cards = _cardService.GetCardById(id);

            return Ok(cards);
        }

        [HttpGet]
        public IActionResult GetCardsUser()
        {
            var cards = _cardService.GetCardsUser(UserId);

            return Ok(cards);
        }
    }
}
