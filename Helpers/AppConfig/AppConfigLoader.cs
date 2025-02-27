using MyApi.Helpers.File;
using SystemFile = System.IO.File;
using Newtonsoft.Json;

namespace MyApi.Helpers.AppConfig
{
    //Helper class with app settings configuration get methods.
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
            var json = SystemFile.ReadAllText(appsettingsFilePath);
            var config = JsonConvert.DeserializeObject<AppConfig>(json);

            return config;
        }
    }
}