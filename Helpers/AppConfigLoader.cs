using Newtonsoft.Json;

namespace MyApi.Helpers
{
    public class AppConfigLoader
    {
        public static FileUrlSettings LoadFileUrls()
        {            
            return GetConfig().FileUrls;
        }

        public static FileSettings LoadFileSettings()
        {
            return GetConfig().FileSettings;
        }

        private static AppConfig GetConfig()
        {
            var appsettingsFilePath = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            var json = File.ReadAllText(appsettingsFilePath);
            var config = JsonConvert.DeserializeObject<AppConfig>(json);

            return config;
        }
    }    
}