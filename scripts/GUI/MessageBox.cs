using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReactiveUI.GUI
{
    public static class MessageBox
    {
        /// <summary>
        /// Shows A Message
        /// </summary>
        /// <param name="message">The content</param>
        /// <param name="caption">The title</param>
        /// todo: Create a custom MessageBox implementation
        public static void ShowMessage(string message, string caption)
        {
            System.Windows.Forms.MessageBox.Show(null,message, caption);
        }
    }
}
