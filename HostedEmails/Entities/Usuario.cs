using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HostedEmails.Entities
{
    public class Usuario
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool ReceberEmails { get; set; }
    }
}
