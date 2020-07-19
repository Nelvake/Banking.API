using Banking.Domain;
using Banking.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.Services.Interfaces
{
    public interface IProviderService
    {
        ProviderDTO CreateProvider(ProviderDTO providerDTO);

        bool CreateProviderService(ProviderServiceDTO providerServiceDTO);

        bool PayForService(PayServiceDTO payServiceDTO);
    }
}
