using ECommerceTests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace ECommerceTests.StepDefinitions
{
    [Binding]
    public class ShoppingCartSteps
    {
        private readonly IWebDriver _driver;
        private readonly ProductsPage _productsPage;
        private readonly CartPage _cartPage;

        public ShoppingCartSteps(IWebDriver driver)
        {
            _driver = driver;
            _productsPage = new ProductsPage(driver);
            _cartPage = new CartPage(driver);
        }

        [When(@"I add ""(.*)"" to the cart")]
        public void WhenIAddToTheCart(string productName)
        {
            _productsPage.AddProductToCart(productName);
        }

        [When(@"I navigate to the cart")]
        public void WhenINavigateToTheCart()
        {
            _productsPage.NavigateToCart();
        }

        [Then(@"the cart badge should show ""(.*)""")]
        public void ThenTheCartBadgeShouldShow(string expectedCount)
        {
            // Give extra time for badge to update after multiple additions
            Thread.Sleep(1000);
            
            string actualCount = _productsPage.GetCartItemCount();
            Assert.That(actualCount, Is.EqualTo(expectedCount),
                $"Cart badge should show '{expectedCount}' but shows '{actualCount}'");
        }

        [Then(@"I should see the cart page")]
        public void ThenIShouldSeeTheCartPage()
        {
            Assert.That(_cartPage.IsCartPageDisplayed(), Is.True,
                "Cart page should be displayed");
        }

        [Then(@"the cart should contain (.*) item")]
        public void ThenTheCartShouldContainItem(int expectedCount)
        {
            int actualCount = _cartPage.GetCartItemCount();
            Assert.That(actualCount, Is.EqualTo(expectedCount),
                $"Cart should contain {expectedCount} item(s) but contains {actualCount}");
        }
    }
}