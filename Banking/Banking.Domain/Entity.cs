using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;

namespace Banking.Domain
{
    public abstract class Entity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime? CreationDate { get; set; } = DateTime.Now;
    }
}
