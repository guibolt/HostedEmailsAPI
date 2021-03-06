using HostedEmails.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HostedEmails.Repositorio
{
    public class Repositorio : IRepositorio
    {
        private readonly IList<EmailAssinatura> _emailAssinaturas;
        private readonly IList<Usuario> _usuarios;

        public Repositorio()
        {
            _emailAssinaturas = new List<EmailAssinatura>();
            _usuarios = new List<Usuario>();
        }

        public void CadastrarEmail(EmailAssinatura emailAssinatura) => _emailAssinaturas.Add(emailAssinatura);

        public void CadastrarUsuario(Usuario usuario)   => _usuarios.Add(usuario);

        public List<EmailAssinatura> ListarEmails() => _emailAssinaturas.ToList();

        public List<Usuario> ListarUsuarios() => _usuarios.ToList();
   
    }
}
