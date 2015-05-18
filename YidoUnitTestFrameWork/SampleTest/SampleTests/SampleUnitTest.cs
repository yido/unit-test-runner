using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestManager.Utilites.Attributes;

namespace SampleTest.SampleTests
{
    [Module(Modules.Activities)]
    public class SampleUnitTest
    {
        [Priority(0)]
        [TestMethodDescription("one")]
        public void TestMethod1()
        {
            var t = 1;
            var t2 = 2;
            Assert.AreNotEqual(t,t2);
        }
        [Priority(2)]
        [TestMethodDescription("two")]
        public void TestMethod2()
        {
            var t = 2;
            var t2 = 3;
            Assert.AreNotEqual(t, t2);
        }
        [Priority(1)]
        [TestMethodDescription("Three...")]
        public void TestMethod3()
        {
            var t = 3;
            var t2 = 4;
            Assert.AreNotEqual(t, t2);
        }
    }
}
