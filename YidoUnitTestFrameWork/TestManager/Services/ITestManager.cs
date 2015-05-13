using TestManager.Utilites.Attributes;

namespace TestManager.Services
{
    public interface ITestManager
    {
        void Initialize();
        bool IsThereAnyHcmisInstance();
        bool IsInLoginState();
        void Login();
        void SetCursorToMainWindow();

        void Run<TTest>() where TTest : class;
        void Run(Modules module);
        void Run();
        TestRegistration TestRegistration { get; set; }

        void LogOut();
        void Finish();



    }
}