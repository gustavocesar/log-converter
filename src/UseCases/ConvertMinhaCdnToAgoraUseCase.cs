using LogConverter.Domain.Entities;
using LogConverter.Domain.Interfaces;
using LogConverter.UseCases.Interfaces;

namespace LogConverter.UseCases;

public class ConvertMinhaCdnToAgoraUseCase : IConvertMinhaCdnToAgoraUseCase
{
    private readonly IFileService _fileService;

    public ConvertMinhaCdnToAgoraUseCase(IFileService fileService)
    {
        _fileService = fileService;
    }

    public async Task ExecuteAsync(string sourceUrl, string destinationPath)
    {
        var minhaCdnLines = await _fileService.DownloadFileContents(sourceUrl);

        var listMinhaCdn = minhaCdnLines.Select(line => (MinhaCdn)line);
        var listAgora = listMinhaCdn.Select(log => (Agora)log);

        await CreateLogFileAgoraFormat(listAgora, destinationPath);
    }

    private async Task CreateLogFileAgoraFormat(IEnumerable<Agora> logAgoras, string destinationPath)
    {
        //header
        var output = new List<string>
        {
            "#Version: 1.0",
            "#Date: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
            "#Fields: provider http-method status-code uri-path time-taken response-size cache-status"
        };

        //body
        output.AddRange(logAgoras.Select(log => log.ToString()));

        _fileService.CreatePathIfNotExists(destinationPath);

        await File.WriteAllLinesAsync(destinationPath, output);
    }
}
