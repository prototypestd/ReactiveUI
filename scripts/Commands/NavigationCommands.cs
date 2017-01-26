﻿using CefSharp.WinForms;
using Reactive;
using Reactive.Plugin;
using ReactiveUI.Renderer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public string[] navItems()
        {
            /// <see cref="https://msdn.microsoft.com/en-us/library/0fss9skc.aspx"/> 
            /// Let's keep this tamper-proof since we have our own method for adding to navigation items.
            return (string[])navItem.ToArray().Clone();
        }

        /// <summary>
        /// Next page url
        /// </summary>
        private static string nextUrl;
        public string nextPage
        {
            get { return nextUrl; }
        }


        public NavigationCommands(ChromiumWebBrowser originalBrowser, Form1 form)
        {
            _instanceBrowser = originalBrowser;
            _instanceMainWindow = form;

            foreach (var module in App.pluginManager.pluginsList)
            {
                if (module.GetType().HasProperty("navItem"))
                {
                    AddToNav(module.GetType().GetProperty("navItem").GetValue(module, null).ToString());
                }
            }
        }

        public void showPage(string page)
        {
            nextUrl = CefInstance.LoadPage(page + ".html", _instanceBrowser);
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
