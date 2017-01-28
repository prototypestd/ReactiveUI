// Copyright (c) ReactiveTeam. All rights reserved.
// Licensed under the GPLv3 license. See LICENSE file in the project root for full license information.

using CefSharp;
using CefSharp.WinForms;
using Reactive;
using System.Windows.Forms;

namespace ReactiveUI.Commands
{
    public class UserManager
    {
        private static ChromiumWebBrowser _instanceBrowser = null;
        private static Form1 _instanceMainWindow = null;

        public UserManager(ChromiumWebBrowser originalBrowser, Form1 form)
        {
            _instanceBrowser = originalBrowser;
            _instanceMainWindow = form;
        }

        public void SaveSettings()
        {
            Constants.userSettings.Save();
        }

        /// <summary>
        /// Returns the current username.
        /// </summary>
        public string userName
        {
            get { return Constants.userSettings.userName; }
            set { Constants.userSettings.userName = value; }
        }
    }
}
