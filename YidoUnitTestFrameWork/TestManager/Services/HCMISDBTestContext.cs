using System;
using System.Data.Entity;

namespace TestManager.Services
{
    public class HCMISDBTestContext: DbContext
    {
        //~ We will organize it soon ~//
        public HCMISDBTestContext():
            base(@"Data Source=192.168.2.58\SqlServer;Initial Catalog=HCMISW;Integrated Security=False;User ID=hcmist;Password=8qnRuvKFDG3")
        {
        }

        public DbSet<CodedUITestResult> CodedUITestResults { get; set; }

        public void InsertFake()
        {
            var codedTestResult = new CodedUITestResult
            {
                Project = "HCMIS WINDOWS",
                Build = "1.0.0.490",
                Module = "Receive",
                Description = "Check if Draft Receive page loads",
                Result = true,
                TestDate = DateTime.Now
            };
            CodedUITestResults.Add(codedTestResult);
            SaveChanges();
        }

        public void LogTestResult(string appVersion, string moduleName, string descriptionWithError, bool result)
        {
            var codedTestResult = new CodedUITestResult
            {
                Project = "HCMIS WINDOWS",
                Build = appVersion,
                Module = moduleName,
                Description = descriptionWithError,
                Result = result,
                TestDate = DateTime.Now
            };
            CodedUITestResults.Add(codedTestResult);
            SaveChanges();
        }
    }

    public class CodedUITestResult
    {
        public int CodedUITestResultID { get; set; }
        public string Project { get; set; }
        public string Build { get; set; }
        public string Module { get; set; }
        public string Description { get; set; }
        public bool Result { get; set; }
        public DateTime TestDate { get; set; }
    }
}
