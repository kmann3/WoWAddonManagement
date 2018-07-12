using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAM_CLI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var foo = WAM_Core.DataModels.Setting.AutoUpdateFrequency;
            WAM_Core.DataModels.Setting.AutoUpdateFrequency = WAM_Core.DataModels.Setting.UpdateFrquencyTypes.Daily;
            var foo3 = WAM_Core.DataModels.Setting.AutoUpdateFrequency;
            int i = 0;
        }
    }
}
