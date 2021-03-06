using HostedEmails.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HostedEmails.Repositorio
{
    public interface IRepositorio
    {
        void CadastrarUsuario(Usuario usuario);
        List<Usuario> ListarUsuarios();
        void CadastrarEmail(EmailAssinatura emailAssinatura);
        List<EmailAssinatura> ListarEmails();

    }
}
