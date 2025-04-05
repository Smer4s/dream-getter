namespace EventService.Domain.Shared;

public static class EnvFetcher
{
    public static string? GetEnvVariable(string key) => Environment.GetEnvironmentVariable(key);
}
