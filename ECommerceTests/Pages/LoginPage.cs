using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ECommerceTests.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        // Locators
        private By UsernameField => By.Id("user-name");
        private By PasswordField => By.Id("password");
        private By LoginButton => By.Id("login-button");
        private By ErrorMessage => By.CssSelector("[data-test='error']");

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void NavigateTo(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public void EnterUsername(string username)
        {
            _wait.Until(d => d.FindElement(UsernameField).Displayed);
            _driver.FindElement(UsernameField).Clear();
            _driver.FindElement(UsernameField).SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            _driver.FindElement(PasswordField).Clear();
            _driver.FindElement(PasswordField).SendKeys(password);
        }

        public void ClickLoginButton()
        {
            _driver.FindElement(LoginButton).Click();
            
            // Wait a moment after clicking login
            Thread.Sleep(1000);
        }

        public ProductsPage Login(string username, string password)
        {
            EnterUsername(username);
            EnterPassword(password);
            ClickLoginButton();
            return new ProductsPage(_driver);
        }

        public string GetErrorMessage()
        {
            _wait.Until(d => d.FindElement(ErrorMessage).Displayed);
            return _driver.FindElement(ErrorMessage).Text;
        }

        public bool IsErrorMessageDisplayed()
        {
            try
            {
                return _driver.FindElement(ErrorMessage).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}