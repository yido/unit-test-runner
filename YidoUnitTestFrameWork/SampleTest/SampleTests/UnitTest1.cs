using System;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HCMISCodedUITest.SampleTests
{
    [TestClass]
    public class UnitTest1
    {
       //~ private ApplicationUnderTest _app; ~//

        [TestMethod]
        public void TestMethod1()
        {
            var test = new LoginUIMapClasses.LoginUIMap();
            test.press_login();
           // TestService.LogFakeData();

            var fullPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Microsoft\\Windows\\Start Menu\\Programs\\HCMIS\\HCMIS Warehouse.appref-ms");
            
            Process.Start(fullPath);

           //~ _app = ApplicationUnderTest.Launch(fullPath); ~// 

        }

    }
}
