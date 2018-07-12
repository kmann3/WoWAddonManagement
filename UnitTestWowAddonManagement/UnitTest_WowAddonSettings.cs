using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestWowAddonManagement
{
    [TestClass]
    public class UnitTest_WowAddonSettings
    {
        [TestMethod]
        public void CheckAutoUpdateAllAddonsSettingForValue()
        {
            Assert.Equals(WoWAddonManagement.DAL.AddonManagerSettings.AutoUpdateAllAddons,  true);
        }
    }
}
