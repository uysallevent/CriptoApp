using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace CriptoApp.Helper
{
    public static class Settings
    {
        private static ISettings AppSettings => CrossSettings.Current;

        public static string PortfoyList
        {
            get => AppSettings.GetValueOrDefault(nameof(PortfoyList),string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(PortfoyList), value);
        }

        public static string LoginEmail
        {
            get => AppSettings.GetValueOrDefault(nameof(LoginEmail), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(LoginEmail), value);
        }

        public static int UserId
        {
            get => AppSettings.GetValueOrDefault(nameof(UserId), 0);
            set => AppSettings.AddOrUpdateValue(nameof(UserId), value);
        }
    }
}
