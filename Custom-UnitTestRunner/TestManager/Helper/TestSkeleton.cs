using TestManager.Utilites.Attributes;

namespace TestManager.Helper
{
    public class TestSkeleton
    {
        private Modules _modules;
        private  int _priority;
        private  bool _useModuleSequence;

        public TestSkeleton Module(Modules module)
        {
            _modules = module;
            return this;
        }

        public TestSkeleton Priority(int priority)
        {
            _priority = priority;
            return this;
        }

        public TestSkeleton UseModuleSequence(bool useModuleSequence)
        {
            _useModuleSequence = useModuleSequence;
            return this;
        }

        public int GetPriority { get { return _priority; } }
        public Modules GetModule { get { return _modules; } }
        public bool GetUseModuleSequence { get { return _useModuleSequence; } }
    }
}


