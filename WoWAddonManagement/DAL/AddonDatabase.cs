using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;

namespace WoWAddonManagement.DAL
{
    public class AddonDatabase
    {
        public static Guid InsertAddonIntoDatabase(string addonName, string gitUrl)
        {
            using (var dbContext = new DataModels.AddonDbDB())
            {
                Guid newId = Guid.NewGuid();

                DataModels.Addon newAddon = new DataModels.Addon();
                newAddon.AddonGuid = newId.ToString();
                newAddon.AddonName = addonName;
                newAddon.GitUrl = gitUrl;
                
                dbContext.Insert(newAddon);

                return newId;
            }
        }
    }
}
