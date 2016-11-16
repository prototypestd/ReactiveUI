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
        public ChromiumWebBrowser chromeBrowser = null;

        /// <summary>
        /// Class Initializer. Initializes CEF and the renderer
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            chromeBrowser = CefInstance.InitializeCEF(this);
            Application.ApplicationExit += Debug.Exit;

            cefInstance = new CefInstance(chromeBrowser, this);
            cefInstance.chromeBrowser.RegisterJsObject("commonCommands", new CommonCommands(chromeBrowser, this));
            cefInstance.chromeBrowser.RegisterJsObject("navigationCommands", new NavigationCommands(chromeBrowser, this));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ReactiveAI.Speech.SpeechTalk.Talk("Welcome Back!");
            App.pluginManager.StartHost();
        }

        private void Form1_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }
    }
}
