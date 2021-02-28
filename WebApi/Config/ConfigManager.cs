using Lib.Utils;

namespace WebApi.Config
{
    internal class ConfigManager
    {
        private static WebApiConfig _config;
        
        public static WebApiConfig Get()
        {
            if (_config == null)
            {
                _config = ConfigUtils.LoadConfig<WebApiConfig>(typeof(Program));
            }

            return _config;
        }
    }
}