using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ECommerceTests.Drivers
{
    public static class DriverManager
    {
        private static IWebDriver? _driver;

        public static IWebDriver GetDriver()
        {
            if (_driver == null)
            {
                var options = new ChromeOptions();
                
                // Disable password manager popup
                options.AddUserProfilePreference("credentials_enable_service", false);
                options.AddUserProfilePreference("profile.password_manager_enabled", false);
                
                // Other Chrome options
                options.AddArgument("--start-maximized");
                options.AddArgument("--disable-search-engine-choice-screen");
                options.AddArgument("--disable-save-password-bubble");
                
                // Disable notifications and popups
                options.AddArgument("--disable-notifications");
                options.AddArgument("--disable-infobars");
                options.AddExcludedArgument("enable-automation");
                options.AddAdditionalOption("useAutomationExtension", false);
                
                // Uncomment for headless mode
                // options.AddArgument("--headless");

                _driver = new ChromeDriver(options);
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }
            return _driver;
        }

        public static void QuitDriver()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver.Dispose();
                _driver = null;
            }
        }
    }
}