﻿using Microsoft.Win32;

namespace Privatezilla.Setting.Apps
{
    internal class TrackingApps: SettingBase
    {
        private const string AppKey = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced";
        private const int DesiredValue = 0;

        public override string ID()
        {
            return Properties.Resources.settingsAppsTrackingApps;
        }

        public override string Info()
        {
            return Properties.Resources.settingsAppsTrackingAppsInfo;
        }

        public override bool CheckSetting()
        {
            return !(
               RegistryHelper.IntEquals(AppKey, "Start_TrackProgs", DesiredValue)
             );
        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(AppKey, "Start_TrackProgs", DesiredValue, RegistryValueKind.DWord);
                return true;
            }
            catch
            { }

            return false;
        }


        public override bool UndoSetting()
        {
            try
            {
                Registry.SetValue(AppKey, "Start_TrackProgs", 1, RegistryValueKind.DWord);
                return true;
            }
            catch
            { }

            return false;
        }
    }
}