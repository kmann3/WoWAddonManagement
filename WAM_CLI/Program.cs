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
            Console.WriteLine("AutoUpdateFrequency: {0}", WAM_Core.DataModels.Setting.AutoUpdateFrequency);
            Console.Read();
        }
    }
}
