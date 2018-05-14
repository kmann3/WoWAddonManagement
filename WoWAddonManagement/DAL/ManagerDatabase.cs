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
            using (var dbContext = new DataModels.ManagerDatabaseDB())
            {
                return Guid.NewGuid();
            }
        }
    }
}
