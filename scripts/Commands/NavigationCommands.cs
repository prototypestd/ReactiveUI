using CefSharp.WinForms;
using ReactiveUI.Renderer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveUI.Commands
{
    public class NavigationCommands
    {
        private static ChromiumWebBrowser _instanceBrowser = null;
        private static Form1 _instanceMainWindow = null;
        public static string[] navItems = { "test", "test2" };

        public NavigationCommands(ChromiumWebBrowser originalBrowser, Form1 form)
        {
            _instanceBrowser = originalBrowser;
            _instanceMainWindow = form;
        }

        public void showPage(string page)
        {
            CefInstance.LoadPage(page + ".html", _instanceBrowser);
        }

        public void goBack()
        {
            CefInstance.GoBack(_instanceBrowser);
        }
    }
}
