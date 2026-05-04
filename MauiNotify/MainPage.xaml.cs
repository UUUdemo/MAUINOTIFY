namespace MauiNotify;

public partial class MainPage : ContentPage
{

    readonly Services.NotificationService _notificationService;

    public MainPage(Services.NotificationService notificationService)
    {
        InitializeComponent();
        //_notificationService = IPlatformApplication.Current!.Services.GetService<Services.NotificationService>()!;
        _notificationService = notificationService;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        // Request notification permission when the page appears for the first time.
        var granted = await _notificationService.RequestPermissionAsync();
        if (!granted)
            await DisplayAlertAsync("通知權限", "請開啟通知權限以接收本地通知。", "確定");
    }


    private void OnNotifyClicked(object? sender, EventArgs e)
    {
        // Safe notification: no sensitive data in Title/Description.
        _notificationService.ShowNotification(
            title: "Hello from MAUI",
            description: "這是一則本地通知範例，不包含任何敏感資料。");
    }
}
