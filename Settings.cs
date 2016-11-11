using System;
using System.Configuration;
using System.Reflection;
using System.Runtime.InteropServices;

[DefaultMember("Item")]
internal sealed class Settings : ApplicationSettingsBase
{
    [UserScopedSetting, DefaultSettingValue("2000,1,1")]
    public DateTime DeviceUpdateLastCheckTime
    {
        get => 
            ((DateTime) this["DeviceUpdateLastCheckTime"]);
        set
        {
            this["DeviceUpdateLastCheckTime"] = value;
        }
    }

    [UserScopedSetting, DefaultSettingValue("true")]
    public bool SettingsUpgradeRequired
    {
        [return: MarshalAs(UnmanagedType.U1)]
        get => 
            ((bool) this["SettingsUpgradeRequired"]);
        [param: MarshalAs(UnmanagedType.U1)]
        set
        {
            this["SettingsUpgradeRequired"] = value;
        }
    }

    [DefaultSettingValue("2000,1,1"), UserScopedSetting]
    public DateTime SoftwareUpdateLastCheckTime
    {
        get => 
            ((DateTime) this["SoftwareUpdateLastCheckTime"]);
        set
        {
            this["SoftwareUpdateLastCheckTime"] = value;
        }
    }

    [UserScopedSetting, DefaultSettingValue("24")]
    public int SystemVoltage
    {
        get => 
            ((int) this["SystemVoltage"]);
        set
        {
            this["SystemVoltage"] = value;
        }
    }

    [DefaultSettingValue("MercedesBenz"), UserScopedSetting]
    public string TruckType
    {
        get => 
            ((string) this["TruckType"]);
        set
        {
            this["TruckType"] = value;
        }
    }

    [DefaultSettingValue("English"), UserScopedSetting]
    public string UserLanguage
    {
        get => 
            ((string) this["UserLanguage"]);
        set
        {
            this["UserLanguage"] = value;
        }
    }
}

