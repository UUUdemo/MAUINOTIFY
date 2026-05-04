using Android.App;
using Android.Content.PM;
using Android.OS;
using System.Runtime.Versioning;

namespace MauiNotify
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            if (OperatingSystem.IsAndroidVersionAtLeast(26))
            {
                CreateNotificationChannel();
            }
        }

        [SupportedOSPlatform("android26.0")]
        private void CreateNotificationChannel()
        {
            var notificationManager = (NotificationManager?)GetSystemService(NotificationService);
            if (notificationManager == null)
                return;

            // IMPORTANCE_HIGH = 彈出 Heads-up 通知
            var channel = new NotificationChannel(
                id: "general",
                name: "一般通知",
                importance: NotificationImportance.High)
            {
                Description = "App 的一般通知"
            };

            // 啟用震動與聲音以觸發 Heads-up 彈出效果
            channel.EnableVibration(true);
            channel.EnableLights(true);

            notificationManager.CreateNotificationChannel(channel);
        }
    }
}
