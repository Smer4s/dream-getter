namespace DreamGetter.Shared.Utils;

public static class EnvFetcher
{
    public static string? GetEnvVariable(string key) 
        => Environment.GetEnvironmentVariable(key);
}
