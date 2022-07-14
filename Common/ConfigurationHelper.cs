using Microsoft.Extensions.Configuration;

namespace Common;

public class ConfigurationHelper
{
    private static IConfigurationRoot config;
    public static void Init()
    {
        config = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();
    }

    public static string ConnectionString
    {
        get { return config["ConnectionString"]; }
    }
}