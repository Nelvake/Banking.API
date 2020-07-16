using Banking.Domain;
using Banking.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.Services.Interfaces
{
    public interface ICardService
    {
        CardDTO CreateCard(Guid id, string cardHolder);
        ICollection<CardDTO> GetCardsUser(Guid id);
        CardDTO GetCardById(Guid id);
    }
}
