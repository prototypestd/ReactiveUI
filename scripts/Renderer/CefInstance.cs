using System;
using CefSharp;
using CefSharp.WinForms;
using System.IO;
using System.Windows.Forms;
using Reactive.Framework.Events;
using System.Runtime.InteropServices;

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

            try
            {
                if (!File.Exists(Constants.htmlResource + "index.html"))
                    throw new FileNotFoundException();

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
            catch (FileNotFoundException e)
            {
                GUI.MessageBox.ShowMessage("Unable to load " + e.FileName, "CEFInstance Error");
                Reactive.Framework.Error.Debug.LogFatal("Failed to initalize CEF due to incomplete data. ERROR_CODE: 0404", true);
            }

            return null;
        }


        /// <summary>
        /// Does what the name says, loads a page.
        /// </summary>
        /// <param name="page"></param>
        /// <param name="browser"></param>
        public static string LoadPage(string page, ChromiumWebBrowser browser = null, string pageURL = null)
        {
            if (!File.Exists(Constants.htmlResource + page))
            {
                Reactive.Framework.Error.Debug.LogFatal("Renderer: Unable to render the requested page", true, "Unable to render the requested page");
            }

            if(browser == null)
            {
                browser = _instanceBrowser;
            }

            char splitDelimiter = '/';
            string[] splitText = browser.Address.Split(splitDelimiter);
            
            if(!(prevPage == splitText[splitText.Length - 1]))
            {
                prevPage = splitText[splitText.Length - 1];
            }

            //OnLoadPage(_instanceBrowser, new CEFOnLoadPageArgs("", page));

            if (String.IsNullOrEmpty(pageURL))
            {

                return page;
                //browser.Load(Constants.htmlResource + page);
            }
            else
            {
                return page;
                //browser.Load(pageURL + page);
            }

        }

        /// <summary>
        /// Goes back to the prevPage
        /// </summary>
        /// <param name="browser"></param>
        /// todo: Improve the logic so it doesn't record current page when navigating to the same page.
        public static void GoBack(ChromiumWebBrowser browser)
        {
            browser.Load(Constants.htmlResource + prevPage);
        }
    }

    static class SystemMenu
    {
        // P/Invoke constants
        public static int WM_SYSCOMMAND = 0x112;
        public static int MF_STRING = 0x0;
        public static int MF_SEPARATOR = 0x800;

        // P/Invoke declarations
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool AppendMenu(IntPtr hMenu, int uFlags, int uIDNewItem, string lpNewItem);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool InsertMenu(IntPtr hMenu, int uPosition, int uFlags, int uIDNewItem, string lpNewItem);

        // ID for the Chrome dev tools item on the system menu
        public static int SYSMENU_CHROME_DEV_TOOLS = 0x1;

        public static void CreateSysMenu(Form frm)
        {
            // in your form override the OnHandleCreated function and call this method e.g:
            // protected override void OnHandleCreated(EventArgs e)
            // {
            //     ChromeDevToolsSystemMenu.CreateSysMenu(frm,e);
            // }

            // Get a handle to a copy of this form's system (window) menu
            IntPtr hSysMenu = GetSystemMenu(frm.Handle, false);

            // Add a separator
            AppendMenu(hSysMenu, MF_SEPARATOR, 0, string.Empty);

            // Add the About menu item
            AppendMenu(hSysMenu, MF_STRING, SYSMENU_CHROME_DEV_TOOLS, "&Chrome Dev Tools");
        }
    }

}
