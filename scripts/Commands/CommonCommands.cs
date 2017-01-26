// Copyright (c) ReactiveTeam. All rights reserved.
// Licensed under the GPLv3 license. See LICENSE file in the project root for full license information.

using CefSharp;
using CefSharp.WinForms;
using Reactive;
using System.Windows.Forms;

namespace ReactiveUI.Commands
{
    public class CommonCommands
    {
        private static ChromiumWebBrowser _instanceBrowser = null;
        private static Form1 _instanceMainWindow = null;

        public CommonCommands(ChromiumWebBrowser originalBrowser, Form1 form)
        {
            _instanceBrowser = originalBrowser;
            _instanceMainWindow = form;
        }

        /// <summary>
        /// Returns the app version
        /// </summary>
        public string reactiveVersion
        {
            get
            {
                return App.Version.ToString();
            }
        }

        /// <summary>
        /// Returns the CEF version
        /// </summary>
        public string cefVersion
        {
            get { return Cef.CefVersion; }
        }

        /// <summary>
        /// Returns the CEFSharp version
        /// </summary>
        public string cefSVersion
        {
            get { return Cef.CefSharpVersion; }
        }

        /// <summary>
        /// Returns the CEF hash
        /// </summary>
        public string cefHash
        {
            get { return Cef.CefCommitHash; }
        }

        /// <summary>
        /// Returns the current date in the format: DD-MM-YYYY h:m:s
        /// </summary>
        public string currentDate
        {
            get { return App.CurrentTime; }
        }

        /// <summary>
        /// A function to show Chromium Developer Tools
        /// </summary>
        public void showDevTools()
        {
            _instanceBrowser.ShowDevTools();
        }

        /// <summary>
        /// Exits the app
        /// </summary>
        public void exitApp()
        {
            Application.Exit();
        }

    }
}
