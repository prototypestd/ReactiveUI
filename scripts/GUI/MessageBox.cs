// Copyright (c) ReactiveTeam. All rights reserved.
// Licensed under the GPLv3 license. See LICENSE file in the project root for full license information.

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
