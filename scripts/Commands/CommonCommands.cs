using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp;
using CefSharp.WinForms;
using System.Diagnostics;
using System.IO;
using ReactiveUI.Renderer;
using Reactive;

namespace ReactiveUI.Commands
{
    public class CommonCommands
    {

        public string reactiveVersion
        {
            get
            {
                return App.Version.ToString();
            }
        }

        public string cefVersion
        {
            get { return Cef.CefVersion; }
        }
        public string cefSVersion
        {
            get { return Cef.CefSharpVersion; }
        }

        public string cefHash
        {
            get { return Cef.CefCommitHash; }
        }

        public string currentDate
        {
            get { return App.CurrentTime; }
        }

        private static ChromiumWebBrowser _instanceBrowser = null;
        private static Form1 _instanceMainWindow = null;

        public CommonCommands(ChromiumWebBrowser originalBrowser, Form1 form)
        {
            _instanceBrowser = originalBrowser;
            _instanceMainWindow = form;
        }

        public void showDevTools()
        {
            _instanceBrowser.ShowDevTools();
        }



    }
}
