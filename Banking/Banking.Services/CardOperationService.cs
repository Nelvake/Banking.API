using Banking.DataAccess.Interfaces;
using Banking.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banking.Services
{
    public class CardOperationService : ICardOperationService
    {
        private readonly IUnitOfWork _context;
        private readonly ILogger<CardService> _logger;

        public CardOperationService(IUnitOfWork context, ILogger<CardService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public bool TopUpBalance(decimal amount, Guid cardId)
        {
            try
            {
                var card = _context.BankCards.Get(cardId);

                if (card == null) return false;

                card.Amount += amount;
                _context.BankCards.Edit(card);

                _context.Save();

                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        public bool TransferToCard(decimal amount, Guid cardId, string numberCardForTransfer)
        {
            try
            {
                _context.BeginTransaction();

                var myCard = _context.BankCards.Get(cardId);
                var cardForTransfer = _context.BankCards.GetAll().FirstOrDefault(x => x.CardNumber == numberCardForTransfer);

                if (myCard == null || cardForTransfer == null) return false;

                if (myCard.Amount < amount) return false;
                myCard.Amount -= amount;
                cardForTransfer.Amount += amount;

                _context.BankCards.Edit(myCard);
                _context.BankCards.Edit(cardForTransfer);

                _context.Save();
                _context.Commit();

                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                _context.Rollback();
                throw;
            }
            
        }

        public bool Withdraw(decimal amount, Guid cardId)
        {
            try
            {
                var card = _context.BankCards.Get(cardId);

                if (card == null || card.Amount < amount) return false;

                card.Amount -= amount;
                _context.BankCards.Edit(card);

                _context.Save();

                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }
    }
}
