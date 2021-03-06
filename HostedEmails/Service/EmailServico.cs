using HostedEmails.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HostedEmails.Service
{
    public  static class EmailServico
    {
        public static void EnviarEmails(EmailAssinatura email, List<Usuario> destinatarios)
            => destinatarios.ForEach(usuario =>

                Debug.WriteLine($"Enviando email: {email.Conteudo} criado: {email.DataCriacao} para {usuario.Email}")
            );
    }
}
    