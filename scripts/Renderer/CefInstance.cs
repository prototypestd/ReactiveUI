using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp;
using CefSharp.WinForms;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Reactive.Framework.Events;

namespace ReactiveUI.Renderer
{
    /// <summary>
    /// Class to initialize and handle CEF instance, also contains some common methods and variables.
    /// </summary>
    public class CefInstance
    {
        private static ChromiumWebBrowser _instanceBrowser = null;
        /// <summary>
        /// A reference to the initialized CEF instance
        /// </summary>
        public ChromiumWebBrowser chromeBrowser { get { return _instanceBrowser; } }

        /// <summary>
        /// The LoadPage event. Hook onto this to catch the Load Page command
        /// </summary>
        public static event CEFLoadPage OnLoadPage;

        private static Form _instanceMainWindow = null;
        private static string prevPage;

        /// <summary>
        /// Initializes the class
        /// </summary>
        /// <param name="originalBrowser"></param>
        /// <param name="form"></param>
        public CefInstance(ChromiumWebBrowser originalBrowser, Form form)
        {
            _instanceBrowser = originalBrowser;
            _instanceMainWindow = form;
        }

        /// <summary>
        /// Method to show CEF Dev Tools to user. (Not recommended for release)
        /// </summary>
        /// todo: Maybe use a command line argument to activate the dev tools
        public void showDevTools()
        {
            _instanceBrowser.ShowDevTools();
        }

        /// <summary>
        /// Initializes CEF subsystem
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public static ChromiumWebBrowser InitializeCEF(Form form)
        {
            CefSettings settings = new CefSettings();
            form.Text = "REACTive";

            if (!File.Exists(Constants.htmlResource+"index.html"))
            {
                GUI.MessageBox.ShowMessage("Unable to load main interface", "ERROR");
                Application.Exit();
            }

            Cef.Initialize(settings);
            ChromiumWebBrowser chromeBrowser = new ChromiumWebBrowser(Constants.htmlResource + "index.html");
            form.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;

            BrowserSettings browserSettings = new BrowserSettings();
            browserSettings.FileAccessFromFileUrls = CefState.Enabled;
            browserSettings.UniversalAccessFromFileUrls = CefState.Enabled;
            chromeBrowser.BrowserSettings = browserSettings;

            _instanceMainWindow = form;
            _instanceBrowser = chromeBrowser;
            Reactive.Framework.Error.Debug.Log(string.Format("Initialized Renderer | CEF# v{0}", Cef.CefSharpVersion));
            return chromeBrowser;
        }

        public static void LoadPage(string page, ChromiumWebBrowser browser)
        {
            if (!File.Exists(Constants.htmlResource + page))
            {
                Reactive.Framework.Error.Debug.LogFatal("Renderer: Unable to render the requested page", true, "Unable to render the requested page");
            }

            char splitDelimiter = '/';
            string[] splitText = browser.Address.Split(splitDelimiter);
            prevPage = splitText[splitText.Length - 1];

            //OnLoadPage(_instanceBrowser, new CEFOnLoadPageArgs("", page));
            browser.Load(Constants.htmlResource + page);
        }

        public static void GoBack(ChromiumWebBrowser browser)
        {
            browser.Load(Constants.htmlResource + prevPage);
        }
    }

}
