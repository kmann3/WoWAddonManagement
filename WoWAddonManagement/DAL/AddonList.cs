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

        private static void LoadAddonList()
        {
            /* Download the file */

            /* Parse the file */
            _addonList = new List<Addon>();
            XElement xelement = XElement.Load("AddonList.xml");
            IEnumerable<XElement> addons = xelement.Elements();

            foreach (var addon in addons)
            {
                Addon newAddon = new Addon();
                newAddon.Name = addon.Element("Name").Value;

                Guid id;
                if (Guid.TryParse(addon.Element("GUID").Value, out id))
                {
                    newAddon.Id = id;

                }
                else
                {
                    throw new Exception("Invalid GUID");
                }

                newAddon.GitUrl = new Uri(addon.Element("GitUrl").Value);
                if (newAddon.GitUrl.IsAbsoluteUri == false)
                {
                    throw new Exception("Invalid Git URL");
                }

                newAddon.Description = addon.Element("Description").Value;
                string categories = addon.Element("Categories").Value;
                if (String.IsNullOrEmpty(categories) == false)
                {
                    newAddon.Categories = new List<string>();
                    foreach (string category in categories.Split(';'))
                    {
                        newAddon.Categories.Add(category);
                    }

                }

                _addonList.Add(newAddon);
            }

            _addonList.Sort((x, y) => x.Name.CompareTo(y.Name));
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
