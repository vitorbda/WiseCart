using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiseCart.Domain.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public DateTimeOffset AddDate { get; set; } = DateTime.Now;
        public DateTimeOffset? AlterDate { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
