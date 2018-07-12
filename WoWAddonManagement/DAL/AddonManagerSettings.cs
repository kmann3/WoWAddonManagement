using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;
using System.IO;

namespace WoWAddonManagement.DAL
{
    public class AddonManagerSettings
    {
        /// <summary>
        /// Overrides all individual settings and forces auto-update on all addons.
        /// True will be our default setting should the setting get messed up or non-existant.
        /// </summary>
        public static bool AutoUpdateAllAddons
        {
            get
            {
                using (var dbContext = new DataModels.ManagerDatabaseDB("AddonManager"))
                {
                    if (autoUpdateAllAddons == null)
                    {
                        var settingValue = (from s in dbContext.Settings where s.SettingName == "AutoUpdateAllAddons" select s.SettingValue).SingleOrDefault();
                        if (settingValue == null)
                        {
                            DataModels.Setting newSettingValue = new DataModels.Setting() { SettingName = "AutoUpdateAllAddons", SettingValue = bool.TrueString };
                            dbContext.Insert(newSettingValue);
                            autoUpdateAllAddons = true;
                        } else
                        {
                            if(Boolean.TryParse(settingValue, out bool result))
                            {
                                autoUpdateAllAddons = result;
                            } else
                            {
                                settingValue = bool.TrueString;
                                autoUpdateAllAddons = true;
                                dbContext.Update(settingValue);
                            }
                        }
                    }

                    return (bool)autoUpdateAllAddons;
                }
            }
            set
            {
                autoUpdateAllAddons = value;

                using (var dbContext = new DataModels.ManagerDatabaseDB("AddonManager"))
                {
                    var settingValue = (from s in dbContext.Settings where s.SettingName == "AutoUpdateAllAddons" select s.SettingValue).SingleOrDefault();
                    if (settingValue == null)
                    {
                        DataModels.Setting newSettingValue = new DataModels.Setting() { SettingName = "AutoUpdateAllAddons", SettingValue = value.ToString() };
                        dbContext.Insert(newSettingValue);
                    }
                    else
                    {
                        settingValue = value.ToString();
                        dbContext.Update(settingValue);
                    }
                }
            }
        }
        /// <summary>
        /// Allows uploading of install addon data.
        /// True is our default settings.
        /// </summary>
        public static bool EnableStatisticsTracking
        {
            get
            {
                using (var dbContext = new DataModels.ManagerDatabaseDB("AddonManager"))
                {
                    if (autoUpdateAllAddons == null)
                    {
                        var settingValue = (from s in dbContext.Settings where s.SettingName == "EnableStatisticsTracking" select s.SettingValue).SingleOrDefault();
                        if (settingValue == null)
                        {
                            DataModels.Setting newSettingValue = new DataModels.Setting() { SettingName = "EnableStatisticsTracking", SettingValue = bool.TrueString };
                            dbContext.Insert(newSettingValue);
                            enableStatisticsTracking = true;
                        }
                        else
                        {
                            if (Boolean.TryParse(settingValue, out bool result))
                            {
                                enableStatisticsTracking = result;
                            }
                            else
                            {
                                settingValue = bool.TrueString;
                                enableStatisticsTracking = true;
                                dbContext.Update(settingValue);
                            }
                        }
                    }

                    return (bool)enableStatisticsTracking;
                }
            }
            set
            {
                enableStatisticsTracking = value;

                using (var dbContext = new DataModels.ManagerDatabaseDB("AddonManager"))
                {
                    var settingValue = (from s in dbContext.Settings where s.SettingName == "EnableStatisticsTracking" select s.SettingValue).SingleOrDefault();
                    if (settingValue == null)
                    {
                        DataModels.Setting newSettingValue = new DataModels.Setting() { SettingName = "EnableStatisticsTracking", SettingValue = value.ToString() };
                        dbContext.Insert(newSettingValue);
                    }
                    else
                    {
                        settingValue = value.ToString();
                        dbContext.Update(settingValue);
                    }
                }
            }
        }

        /// <summary>
        /// How often to check for updates
        /// </summary>
        public static UpdateFrquencyTypes UpdateFrquency
        {
            get
            {
                using (var dbContext = new DataModels.ManagerDatabaseDB("AddonManager"))
                {
                    if (updateFrequency == null)
                    {
                        var settingValue = (from s in dbContext.Settings where s.SettingName == "UpdateFrequency" select s.SettingValue).SingleOrDefault();
                        if (settingValue == null)
                        {
                            DataModels.Setting newSettingValue = new DataModels.Setting() { SettingName = "UpdateFrequency", SettingValue = UpdateFrquencyTypes.Daily.ToString() };
                            dbContext.Insert(newSettingValue);
                            updateFrequency = UpdateFrquencyTypes.Daily;
                        }
                        else
                        {
                            switch (settingValue)
                            {
                                case "Unset":
                                    updateFrequency = UpdateFrquencyTypes.Unset;
                                    break;
                                case "Hourly":
                                    updateFrequency = UpdateFrquencyTypes.Hourly;
                                    break;
                                case "Every2Hours":
                                    updateFrequency = UpdateFrquencyTypes.Every2Hours;
                                    break;
                                case "Every6Hours":
                                    updateFrequency = UpdateFrquencyTypes.Every6Hours;
                                    break;
                                case "Every12Hours":
                                    updateFrequency = UpdateFrquencyTypes.Every12Hours;
                                    break;
                                case "Daily":
                                    updateFrequency = UpdateFrquencyTypes.Daily;
                                    break;
                                case "Weekly":
                                    updateFrequency = UpdateFrquencyTypes.Weekly;
                                    break;
                                default:
                                    settingValue = UpdateFrquencyTypes.Daily.ToString();
                                    updateFrequency = UpdateFrquencyTypes.Daily;
                                    dbContext.Update(settingValue);
                                    break;
                            }
                        }
                    }
                    
                    return (UpdateFrquencyTypes)updateFrequency;
                }
            }
            set
            {
                updateFrequency = value;

                using (var dbContext = new DataModels.ManagerDatabaseDB("AddonManager"))
                {
                    var settingValue = (from s in dbContext.Settings where s.SettingName == "UpdateFrequency" select s.SettingValue).SingleOrDefault();
                    if (settingValue == null)
                    {
                        DataModels.Setting newSettingValue = new DataModels.Setting() { SettingName = "UpdateFrequency", SettingValue = value.ToString() };
                        dbContext.Insert(newSettingValue);
                    }
                    else
                    {
                        settingValue = value.ToString();
                        dbContext.Update(settingValue);
                    }
                }
            }
        }

        /// <summary>
        /// Options for frquency to update.
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

        /// <summary>
        /// Location of the World of Warcraft directory. We can infer the addon directory with this.
        /// </summary>
        public static string WoWLocation
        {
            get
            {
                using (var dbContext = new DataModels.ManagerDatabaseDB("AddonManager"))
                {
                    if (wowLocation == null)
                    {
                        var settingValue = (from s in dbContext.Settings where s.SettingName == "WoWLocation" select s.SettingValue).SingleOrDefault();
                        if (settingValue == null)
                        {
                            DataModels.Setting newSettingValue = new DataModels.Setting() { SettingName = "WoWLocation", SettingValue = string.Empty };
                            dbContext.Insert(newSettingValue);
                            autoUpdateAllAddons = true;
                        }
                        else
                        {
                            // Is it a valid path
                            if(!Directory.Exists(settingValue))
                            {
                                settingValue = string.Empty;
                                wowLocation = string.Empty;
                                dbContext.Update(settingValue);
                            } else
                            {
                                wowLocation = settingValue;
                            }

                        }
                    }

                    return wowLocation;
                }
            }
            set
            {
                wowLocation = value;

                using (var dbContext = new DataModels.ManagerDatabaseDB("AddonManager"))
                {
                    var settingValue = (from s in dbContext.Settings where s.SettingName == "WoWLocation" select s.SettingValue).SingleOrDefault();
                    if (settingValue == null)
                    {
                        DataModels.Setting newSettingValue = new DataModels.Setting() { SettingName = "WoWLocation", SettingValue = value };
                        dbContext.Insert(newSettingValue);
                        autoUpdateAllAddons = true;
                    }
                    else
                    {
                        // Is it a valid path
                        if (Directory.Exists(settingValue))
                        {
                            settingValue = value;
                            dbContext.Update(settingValue);
                        } else
                        {
                            throw new DirectoryNotFoundException("WoW folder doesn't exist? What's up with that?");
                        }
                    }
                }
            }
        }

        private static bool? autoUpdateAllAddons = null;
        private static bool? enableStatisticsTracking = null;
        private static UpdateFrquencyTypes? updateFrequency = null;
        private static string wowLocation = null;
    }
}
