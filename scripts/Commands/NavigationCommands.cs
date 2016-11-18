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

        /// <summary>
        /// Navigation Items
        /// </summary>
        private static List<string> navItem = new List<string>() { "test" };
        public string[] navItems
        {
            get { return navItem.ToArray(); }
        }


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

        /// <summary>
        /// Dynamically adds a navigation item to the navList
        /// </summary>
        /// <param name="page"></param>
        public static void AddToNav(string page)
        {
            if (!String.IsNullOrEmpty(page))
            {
                navItem.Add(page);
            }
        }
    }
}
