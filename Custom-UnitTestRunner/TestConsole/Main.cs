using System;
using System.Reflection;
using TestManager.Services;
using TestManager.Utilites;
using TestManager.Utilites.Attributes;

namespace TestConsole
{
    [Module(Modules.Main)]
    public class Main
    {
        private readonly TestManager _testManager;

        public Main()
        {
            _testManager = new TestManager();

            var registeredTests = new RegisterTest();
            registeredTests.Registration();

            _testManager.TestRegistration = registeredTests;
        }

        public string Path {get { return TestSettings.Path; } set { TestSettings.Path = value; } }
        public string BuildNumber { get { return TestSettings.AppVersion; } set { TestSettings.AppVersion = value; } }


        [TestMethodDescription("Initialization...")]
        public void TestInitialize()
        {
            try
            {
                _testManager.Initialize();
            }
            catch (Exception e)
            {
                this.Log(MethodBase.GetCurrentMethod(), e.Message);
            }

            this.Log(MethodBase.GetCurrentMethod());
        }

        [TestMethodDescription("Login Started!")]
        public void Login()
        {
            try
            {
                if ( _testManager.IsThereAnyHcmisInstance() && _testManager.IsInLoginState())
                    _testManager.Login();
            }
            catch (Exception e)
            {
                this.Log(MethodBase.GetCurrentMethod(), e.Message);
            }

            this.Log(MethodBase.GetCurrentMethod());
        }

        [TestMethodDescription("Run All Tests...")]
        public void RunAllTests()
        {
            try
            {
                _testManager.Run();
            }
            catch (Exception e)
            {
                this.Log(MethodBase.GetCurrentMethod(), e.Message);
            }
            this.Log(MethodBase.GetCurrentMethod());
        }

        [TestMethodDescription("Run a specific Module...")]
        public void RunOneModule()
        {
            _testManager.Run(Modules.Receive);
        }

        [TestMethodDescription("Run a single test")]
        public void RunSingleTest<TTest>() where TTest: class
        {
            _testManager.Run<TTest>();
        }

        [TestMethodDescription("LogOut")]
        public void LogOut()
        {
            _testManager.Finish();
            _testManager.LogOut();
        }
    }
}
