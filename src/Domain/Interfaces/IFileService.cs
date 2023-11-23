namespace LogConverter.Domain.Interfaces;

public interface IFileService
{
    Task<IEnumerable<string>> DownloadFileContents(string url);
    void CreatePathIfNotExists(string path);
}
