namespace LogConverter.Domain.Interfaces;

public interface IDownloadFileService
{
    Task<string> GetFileContents(string url);
}
