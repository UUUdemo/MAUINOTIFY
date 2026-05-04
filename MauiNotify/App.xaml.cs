namespace MauiNotify;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        var window = new Window(new AppShell());

        window.Destroying += (s, e) =>
        {
            // 取消訂閱通知事件，防止 Windows 關閉時觸發 Win32 例外
            var svc = IPlatformApplication.Current?.Services
                          .GetService<Services.NotificationService>();
            svc?.Dispose();
        };

        return window;
    }
}