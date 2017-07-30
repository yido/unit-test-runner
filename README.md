# Custom-UnitTest-Runner
Introduction:

On the surface, Custom-Test-Runner has most of the basic features of a unit test framework. You can add some custom attributes to your unit test classes: [TestClass], to signify this is a unit test class [TestSetup], run at the beginning to initialize the entire test class [TestPre], run before every unit test.  
How to use :

    _testManager = new TestManager();
    var registeredTests = new RegisterTest();
    registeredTests.Registration();
     Register<ReceiveCodedUITest>().Module(Modules.Receive)
                .Priority(1).
                UseModuleSequence(false);
                
You can prioritize your test methods:

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

