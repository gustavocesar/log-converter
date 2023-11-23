namespace LogConverter.UseCases.Interfaces;

public interface IConvertMinhaCdnToAgoraUseCase
{
    Task ExecuteAsync(string sourceUrl, string destinationPath);
}
