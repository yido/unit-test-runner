using HCMISCodedUITest.SampleTests;
using TestManager.Services;
using TestManager.Utilites.Attributes;

namespace TestConsole
{
    public class RegisterTest: TestRegistration
    {
        public override void Registration()
        {
            Register<ReceiveCodedUITest>().Module(Modules.Receive)
                .Priority(1).
                UseModuleSequence(false);

            Register<ReceiveCodedUITest>().Module(Modules.Receive)
              .Priority(1).
              UseModuleSequence(false);
            Prioritize();
        }
    }
}
