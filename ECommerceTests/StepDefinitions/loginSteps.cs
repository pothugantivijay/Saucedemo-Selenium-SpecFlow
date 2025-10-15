using ECommerceTests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace ECommerceTests.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private readonly IWebDriver _driver;
        private readonly LoginPage _loginPage;
        private readonly ProductsPage _productsPage;

        public LoginSteps(IWebDriver driver)
        {
            _driver = driver;
            _loginPage = new LoginPage(_driver);
            _productsPage = new ProductsPage(_driver);
        }

        [Given(@"I navigate to the SauceDemo Login page")]
        [Given(@"I navigate to SauceDemo login page")]
        public void GivenINavigateToTheSauceDemoLoginPage()
        {
            _loginPage.NavigateTo("https://www.saucedemo.com/");
        }

        [Given(@"I login with username ""(.*)"" and password ""(.*)""")]
        public void GivenILoginWithUsernameAndPassword(string username, string password)
        {
            _loginPage.EnterUsername(username);
            _loginPage.EnterPassword(password);
            _loginPage.ClickLoginButton();
        }

        [When(@"I enter username ""(.*)""")]
        public void WhenIEnterUsername(string username)
        {
            _loginPage.EnterUsername(username);
        }

        [When(@"I enter password ""(.*)""")]
        public void WhenIEnterPassword(string password)
        {
            _loginPage.EnterPassword(password);
        }

        [When(@"I click the login button")]
        public void WhenIClickTheLoginButton()
        {
            _loginPage.ClickLoginButton();
        }

        [Then(@"I should see the products page")]
        public void ThenIShouldSeeTheProductsPage()
        {
            Assert.That(_productsPage.IsProductsPageDisplayed(), Is.True,
                "Products page should be displayed after successful login");
        }

        [Then(@"I should see an error message containing ""(.*)""")]
        public void ThenIShouldSeeAnErrorMessageContaining(string expectedText)
        {
            Assert.That(_loginPage.IsErrorMessageDisplayed(), Is.True,
                "Error message should be displayed");

            string actualMessage = _loginPage.GetErrorMessage();
            Assert.That(actualMessage, Does.Contain(expectedText),
                $"Error message should contain '{expectedText}'. Actual: '{actualMessage}'");
        }
    }
}