using Reactive.Framework.Error;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReactiveUI
{
    static class Program
    {
        private static Reactive.App m_App;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Debug.Log("Application: Initializing Subsystems");
            m_App = Constants.app;

            if (!m_App.CheckSingleInstance())
            {
                return;
            }
            if (!m_App.Check64Bit())
            {
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Reactive.App.InvokeBeforeRun();

            Debug.Log("Application: Initialized subsystems");
            Reactive.App.pluginManager.StartHost();
            Application.Run(new Form1());
        }
    }
}
