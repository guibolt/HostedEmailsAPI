using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HostedEmails.Entities
{
    public class EmailAssinatura
    {
        public string Assunto { get; private set; }
        public string Conteudo { get; private set; }
        public DateTime DataCriacao { get;  } = DateTime.Now;
        public bool EnviadoATodos { get; private set; }

        public EmailAssinatura(string assunto, string conteudo)
        {
            Assunto = assunto;
            Conteudo = conteudo;
        }

        public void ConfirmaEnvio() => EnviadoATodos = true;

    }
}
