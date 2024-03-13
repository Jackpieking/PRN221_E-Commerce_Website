namespace PRN221_E_Commerce_Website.Options;

public sealed class DatabaseOption
{
    public string ConnectionString { get; set; }

    public int CommandTimeOut { get; set; }

    public int EnableRetryOnFailure { get; set; }

    public bool EnableSensitiveDataLogging { get; set; }

    public bool EnableDetailedErrors { get; set; }

    public bool EnableThreadSafetyChecks { get; set; }

    public bool EnableServiceProviderCaching { get; set; }
}
