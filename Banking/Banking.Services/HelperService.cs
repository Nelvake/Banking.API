using Banking.Services.Interfaces;
using System;
using System.Text;

namespace Banking.Services
{
    public class HelperService : IHelperService
    {
        private readonly Random _random;
        private readonly StringBuilder _builder;

        public HelperService(Random random, StringBuilder builder)
        {
            _random = random;
            _builder = builder;
        }

        public string GenerateAccountNumber()
        {
            _builder.Append("KZ");

            for (int i = 0; i < 20; i++)
            {
                _builder.Append($"{_random.Next(10)}");
            }

            return _builder.ToString();
        }

        public string GenerateCardNumber()
        {
            for (int i = 0; i < 16; i++)
            {
                _builder.Append($"{_random.Next(10)}");
            }

            return _builder.ToString();
        }
    }
}
