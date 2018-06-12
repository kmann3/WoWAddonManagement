using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;

namespace WoWAddonManagement.DAL
{
    public class ManagerDatabase
    {
        public static Guid InsertAddonIntoDatabase(string addonName, string gitUrl)
        {
            using (var dbContext = new DataModels.ManagerDatabaseDB("AddonManager"))
            {
                var foo = from d in dbContext.InstalledAddons orderby d.AddonName select d;
                var foo2 = foo.ToList();
                return Guid.NewGuid();
            }
        }
    }
}
