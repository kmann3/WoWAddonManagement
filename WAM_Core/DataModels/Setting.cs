using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;

namespace WAM_Core.DataModels
{
    public partial class Setting
    {
        /// <summary>
        /// List of settings offered.
        /// </summary>
        public enum WAM_Setting
        {
            AutoUpdateAllAddons,
            AutoUpdateFrequency,
            EnableStatisticsTracking,
            WoWLocation
        }

        /// <summary>
        /// How often the app should check for updates. This is a global "dumb" setting.
        /// Meaning it checks all addons at X frequency. So, hypothetically, all at noon. Not based off of when you installed it.
        /// Every 2 hours if all even numbers, 6 hours is 00:00, 06:00, 12:00, 18:00, 12 hours is noon and midnight.
        /// Daily is, well, daily. Weekly is Wednesday.
        /// </summary>
        public enum UpdateFrquencyTypes
        {
            Unset,
            Hourly,
            Every2Hours,
            Every6Hours,
            Every12Hours,
            Daily,
            Weekly
        }

        public static bool AutoUpdateAllAddons
        {
            get
            {
                string getSet = GetSetting(WAM_Setting.AutoUpdateAllAddons);
                if (getSet == null)
                {
                    // Setting not found in database at all. Insert one and return a default value.
                    SetSetting(WAM_Setting.AutoUpdateAllAddons, bool.TrueString);
                    return true;
                }
                else
                {
                    if (Boolean.TryParse(getSet, out bool result) == true)
                    {
                        return result;
                    }
                    else
                    {
                        // Someone probably manually tweaked it and it's no longer parasable as true/false so let's reset it.
                        SetSetting(WAM_Setting.AutoUpdateAllAddons, bool.TrueString);
                        return true;
                    }
                }
            }
            set
            {
                SetSetting(WAM_Setting.AutoUpdateAllAddons, value.ToString());
            }
        }

        public static UpdateFrquencyTypes AutoUpdateFrequency
        {
            get
            {
                string getSet = GetSetting(WAM_Setting.AutoUpdateFrequency);
                if (getSet == null)
                {
                    // Setting not found in database at all. Insert one and return a default value.
                    SetSetting(WAM_Setting.AutoUpdateFrequency, UpdateFrquencyTypes.Daily.ToString());
                    return UpdateFrquencyTypes.Daily;
                }
                else
                {
                    switch (getSet)
                    {
                        case "Unset":
                             return UpdateFrquencyTypes.Unset;
                        case "Hourly":
                            return UpdateFrquencyTypes.Hourly;
                        case "Every2Hours":
                            return UpdateFrquencyTypes.Every2Hours;
                        case "Every6Hours":
                            return UpdateFrquencyTypes.Every6Hours;
                        case "Every12Hours":
                            return UpdateFrquencyTypes.Every12Hours;
                        case "Daily":
                            return UpdateFrquencyTypes.Daily;
                        case "Weekly":
                            return UpdateFrquencyTypes.Weekly;
                        default:
                            SetSetting(WAM_Setting.AutoUpdateFrequency, UpdateFrquencyTypes.Daily.ToString());
                            return UpdateFrquencyTypes.Daily;
                    }
                }
            }
            set
            {
                SetSetting(WAM_Setting.AutoUpdateFrequency, value.ToString());
            }
        }
        public static bool EnableStatisticsTracking
        {
            get
            {
                string getSet = GetSetting(WAM_Setting.EnableStatisticsTracking);
                if (getSet == null)
                {
                    // Setting not found in database at all. Insert one and return a default value.
                    SetSetting(WAM_Setting.EnableStatisticsTracking, bool.TrueString);
                    return true;
                }
                else
                {
                    if (Boolean.TryParse(getSet, out bool result) == true)
                    {
                        return result;
                    }
                    else
                    {
                        // Someone probably manually tweaked it and it's no longer parasable as true/false so let's reset it.
                        SetSetting(WAM_Setting.EnableStatisticsTracking, bool.TrueString);
                        return true;
                    }
                }
            }
            set
            {
                SetSetting(WAM_Setting.EnableStatisticsTracking, value.ToString());
            }
        }

        public static string WoWLocation
        {
            get
            {
                string getSet = GetSetting(WAM_Setting.WoWLocation);
                if (getSet == null)
                {
                    // Setting not found in database at all. Insert one and return a default value.
                    SetSetting(WAM_Setting.WoWLocation, string.Empty);
                    return string.Empty;
                }

                return getSet;
            }
            set
            {
                SetSetting(WAM_Setting.WoWLocation, value);
            }
        }

        private static string GetSetting(WAM_Setting settingName)
        {
            using (var dbContext = new DataModels.WamDbDB("WAM_DB"))
            {
                var returnSetting = (from s in dbContext.Settings where s.SettingName == settingName.ToString() select s).SingleOrDefault();
                if (returnSetting == null) return null;
                return returnSetting.SettingValue;
            }
        }

        private static void SetSetting(WAM_Setting settingName, string settingValue)
        {
            using (var dbContext = new DataModels.WamDbDB("WAM_DB"))
            {
                var returnSetting = (from s in dbContext.Settings where s.SettingName == settingName.ToString() select s).SingleOrDefault();
                if (returnSetting == null)
                {
                    DataModels.Setting newSetting = new Setting() { SettingName = settingName.ToString(), SettingValue = settingValue };
                    dbContext.Insert(newSetting);
                } else
                {
                    returnSetting.SettingValue = settingValue;
                    dbContext.Update(returnSetting);
                }
            }
        }
    }
}