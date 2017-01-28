// Copyright (c) ReactiveTeam. All rights reserved.
// Licensed under the GPLv3 license. See LICENSE file in the project root for full license information.

using Reactive;
using Reactive.Framework.Error;

namespace ReactiveUI
{
    /// <summary>
    /// Constants available throughout the whole application
    /// </summary>
    public static class Constants
    {
        public static string htmlResource = string.Format(@"{0}\html-resources\html\", App.StartupPath);
        public static App app = new App();
        public static Debug debug = new Debug();
        public static UserSettings userSettings = new UserSettings();
    }
}
