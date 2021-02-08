using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace EMERIOSChallenge.Program
{
    /// <summary>
    /// Worker service
    /// </summary>
    public class Worker : BackgroundService
    {
        private readonly IMainProgram _mainProgram;

        public Worker(IMainProgram mainProgram)
        {
            this._mainProgram = mainProgram;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            this._mainProgram.Execute();
        }
    }
}
