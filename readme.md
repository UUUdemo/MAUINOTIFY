# MauiNotify

MauiNotify 是一個使用 [.NET MAUI](https://learn.microsoft.com/dotnet/maui/) 開發的跨平台應用程式。根據專案結構，此專案包含針對通知（Notification）功能的實作。

## 🌟 功能特色

* 跨平台支援 (Android, iOS, Mac Catalyst, Windows)
* 本機通知服務整合 (`Services/NotificationService.cs`)
* 基於 .NET 10.0 開發

## 🚀 開發環境需求

在開始之前，請確保您的開發環境符合以下需求：

* [.NET 10.0 SDK](https://dotnet.microsoft.com/download)
* [Visual Studio 2026](https://visualstudio.microsoft.com/) (需安裝 .NET MAUI 開發工作負載) 

## 📁 專案結構

* `MauiNotify/` - 主要的 MAUI 專案原始碼
  * `MainPage.xaml` - 應用程式首頁 UI
  * `Services/NotificationService.cs` - 通知服務實作邏輯
  * `Platforms/` - 各平台專屬的程式碼與設定 (Android, iOS, Windows, MacCatalyst)
  * `Resources/` - 應用程式資源 (圖片、圖示、字型、樣式與啟動畫面)


## 🛠️ 如何建置與執行

### 使用 Visual Studio / VS Code
1. 打開根目錄的 `MauiNotify.sln` 或直接開啟資料夾。
2. 選擇您想要測試的目標平台（例如：Windows Machine, Android Emulator 等）。
3. 按下 `F5` 開始偵錯並執行應用程式。

## 📄 授權條款

此專案採用 [MIT License](LICENSE) 授權。

