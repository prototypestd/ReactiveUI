using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReactiveUI.GUI
{
    public class MessageBox
    {
        public static void ShowMessage(string message, string caption)
        {
            System.Windows.Forms.MessageBox.Show(null,message, caption);
        }
    }
}
