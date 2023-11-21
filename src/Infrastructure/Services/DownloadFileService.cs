using LogConverter.Domain.Interfaces;

namespace LogConverter.Infrastructure.Services;

public class DownloadFileService : IDownloadFileService
{
    public async Task<string> GetFileContents(string url)
    {
        using var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        var response = await client.SendAsync(request);

        return await response.Content.ReadAsStringAsync();
    }
}
