using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace ECommerceTests.Utilities
{
    public class ExtentReportManager
    {
        private static ExtentReports? _extent;
        private static ExtentTest? _test;

        public static ExtentReports GetExtent()
        {
            if (_extent == null)
            {
                var reportPath = Path.Combine(Directory.GetCurrentDirectory(), "Reports", "TestReport.html");
                Directory.CreateDirectory(Path.GetDirectoryName(reportPath)!);

                var htmlReporter = new ExtentSparkReporter(reportPath);
                htmlReporter.Config.DocumentTitle = "SauceDemo Test Report";
                htmlReporter.Config.ReportName = "Automation Test Results";
                htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Dark;

                _extent = new ExtentReports();
                _extent.AttachReporter(htmlReporter);
                _extent.AddSystemInfo("Application", "SauceDemo");
                _extent.AddSystemInfo("Environment", "QA");
                _extent.AddSystemInfo("User", Environment.UserName);
            }
            return _extent;
        }

        public static ExtentTest CreateTest(string testName, string description = "")
        {
            _test = GetExtent().CreateTest(testName, description);
            return _test;
        }

        public static ExtentTest GetTest()
        {
            return _test!;
        }

        public static void FlushReport()
        {
            _extent?.Flush();
        }
    }
}