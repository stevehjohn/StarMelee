using System;
using System.IO;
using Newtonsoft.Json;

namespace StarMelee.Infrastructure.Configuration
{
    public class AppSettings
    {
        private static readonly Lazy<AppSettings> Lazy = new Lazy<AppSettings>(GetAppSettings);

        public static AppSettings Instance => Lazy.Value;

        public string Resolution { get; set; }

        public bool Windowed { get; set; }

        public string PlayerName { get; set; }

        private AppSettings()
        {
        }

        private static AppSettings GetAppSettings()
        {
            var json = File.ReadAllText("app-settings.json");

            return JsonConvert.DeserializeObject<AppSettings>(json);
        }
    }
}