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
        /// A list of notification items.
        /// </summary>
        /// TODO: Improve the notification logic. A suggestion is using a Dictionary.
        private static List<string> noti = new List<string>() { "test" };
        public string[] notification()
        {
            /// <see cref="https://msdn.microsoft.com/en-us/library/0fss9skc.aspx"/> 
            /// Let's keep this tamper-proof since we have our own method for adding to navigation items.
            return (string[])noti.ToArray().Clone();
        }

        /// <summary>
        /// A list of notification times.
        /// </summary>
        /// TODO: Since this should be contained within the notification items list. This should be removed during the improvement of the notification logic.
        private static List<string> notinTime = new List<string>() { "test" };
        public string[] notificationTime()
        {
            /// <see cref="https://msdn.microsoft.com/en-us/library/0fss9skc.aspx"/> 
            /// Let's keep this tamper-proof since we have our own method for adding to navigation items.
            return (string[])notinTime.ToArray().Clone();
        }

        /// <summary>
        /// The number of notifications
        /// </summary>
        /// TODO: Should be counted from the number of notifications in the list. This should be removed during the improvement of the notification logic.
        private static int noticount = 0;
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
