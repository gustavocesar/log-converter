namespace LogConverter.Domain.Entities;

public class Agora : EntityBase
{
    public string Provider { get; set; } = "MINHA CDN";
    public int TimeTaken { get; set; }

    public override string ToString()
    {
        return $"\"{Provider}\" {HttpMethod} {StatusCode} {UriPath} {TimeTaken} {ResponseSize} {CacheStatus}";
    }
}
