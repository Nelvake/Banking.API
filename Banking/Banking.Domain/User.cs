using System;

namespace Banking.Domain
{
    public class User : Entity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsBlocked { get; set; }
        public DateTime? BlockDate { get; set; }
    }
}