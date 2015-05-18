using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestManager.Helper;
using TestManager.Utilites.Attributes;

namespace SampleTest.SampleTests
{
   
    public class DataBaseTest
    {
        public DataBaseTest()
        {
        }

        [TestMethod]
        public void DataBaseTestMethod1()
        {
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        }
        [TestMethod]
        [TestMethodDescription("Your description here!")]
        public void DataBaseTestMethod2()
        {
            var description = MethodBase.GetCurrentMethod().GetTestMethodDescription();
            var module = TestExtensions.GetTestModuleName<SampleUnitTest>().GetName();
        }
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
    }
}
