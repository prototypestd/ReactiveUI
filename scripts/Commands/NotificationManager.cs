using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveUI.Commands
{
    /// <summary>
    /// The notification manager handles the interface for notifications between interface and backend.
    /// </summary>
    public class NotificationManager
    {
        private static ChromiumWebBrowser _instanceBrowser = null;
        private static Form1 _instanceMainWindow = null;

        /// <summary>
        /// Navigation Items
        /// </summary>
        private static List<string> noti = new List<string>() { "test" };
        private static List<string> notinTime = new List<string>() { "test" };
        private static int noticount = 0;

        public string[] notification
        {
            get { return noti.ToArray(); }
        }

        public string[] notificationTime
        {
            get { return notinTime.ToArray(); }
        }

        public string notiCount
        {
            get { return noticount.ToString(); }
        }


        public NotificationManager(ChromiumWebBrowser originalBrowser, Form1 form)
        {
            _instanceBrowser = originalBrowser;
            _instanceMainWindow = form;
        }
    }
}
