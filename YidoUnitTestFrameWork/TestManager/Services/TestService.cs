using System.Reflection;
using TestManager.Helper;
using TestManager.Utilites;

namespace TestManager.Services
{
    public static class TestService
    {
        private static readonly
            HCMISDBTestContext TestContext
                = new HCMISDBTestContext();

        public static void LogFakeData()
        {
            TestContext.InsertFake();
        }

        public static void Log<TTest>(this TTest Ttest,MethodBase method,string message) where TTest : class
        {
            TestContext.LogTestResult(TestSettings.AppVersion,
                TestExtensions.GetTestModuleName<TTest>().GetName(),
                method.GetTestMethodDescription() + " : Error Message -> " + message
                , false);
        }
        public static void Log<TTest>(this TTest Ttest, MethodBase method) where TTest : class
        {
            TestContext.LogTestResult(TestSettings.AppVersion, 
                TestExtensions.GetTestModuleName<TTest>().GetName(),
                method.GetTestMethodDescription(),
                true);
        }
    }
}
