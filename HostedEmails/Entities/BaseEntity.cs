using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HostedEmails.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}
