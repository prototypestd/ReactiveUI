using CefSharp;
using CefSharp.WinForms;
using Reactive;
using Reactive.Framework.Error;
using ReactiveUI.Commands;
using ReactiveUI.Renderer;
using System;
using System.Windows.Forms;

namespace ReactiveUI
{

    /// <summary>
    /// Main UI entry for the application
    /// </summary>
    public partial class Form1 : Form
    {
        static CefInstance cefInstance = null;

        /// <summary>
        /// Reference to the CEF browser instance
        /// </summary>
        private ChromiumWebBrowser chromeBrowser = null;
        public ChromiumWebBrowser ChromeBrowser
        {
            get { return chromeBrowser; }
            set { chromeBrowser = value; }
        }

        /// <summary>
        /// Class Initializer. Initializes CEF and the renderer
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            chromeBrowser = CefInstance.InitializeCEF(this);
            Application.ApplicationExit += Debug.Exit;
            Reactive.Framework.Events.ApplicationEvents.addToExitEvent(Shutdown);

            cefInstance = new CefInstance(chromeBrowser, this);
            cefInstance.chromeBrowser.RegisterJsObject("commonCommands", new CommonCommands(chromeBrowser, this));
            cefInstance.chromeBrowser.RegisterJsObject("navigationCommands", new NavigationCommands(chromeBrowser, this));
            cefInstance.chromeBrowser.RegisterJsObject("notificationManager", new NotificationManager(chromeBrowser, this));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ReactiveAI.Speech.SpeechTalk.Talk("Welcome Back!");
            App.pluginManager.StartHost();
            SystemMenu.CreateSysMenu(this);
        }

        private void Shutdown()
        {
            Cef.Shutdown();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            // Test if the About item was selected from the system menu
            if ((m.Msg == SystemMenu.WM_SYSCOMMAND) &&
               ((int)m.WParam == SystemMenu.SYSMENU_CHROME_DEV_TOOLS))
            {
                chromeBrowser.ShowDevTools();
            }
        }
    }
}
