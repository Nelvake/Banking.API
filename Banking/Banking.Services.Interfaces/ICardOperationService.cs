using Banking.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.Services.Interfaces
{
    public interface ICardOperationService
    {
        bool TopUpBalance(decimal amount, Guid cardId);
        bool Withdraw(decimal amount, Guid cardId);
        bool TransferToCard(decimal amount, Guid cardId, string numberCardForTransfer);
    }
}
