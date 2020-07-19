﻿using Banking.DataAccess.Interfaces;
using Banking.Domain;
using Banking.DTOs;
using Banking.Services.Interfaces;
using Mapster;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Banking.Services
{
    public class ProviderService : IProviderService
    {
        private readonly IUnitOfWork _context;
        private readonly ILogger<ProviderService> _logger;

        public ProviderService(ILogger<ProviderService> logger, IUnitOfWork context)
        {
            _logger = logger;
            _context = context;
        }

        public ProviderDTO CreateProvider(ProviderDTO providerDTO)
        {
            try
            {
                var provider = new Domain.ServiceProvider
                {
                    ServiceName = providerDTO.ServiceName,
                    ServiceType = providerDTO.ServiceType
                };

                _context.ServiceProviders.Add(provider);
                _context.Save();

                return provider.Adapt<ProviderDTO>();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        public ProviderServiceDTO CreateProviderService(ProviderServiceDTO providerServiceDTO)
        {
            try
            {
                if (providerServiceDTO.Amount <= 0) return null;

                var provider = _context.ServiceProviders.Get(providerServiceDTO.ServiceProviderId);
                var card = _context.BankCards.Get(providerServiceDTO.BankCardId);

                if (provider == null || card == null) return null;

                var service = new Service
                {
                    Amount = providerServiceDTO.Amount,
                    BankCardId = card.Id,
                    ServiceProviderId = provider.Id,
                };

                _context.Services.Add(service);
                _context.Save();

                return service.Adapt<ProviderServiceDTO>();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }

        }

        public ICollection<ProviderDTO> GetAllProviders()
        {
            try
            {
                return _context.ServiceProviders.GetAll().Adapt<List<ProviderDTO>>();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        public ICollection<ProviderServiceDTO> GetAllProviderServices(Guid providerId)
        {
            try
            {
                var services = _context.Services.GetAll().Where(x => x.ServiceProviderId == providerId).ToList();
                return services.Adapt<List<ProviderServiceDTO>>();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        public bool PayForService(PayServiceDTO payServiceDTO)
        {
            try
            {
                _context.BeginTransaction();
                var service = _context.Services.Get(payServiceDTO.ServiceId);
                var card = _context.BankCards.Get(payServiceDTO.CardId);

                if (service == null || card == null) return false;

                if (card.Amount < service.Amount) return false;

                card.Amount -= service.Amount;
                service.BankCard.Amount += service.Amount;

                _context.BankCards.Edit(card);
                _context.BankCards.Edit(service.BankCard);
                _context.Save();

                _context.Commit();

                return true;
            }
            catch (Exception e)
            {
                _context.Rollback();
                _logger.LogError(e.Message);
                throw;
            }
        }
    }
}
