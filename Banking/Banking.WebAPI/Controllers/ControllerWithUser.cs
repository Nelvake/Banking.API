using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Banking.WebAPI.Controllers
{
    public abstract class ControllerWithUser : ControllerBase
    {
        private IEnumerable<Claim> _userClaims;

        public IEnumerable<Claim> UserClaims
        {
            get => _userClaims ?? User.Claims;
            set => _userClaims = value;
        }

        protected Guid UserId
        {
            get
            {
                Guid.TryParse(UserClaims.FirstOrDefault(claim => claim.Type == ClaimTypes.Sid)?.Value,
                    out var userId);
                return userId;
            }
        }
    }
}
