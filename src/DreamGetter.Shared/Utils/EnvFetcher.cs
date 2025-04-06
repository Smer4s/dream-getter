namespace DreamGetter.Shared.Utils;

public static class EnvFetcher
{
    public static string? GetEnvVariable(string key)
        => Environment.GetEnvironmentVariable(key);

    public static string GetRequiredEnvVariable(string key) =>
        GetEnvVariable(key) ?? throw new ArgumentNullException(nameof(key));

    public static T GetRequiredEnvVariable<T>(string key, Func<string, T> converter)
    {
        var variable = GetRequiredEnvVariable(key);

        return converter(variable);
    }
}
