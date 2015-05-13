using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestManager.Helper;
using TestManager.Services;
using TestManager.Utilites;
using TestManager.Utilites.Attributes;

namespace HCMISCodedUITest.SampleTests
{
    /// <summary>
    /// Summary description for ReceiveCodedUITest
    /// </summary>
    [CodedUITest]
    [Module(Modules.Receive)]
    public class ReceiveCodedUITest
    {
        public ReceiveCodedUITest()
        {
        }

        [TestMethod]
        [TestMethodDescription("Just a Login!")]
        public void CodedUITestMethod1()
        {
            LoginUIMap.LoginTest();
            var version = LoginUIMap.LoadAppVersion();
            TestSettings.AppVersion = version;

            var description = MethodBase.GetCurrentMethod().GetTestMethodDescription();
            var module = TestExtensions.GetTestModuleName<ReceiveCodedUITest>().GetName();
            
            testContextInstance.WriteLine("Description: " + description + "Module: " +module);
        }

        public string LoadAppVersion()
        {
            string version = string.Empty;
            try
            {
                 version = LoginUIMap.LoadAppVersion();
            }
            catch (Exception e)
            {
                this.Log(MethodBase.GetCurrentMethod(),e.Message);
            }

            this.Log(MethodBase.GetCurrentMethod());
            return version;
        }
        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        //Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            Playback.PlaybackSettings.ShouldSearchFailFast = false;
            Playback.PlaybackSettings.DelayBetweenActions = 2000;
            Playback.PlaybackSettings.SearchTimeout = 3000;
            Playback.PlaybackSettings.MatchExactHierarchy = true;
            Playback.PlaybackSettings.SmartMatchOptions = SmartMatchOptions.Control;
            Playback.PlaybackSettings.SmartMatchOptions = SmartMatchOptions.TopLevelWindow;
            Playback.PlaybackSettings.SmartMatchOptions = SmartMatchOptions.None;
            Playback.PlaybackSettings.SearchInMinimizedWindows = true;
            Playback.PlaybackSettings.ThinkTimeMultiplier = 2;
            Playback.PlaybackSettings.WaitForReadyLevel = WaitForReadyLevel.AllThreads;
            Playback.PlaybackSettings.WaitForReadyLevel = WaitForReadyLevel.UIThreadOnly;
            Playback.PlaybackSettings.WaitForReadyLevel = WaitForReadyLevel.Disabled;
            Playback.PlaybackSettings.WaitForReadyTimeout = 1000;
        }

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        public HCMISCodedUITest.LoginUIMapClasses.LoginUIMap LoginUIMap
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new HCMISCodedUITest.LoginUIMapClasses.LoginUIMap();
                }

                return this.map;
            }
        }

        private HCMISCodedUITest.LoginUIMapClasses.LoginUIMap map;
    }
}
