namespace LogConverter.Domain.Entities;

public class MinhaCdn : EntityBase
{
    public float TimeTaken { get; set; }

    public static implicit operator MinhaCdn(string line)
    {
        var arr = line.Split('|');

        var request = arr[3].Replace("\"", "");
        var arrRequest = request.Split(" ");

        var logCdn = new MinhaCdn
        {
            ResponseSize = int.Parse(arr[0]),
            StatusCode = int.Parse(arr[1]),
            CacheStatus = arr[2],
            HttpMethod = arrRequest[0],
            UriPath = arrRequest[1],
            TimeTaken = float.Parse(arr[4]) / 10
        };

        return logCdn;
    }

    public static implicit operator Agora(MinhaCdn logCdn)
    {
        var agora = new Agora
        {
            ResponseSize = logCdn.ResponseSize,
            StatusCode = logCdn.StatusCode,
            CacheStatus = logCdn.CacheStatus.Replace("INVALIDATE", "REFRESH_HIT"),
            HttpMethod = logCdn.HttpMethod,
            UriPath = logCdn.UriPath,
            TimeTaken = (int)Math.Round(logCdn.TimeTaken)
        };

        return agora;
    }
}
