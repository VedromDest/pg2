using FotoToestellen.Domein.Modellen;
using FotoToestellenApp.Services;
using Microsoft.Extensions.Hosting;

namespace FotoToestellenApp.CUI;

public partial class App(AppActies appActies, IHostApplicationLifetime lifetime) : IHostedService
{
    Task IHostedService.StartAsync(CancellationToken cancellationToken)
    {
        AppConsole.SchrijfLog("Starting FotoToestellenApp");
        return Task.Run(InterageerMetGebruiker, cancellationToken);
    }
    
    Task IHostedService.StopAsync(CancellationToken cancellationToken)
    {
        AppConsole.SchrijfLog("Stopping FotoToestellenApp");
        return Task.CompletedTask;
    }
}