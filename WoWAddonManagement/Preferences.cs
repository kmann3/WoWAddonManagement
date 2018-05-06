using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoWAddonManagement
{
    [Serializable]
    public class Preferences
    {
        public enum UpdateFrequency
        {
            EveryFourHours,
            Daily,
            EveryOtherDay,
            Weekly,
            Monthly,
            ManualOnly
        }

        public UpdateFrequency UpdateCheckFrequency = UpdateFrequency.EveryOtherDay;
        public string WoWLocation { get; set; }

        public Preferences()
        {
            this.UpdateCheckFrequency = UpdateFrequency.EveryOtherDay;
            this.WoWLocation = String.Empty;
        }
    }
}
