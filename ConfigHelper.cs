using Microsoft.Extensions.Configuration;

namespace StoreKeeper.WinForms
{
    public static class ConfigHelper
    {
        private static IConfigurationRoot _configuration;

        static ConfigHelper()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            _configuration = builder.Build();
        }

        public static string GetConnectionString(string name = "DefaultConnection")
        {
            return _configuration.GetConnectionString(name);
        }
    }
}