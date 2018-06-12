using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace WoWAddonManagement.DAL
{
    public class Addons
    {
        private static List<Addon> _addonList { get; set; }
        public static List<Addon> AddonList {
            get
            {
                if (_addonList == null)
                {
                    LoadAddonList();
                }                    

                return _addonList;
            }
            set
            {
                _addonList = value;
            }
        }

        private static List<Addon> LoadAddonList()
        {
            List<Addon> loadList = new List<Addon>();
            using (var dbContext = new DataModels.AddonListDB("AddonList"))
            {
                var foo = from d in dbContext.Addons orderby d.AddonName select d;
                var foo2 = foo.ToList();
                return null;
            }
        }

        /// <summary>
        /// Class used to reference the AddonList XML file.
        /// </summary>
        public class Addon
        {
            public string Name { get; set; }
            public Guid Id { get; set; }
            public List<string> Categories { get; set; }
            public string Description { get; set; }
            public Uri GitUrl { get; set; }

            public override string ToString()
            {
                return "Name: " + this.Name + " | ID: " + this.Id;
            }
        }
    }
}
