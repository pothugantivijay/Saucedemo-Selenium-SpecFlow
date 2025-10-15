using BoDi;
using ECommerceTests.Drivers;
using ECommerceTests.Utilities;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace ECommerceTests.Hooks
{
    [Binding]
    public class TestHooks
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private ExtentTest? _test;

        public TestHooks(IObjectContainer objectContainer, ScenarioContext scenarioContext)
        {
            _objectContainer = objectContainer;
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ExtentReportManager.GetExtent();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var driver = DriverManager.GetDriver();
            _objectContainer.RegisterInstanceAs<IWebDriver>(driver);

            var scenarioTitle = _scenarioContext.ScenarioInfo.Title;
            var tags = string.Join(", ", _scenarioContext.ScenarioInfo.Tags);
            _test = ExtentReportManager.CreateTest(scenarioTitle, $"Tags: {tags}");
            
            _test.Info("Test started");
        }

        [AfterStep]
        public void AfterStep()
        {
            if (_test == null) return;

            var stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            var stepText = _scenarioContext.StepContext.StepInfo.Text;

            if (_scenarioContext.TestError == null)
            {
                _test.Pass($"{stepType}: {stepText}");
            }
            else
            {
                _test.Fail($"{stepType}: {stepText}");
                _test.Fail(_scenarioContext.TestError.Message);
                
                // Capture screenshot on failure
                try
                {
                    var driver = _objectContainer.Resolve<IWebDriver>();
                    var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                    var screenshotPath = Path.Combine(Directory.GetCurrentDirectory(), "Reports", "Screenshots", 
                        $"{_scenarioContext.ScenarioInfo.Title.Replace(" ", "_")}_{DateTime.Now:yyyyMMdd_HHmmss}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(screenshotPath)!);
                    screenshot.SaveAsFile(screenshotPath);
                    
                    _test.AddScreenCaptureFromPath(screenshotPath);
                }
                catch
                {
                    // Ignore screenshot errors
                }
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (_test != null)
            {
                if (_scenarioContext.TestError != null)
                {
                    _test.Fail("Test failed");
                }
                else
                {
                    _test.Pass("Test completed successfully");
                }
            }

            DriverManager.QuitDriver();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            ExtentReportManager.FlushReport();
        }
    }
}