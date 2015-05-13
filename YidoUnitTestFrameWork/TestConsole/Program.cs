namespace TestConsole
{
    class Program
    {
        private static Main _main;
        static void Main(string[] args)
        {
            //_main = new Main(){Path = args[0],BuildNumber = args[1]}; //~ Will be modified! ~//
            //_main.TestInitialize();
            Playback.Initialize();
            _main = new Main();
            //_main.RunSingleTest<Login_To_HCMIS>();
            _main.RunSingleTest<Receive_ReceivePO_Add>();
            Playback.Cleanup();
        }
    }
}
