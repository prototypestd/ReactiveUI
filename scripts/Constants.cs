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
    }
}
