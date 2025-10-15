using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ECommerceTests.Pages
{
    public class CartPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        private By CartTitle => By.ClassName("title");
        private By CartItems => By.ClassName("cart_item");

        public CartPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public bool IsCartPageDisplayed()
        {
            try
            {
                // Wait for cart page to load
                _wait.Until(d => d.Url.Contains("cart.html"));
                _wait.Until(d => d.FindElement(CartTitle).Displayed);
                return _driver.FindElement(CartTitle).Text == "Your Cart";
            }
            catch
            {
                return false;
            }
        }

        public int GetCartItemCount()
        {
            try
            {
                return _driver.FindElements(CartItems).Count;
            }
            catch (NoSuchElementException)
            {
                return 0;
            }
        }
    }
}