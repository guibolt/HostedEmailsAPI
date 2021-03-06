using HostedEmails.Entities;
using HostedEmails.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HostedEmails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailUsuarioController : ControllerBase
    {
        private IRepositorio _repositorio;

        public EmailUsuarioController(IRepositorio repositorio) => _repositorio = repositorio;
        
        [Route("cadastra/email")]
        [HttpPost]
        public IActionResult CadastraEmail([FromBody] EmailInputModel email)
        {
            var novoEmail = new EmailAssinatura(email.Assunto, email.Conteudo);
         
            _repositorio.CadastrarEmail(novoEmail);

            Debug.WriteLine("ehehhe");

            return Ok("Cadastrado com sucesso");
        }

        [Route("cadastra/usuario")]
        [HttpPost]
        public IActionResult CadastraUsuarios([FromBody] Usuario usuario)
        {
            _repositorio.CadastrarUsuario(usuario);

            return Ok("Cadastrado com sucesso");
        }

        [Route("lista/usuarios")]
        [HttpGet]
        public IActionResult ListaUsuarios()
        {
            var lstUsuarios = _repositorio.ListarUsuarios();
            return Ok(new
            {
                ListaDeUsuarios = lstUsuarios
            });
        }

        [Route("lista/emails")]
        [HttpGet]
        public IActionResult ListaEmails()
        {
            var lstEmails = _repositorio.ListarEmails();
            return Ok(new
            {
                ListaDeEmails = lstEmails
            });
        }



    }
}
