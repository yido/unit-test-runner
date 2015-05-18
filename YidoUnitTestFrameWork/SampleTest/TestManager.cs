using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestManager.Services;
using TestManager.Utilites;
using TestManager.Utilites.Attributes;

namespace SampleTest
{
    public class TestManager:ITestManager
    {

        #region Initilaze and Login

        public void Initialize()
        {
            StartHCMIS();
            LoadAppVersion();
            #region playBackSettings

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

            #endregion

        }


        protected void StartHCMIS()
        {
           // var fullPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),"Microsoft\\Windows\\Start Menu\\Programs\\HCMIS\\HCMIS Warehouse.appref-ms");
            var fullPath = TestSettings.Path; //~  WE NEED TO MODIFY IT! ~//
            Process.Start(fullPath);
        }

        private void LoadAppVersion()
        {
           // TestSettings.AppVersion = yourmap.LoadAppVersion();
        }

        public bool IsThereAnyHcmisInstance()
        {
            throw new NotImplementedException();
        }

        public bool IsInLoginState()
        {
            throw new NotImplementedException();
        }

        public void Login()
        {
            throw new NotImplementedException();
        }

        public void SetCursorToMainWindow()
        {
            throw new NotImplementedException();
        }

        #endregion
        
        #region Main Test

        public void Run<TTest>() where TTest : class
        {
            Run(typeof (TTest));
        }
   
        public void Run(Modules module)
        {
            throw new NotImplementedException();
        }

        public void Run()
        {
            foreach (var test in TestRegistration.PrioritizedTests)
            {
                Run(test);
            }
        }
        protected void Run(Type type)
        {
            var instance = Activator.CreateInstance(type);
            var methods = PrioritizedMethods(type.GetMethods());

            foreach (var method in methods)
            {
                method.Invoke(instance,null);
            }
        }

        public TestRegistration TestRegistration { get; set; }

        #endregion

        #region Finish Tests

        public void Finish()
        {
            throw new NotImplementedException();
        }

        public void LogOut()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Helpers

        private static IEnumerable<MethodInfo> PrioritizedMethods(IEnumerable<MethodInfo> methiods)
        {
            var intialMethods = new Dictionary<MethodInfo, int>();
            foreach (var method in methiods)
            {
                var attribute = method.GetCustomAttributes(typeof(PriorityAttribute), true);
                if (attribute.Length == 0) continue;
                var priorityId = ((PriorityAttribute) attribute[0]).Priority;
                intialMethods.Add(method,priorityId);
            }

            return intialMethods.
                     OrderBy(pid => pid.Value).
                        Select(m => m.Key).
                            ToList();
        }
        #endregion
    }
}
