using LogConverter.UseCases.Interfaces;

namespace LogConverter.Workers;

public class ConvertFormatWorker : BackgroundService
{
    private readonly ILogger<ConvertFormatWorker> _logger;
    private readonly IHostApplicationLifetime _hostApplicationLifetime;
    private readonly IConvertMinhaCdnToAgoraUseCase _useCase;
    private readonly IList<string> _arg;

    public ConvertFormatWorker(ILogger<ConvertFormatWorker> logger,
        IHostApplicationLifetime hostApplicationLifetime,
        IConvertMinhaCdnToAgoraUseCase useCase,
        IList<string> arg
    )
    {
        _logger = logger;
        _hostApplicationLifetime = hostApplicationLifetime;
        _useCase = useCase;
        _arg = arg;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            if (!_arg.Any() || _arg.Count < 2)
                throw new Exception("Please provide URL (sourceUrl) and a destination file (targetPath) as arguments.");

            var sourceUrl = _arg.FirstOrDefault() ?? string.Empty;
            var targetPath = _arg.LastOrDefault() ?? string.Empty;

            //TODO
        }
        catch (Exception e)
        {
            _logger.LogError($"Exception: {e.Message} | {e.StackTrace}");
        }
        finally
        {
            _hostApplicationLifetime.StopApplication();
        }

        await Task.CompletedTask;
    }
}