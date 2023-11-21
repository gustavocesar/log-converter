using LogConverter.UseCases.Interfaces;

namespace LogConverter.Workers;

public class ConvertFormatWorker : BackgroundService
{
    private readonly ILogger<ConvertFormatWorker> _logger;
    private readonly IHostApplicationLifetime _hostApplicationLifetime;
    private readonly IConvertMinhaCdnToAgoraUseCase _useCase;

    public ConvertFormatWorker(ILogger<ConvertFormatWorker> logger,
        IHostApplicationLifetime hostApplicationLifetime,
        IConvertMinhaCdnToAgoraUseCase useCase
    )
    {
        _logger = logger;
        _hostApplicationLifetime = hostApplicationLifetime;
        _useCase = useCase;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {

        try
        {
            //todo
        }
        catch (Exception e)
        {
            _logger.LogError($"Exception: {e.Message} | {e.StackTrace}");
            throw;
        }
        finally
        {
            _hostApplicationLifetime.StopApplication();
        }

        await Task.CompletedTask;
    }
}