using LogConverter.UseCases.Interfaces;

namespace LogConverter.Workers;

public class ConvertFormatWorker : BackgroundService
{
    private readonly ILogger<ConvertFormatWorker> _logger;
    private readonly IHostApplicationLifetime _hostApplicationLifetime;
    private readonly IConvertMinhaCdnToAgoraUseCase _minhaCdnToAgoraUseCase;
    private readonly IList<string> _arguments;

    public ConvertFormatWorker(ILogger<ConvertFormatWorker> logger,
        IHostApplicationLifetime hostApplicationLifetime,
        IConvertMinhaCdnToAgoraUseCase minhaCdnToAgoraUseCase,
        IList<string> arguments
    )
    {
        _logger = logger;
        _hostApplicationLifetime = hostApplicationLifetime;
        _minhaCdnToAgoraUseCase = minhaCdnToAgoraUseCase;
        _arguments = arguments;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            ThrowIfInvalidArguments();

            var sourceUrl = _arguments.FirstOrDefault(string.Empty);
            var targetPath = _arguments.LastOrDefault(string.Empty);

            await _minhaCdnToAgoraUseCase.ExecuteAsync(sourceUrl, targetPath);
        }
        catch (Exception e)
        {
            _logger.LogError($"Exception: {e.Message} | {e.StackTrace}");
        }
        finally
        {
            _hostApplicationLifetime.StopApplication();
        }
    }

    private void ThrowIfInvalidArguments()
    {
        if (_arguments.Count is not 2)
            throw new Exception("Invalid arguments.");
    }
}