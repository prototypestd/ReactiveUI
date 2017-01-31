// Copyright (c) ReactiveTeam. All rights reserved.
// Licensed under the GPLv3 license. See LICENSE file in the project root for full license information.

using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReactiveUI.Commands
{
    /// <summary>
    /// A container for notification items.
    /// </summary>
    public struct NotificationItem
    {
        public int notificationId;
        public string notificationContent;
        public string sender;
        public int timestamp;
        public NotificationLevels type;
    }

    public enum NotificationLevels
    {
        info = 0,
        warning = 1,
        fatal = 2,
        system = 3,
        unknown = 4,
    }

    /// <summary>
    /// The notification manager handles the interface for notifications between interface and backend.
    /// </summary>
    public class NotificationManager
    {
        private static ChromiumWebBrowser _instanceBrowser = null;
        private static Form1 _instanceMainWindow = null;

        public NotificationManager(ChromiumWebBrowser originalBrowser, Form1 form)
        {
            _instanceBrowser = originalBrowser;
            _instanceMainWindow = form;
        }

        /// <summary>
        /// A list of notifications.
        /// </summary>
        /// TODO: Find a way to return a specific notification to the renderer
        private static Dictionary<int, NotificationItem> notificationItems = new Dictionary<int, NotificationItem>();
        public NotificationItem[] notification
        {
            get { return notificationItems.Values.ToArray(); }
        }

        /// <summary>
        /// Returns the total number of notifications.
        /// </summary>
        /// TODO: In UI, the notification panel is not plurarize when there are more than 1. Fix this
        public string notiCount
        {
            get { return notificationItems.Count.ToString(); }
        }

        /// <summary>
        /// Notifies the user of anything.
        /// </summary>
        /// <param name="content">The message to send to user</param>
        /// TODO: Improve the UI for notification. This depends on the level of notification. (eg: Important level should so a toast tip. Message level should be in notification panel)
        public static void NotifyUser(NotificationItem content)
        {
            int notiId = notificationItems.Count + 1;
            notificationItems.Add(notiId, content);
        }

    }
}
