using System;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SampleTest.SampleTests
{
    [TestClass]
    public class UnitTest1
    {
       //~ private ApplicationUnderTest _app; ~//

        [TestMethod]
        public void TestMethod1()
        {
            //var test = new LoginUIMapClasses.LoginUIMap();
            //test.press_login();
           // TestService.LogFakeData();

            var fullPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "your app path");
            
            Process.Start(fullPath);

           //~ _app = ApplicationUnderTest.Launch(fullPath); ~// 

        }

    }
}
