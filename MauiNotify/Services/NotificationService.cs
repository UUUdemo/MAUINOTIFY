using System;
using Plugin.LocalNotification;
using Plugin.LocalNotification.Core.Models;
using Plugin.LocalNotification.Core.Models.AndroidOption;
using Plugin.LocalNotification.EventArgs;

namespace MauiNotify.Services;

    // Wrapper around Plugin.LocalNotification.
    // Security notes:
    //  - Do NOT include sensitive data (tokens, PII) in Title/Description/ReturningData.
    //  - Always validate ReturningData on tap before navigating or executing actions.
    public class NotificationService : IDisposable
    {
        private bool _disposed;

        public NotificationService()
        {
            LocalNotificationCenter.Current.NotificationActionTapped += OnNotificationActionTapped;
        }

        /// <summary>
        /// Requests notification permission from the user (required on Android 13+ and iOS).
        /// Call this before showing any notification (e.g., on app start or before first use).
        /// </summary>
        public async Task<bool> RequestPermissionAsync()
        {
            return await LocalNotificationCenter.Current.RequestNotificationPermission();
        }

        /// <summary>
        /// Shows an immediate local notification. Do not pass sensitive data in title or description.
        /// </summary>
        public void ShowNotification(string title, string description, string returningData = "action=view")
        {
            if (string.IsNullOrWhiteSpace(title))
                title = "Notification";

            var request = new NotificationRequest
            {
                NotificationId = Random.Shared.Next(1, int.MaxValue),
                Title = title,
                Description = description,
                ReturningData = returningData,
                Android = new AndroidOptions
                {
                    ChannelId = "general"   // 對應 MainActivity 建立的 HIGH importance channel
                }
            };

            LocalNotificationCenter.Current.Show(request);
        }

        /// <summary>
        /// Schedules a notification to appear at a future time.
        /// </summary>
        public void ScheduleNotification(string title, string description, DateTime notifyAt)
        {
            var request = new NotificationRequest
            {
                NotificationId = Random.Shared.Next(1, int.MaxValue),
                Title = title,
                Description = description,
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = notifyAt
                }
            };

            LocalNotificationCenter.Current.Show(request);
        }

        private void OnNotificationActionTapped(NotificationActionEventArgs e)
        {
            try
            {
                var data = e.Request?.ReturningData;
                if (string.IsNullOrEmpty(data))
                    return;

                // Whitelist-based validation: only allow known action formats.
                if (data.StartsWith("action=", StringComparison.OrdinalIgnoreCase))
                {
                    var action = data["action=".Length..];
                    switch (action)
                    {
                        case "view":
                            // Safe navigation example: Shell.Current.GoToAsync("/details")
                            break;
                        default:
                            // Unknown action, ignore.
                            break;
                    }
                }
            }
            catch
            {
                // Prevent crashes from malformed notification data.
            }
        }

        public void Dispose()
        {
            if (_disposed) return;
            LocalNotificationCenter.Current.NotificationActionTapped -= OnNotificationActionTapped;
            _disposed = true;
        }
    }

