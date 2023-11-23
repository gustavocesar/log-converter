using LogConverter.Domain.Interfaces;
using LogConverter.Infrastructure.Services;
using LogConverter.UseCases;
using LogConverter.UseCases.Interfaces;
using LogConverter.Workers;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        var listArgs = new List<string>(args);

        services.AddHostedService(serviceProvider =>
            new ConvertFormatWorker(
                serviceProvider.GetService<ILogger<ConvertFormatWorker>>()!,
                serviceProvider.GetService<IHostApplicationLifetime>()!,
                serviceProvider.GetService<IConvertMinhaCdnToAgoraUseCase>()!,
                listArgs
            )
        );

        services.AddTransient<IDownloadFileService, DownloadFileService>();
        services.AddTransient<IConvertMinhaCdnToAgoraUseCase, ConvertMinhaCdnToAgoraUseCase>();
    })
    .Build();

await host.RunAsync();
