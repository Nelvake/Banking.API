using Banking.DataAccess.Interfaces;
using Banking.Domain;
using Banking.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banking.Services
{
    public class CardService : ICardService
    {
        private readonly IUnitOfWork _context;
        private readonly ILogger<CardService> _logger;
        private readonly IHelperService _helperService;

        public CardService(IUnitOfWork context, ILogger<CardService> logger, IHelperService helperService)
        {
            _context = context;
            _logger = logger;
            _helperService = helperService;
        }

        public BankCard CreateCard(Guid id, string cardHolder)
        {
            try
            {
                _context.BeginTransaction();

                var userBankAccount = _context.BankAccounts.Get(id);

                var newBankCard = new BankCard
                {
                    CardHolder = cardHolder,
                    Amount = 0,
                    BankAccountId = userBankAccount.Id,
                    CardNumber = _helperService.GenerateCardNumber(),
                    CVC = _helperService.GenerateCVC()
                };

                _context.BankCards.Add(newBankCard);
                _context.BankAccounts.Edit(userBankAccount);
                _context.Save();

                _context.Commit();

                return newBankCard;
            }
            catch (Exception e)
            {
                _context.Rollback();
                _logger.LogError(e.Message);
                throw;
            }
        }

        public ICollection<BankCard> GetCardsUser(Guid id)
        {
            try
            {
               return _context.BankCards.GetAll().Where(x => x.BankAccount.User.Id == id).ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }
    }
}
