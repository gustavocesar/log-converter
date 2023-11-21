using LogConverter.Domain.Interfaces;
using LogConverter.Infrastructure.Services;
using LogConverter.UseCases;
using LogConverter.UseCases.Interfaces;
using LogConverter.Workers;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<ConvertFormatWorker>();

        services.AddTransient<IDownloadFileService, DownloadFileService>();
        services.AddTransient<IConvertMinhaCdnToAgoraUseCase, ConvertMinhaCdnToAgoraUseCase>();
    })
    .Build();

await host.RunAsync();
