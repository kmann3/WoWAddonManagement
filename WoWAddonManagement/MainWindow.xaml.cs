using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WoWAddonManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

        }

        private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }

        private void Button_BackupAddonList_Click(object sender, RoutedEventArgs e)
        {
            //var foo = DAL.ManagerDatabase.InsertAddonIntoDatabase("Saved Instances", "https://github.com/SavedInstances/SavedInstances");
            //MessageBox.Show("inserted with guid: " + foo.ToString());
            //List<DAL.Addons.Addon> foo = DAL.Addons.AddonList;
            //var foo2 = DAL.ManagerDatabase.InsertAddonIntoDatabase("Foo", "foo");
            //var foo = DAL.AddonManagerSettings.AutoUpdateAllAddons;
            DAL.AddonManagerSettings.AutoUpdateAllAddons = true;
            DAL.AddonManagerSettings.EnableStatisticsTracking = true;
            DAL.AddonManagerSettings.UpdateFrquency = DAL.AddonManagerSettings.UpdateFrquencyTypes.Daily;
            DAL.AddonManagerSettings.WoWLocation = @"C:\Games\World of Warcraft";

        }
    }
}
