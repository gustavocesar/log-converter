namespace LogConverter.Entities;

public abstract class EntityBase
{
    public int ResponseSize { get; set; }
    public int StatusCode { get; set; }
    public string CacheStatus { get; set; } = string.Empty;
    public string HttpMethod { get; set; } = string.Empty;
    public string UriPath { get; set; } = string.Empty;
}
