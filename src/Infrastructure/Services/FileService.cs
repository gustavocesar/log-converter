using LogConverter.Domain.Interfaces;

namespace LogConverter.Infrastructure.Services;

public class FileService : IFileService
{
    public async Task<IEnumerable<string>> DownloadFileContents(string url)
    {
        using var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        var response = await client.SendAsync(request);
        var content = await response.Content.ReadAsStringAsync();

        return RemoveEmptyLines(content);
    }

    public void CreatePathIfNotExists(string path)
    {
        var directory = Path.GetDirectoryName(path);

        if (!Directory.Exists(directory))
            Directory.CreateDirectory(directory!);
    }

    private IEnumerable<string> RemoveEmptyLines(string content)
    {
        return content.Split(Environment.NewLine)
            .Where(line => !string.IsNullOrWhiteSpace(line));
    }
}
