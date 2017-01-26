// Copyright (c) ReactiveTeam. All rights reserved.
// Licensed under the GPLv3 license. See LICENSE file in the project root for full license information.

using CefSharp.WinForms;
using Reactive;
using ReactiveUI.Renderer;
using System;
using System.Collections.Generic;

namespace ReactiveUI.Commands
{
    public class NavigationCommands
    {
        private static ChromiumWebBrowser _instanceBrowser = null;
        private static Form1 _instanceMainWindow = null;

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

        /// <summary>
        /// Navigation Items
        /// </summary>
        private static List<string> navItem = new List<string>() { "test" };
        public string[] navItems
        {
            get { return navItem.ToArray(); }
        }

        /// <summary>
        /// Next page url
        /// </summary>
        private static string nextUrl;
        public string nextPage
        {
            get { return nextUrl; }
        }

        /// <summary>
        /// This loads the page into the iframe in the UI
        /// </summary>
        /// <param name="page"></param>
        /// TODO: Should I improve this logic? Maybe some checks for it?
        public void showPage(string page)
        {
            nextUrl = CefInstance.LoadPage(page + ".html", _instanceBrowser);
        }

        /// <summary>
        /// Go backs to the previous page.
        /// </summary>
        /// TODO: Improve this logic. (Right now, it doesn't work...)
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
