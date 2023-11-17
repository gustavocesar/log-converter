using LogConverter;
using LogConverter.Domain.Interfaces;
using LogConverter.Infrastructure.Services;
using LogConverter.UseCases;
using LogConverter.UseCases.Interfaces;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();

        services.AddScoped<IDownloadFileService, DownloadFileService>();
        services.AddScoped<IConvertMinhaCdnToAgoraUseCase, ConvertMinhaCdnToAgoraUseCase>();
    })
    .Build();

await host.RunAsync();
