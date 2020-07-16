using Banking.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.Services.Interfaces
{
    public interface ICardService
    {
        BankCard CreateCard(Guid id, string cardHolder);
        ICollection<BankCard> GetCardsUser(Guid id);
    }
}
