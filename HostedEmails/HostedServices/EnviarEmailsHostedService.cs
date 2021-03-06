using HostedEmails.Repositorio;
using HostedEmails.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HostedEmails.HostedServices
{
    public class EnviarEmailsHostedService : IHostedService, IDisposable
    {
        public IServiceProvider ServiceProvider { get; set; }
        private IRepositorio _repositorio;

        private Timer _timer;

        public EnviarEmailsHostedService(IServiceProvider serviceProvider,  IRepositorio  repositorio)
        {
            ServiceProvider = serviceProvider;
            _repositorio = repositorio;

        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(EnviarEmails, null, 0, 100000);

            return Task.CompletedTask;
        }


        private void EnviarEmails(object state)
        {

            using (var scope = ServiceProvider.CreateScope())
            {
                var lstUsuarios = _repositorio.ListarUsuarios().Where(c => c.ReceberEmails).ToList(); 
                var lstEmails = _repositorio.ListarEmails().Where(c => c.EnviadoATodos == false).ToList();


                lstEmails.ForEach(e =>
                {
                   EmailServico.EnviarEmails(e, lstUsuarios);

                    e.ConfirmaEnvio();

                });
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }
        public void Dispose() => _timer.Dispose();
     

    }
}
