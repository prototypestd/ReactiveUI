using System;
using System.Configuration;

namespace ReactiveUI
{
    public class UserSettings : ApplicationSettingsBase
    {
        [UserScopedSetting]
        [DefaultSettingValue("user")]
        public string userName
        {
            get
            {
                return (string)this["userName"];
            }
            set
            {
                if (value is string && !String.IsNullOrEmpty(value))
                {
                    this["userName"] = value;
                }
            }
        }
    }
}
