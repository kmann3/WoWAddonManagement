// File: InstalledAddon.cs - 7/13/2018
// Author: Kennith Mann
// (C) Kennith Mann

using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using LibGit2Sharp;
using System.IO;

namespace WAM_Core.DataModels
{
    public partial class InstalledAddon
    {
		public static List<InstalledAddon> GetInstalledAddonsList() 
		{
			using (var dbContext = new DataModels.WamDbDB("WAM_DB")) 
			{
                return (from a in dbContext.InstalledAddons orderby a.AddonName select a).ToList();
			}
        }

        /// <summary>
        /// Installs the addon under the directory of the addon name via a `git clone` command.
        /// </summary>
        /// <param name="addonId">Addon identifier.</param>
        public static void InstallAddon(Guid addonId) 
        {
            using (var dbContext = new DataModels.AddonLibraryDB("AddonLibrary_DB"))
            using (var wamDbContext = new DataModels.WamDbDB("WAM_DB")) 
    
            {
                DataModels.Addon addonToInstall = (from a in dbContext.Addons where a.AddonGuid == addonId.ToString() select a).Single();

                string addonPath = Path.Combine(Setting.WoWLocation, addonToInstall.AddonName);
                Repository.Clone(addonToInstall.GitUrl, addonPath);

                DataModels.InstalledAddon installedAddon = new InstalledAddon();
                installedAddon.AddonGuid = addonId.ToString();
                installedAddon.AddonName = addonToInstall.AddonName;
                installedAddon.GitUrl = addonToInstall.GitUrl;

                installedAddon.AutoUpdate = 1; // true
                installedAddon.InstallDate = DateTime.Now.ToString();
                installedAddon.LastCheckDate = DateTime.Now.ToString();

                wamDbContext.Insert(installedAddon);
            }
        }

        /// <summary>
        /// Updates the addon via a simple `git pull` command.
        /// </summary>
        /// <param name="addonId">Addon identifier.</param>
        public static void UpdateAddon(Guid addonId) 
        {
            using (var dbContext = new DataModels.WamDbDB("WAM_DB")) 
            {
                var addonToUpdate = (from a in dbContext.InstalledAddons where a.AddonGuid == addonId.ToString() select a).Single();
                string addonPath = Path.Combine(Setting.WoWLocation, addonToUpdate.AddonName);
                //using (var repo = new Repository(addonPath)) 
                //{
                //    repo.Network.Pull();
                //}
            }
        }
    }
}
