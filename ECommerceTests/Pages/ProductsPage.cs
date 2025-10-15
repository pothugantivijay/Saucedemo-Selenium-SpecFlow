using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ECommerceTests.Pages
{
    public class ProductsPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private readonly IJavaScriptExecutor _js;

        private By ProductsTitle => By.ClassName("title");
        private By AddBackpackButton => By.Id("add-to-cart-sauce-labs-backpack");
        private By AddBikeLightButton => By.Id("add-to-cart-sauce-labs-bike-light");
        private By CartBadge => By.ClassName("shopping_cart_badge");
        private By CartIcon => By.ClassName("shopping_cart_link");

        public ProductsPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            _js = (IJavaScriptExecutor)driver;
        }

        public bool IsProductsPageDisplayed()
        {
            try
            {
                _wait.Until(d => d.Url.Contains("inventory.html"));
                _wait.Until(d => d.FindElement(ProductsTitle).Displayed);
                return _driver.FindElement(ProductsTitle).Text == "Products";
            }
            catch
            {
                return false;
            }
        }

        public void AddProductToCart(string productName)
        {
            // Wait for page to be fully loaded
            _wait.Until(d => d.FindElement(ProductsTitle).Displayed);
            
            // Extra time to let any popups appear
            Thread.Sleep(1500);
            
            // Try to dismiss any Chrome password popup by pressing Escape
            try
            {
                _driver.SwitchTo().ActiveElement().SendKeys(Keys.Escape);
                Thread.Sleep(300);
            }
            catch { }
            
            try
            {
                IWebElement button;
                
                switch (productName.ToLower())
                {
                    case "backpack":
                        button = _wait.Until(d => d.FindElement(AddBackpackButton));
                        // Use JavaScript click to bypass any overlay
                        _js.ExecuteScript("arguments[0].click();", button);
                        break;
                        
                    case "bike light":
                        button = _wait.Until(d => d.FindElement(AddBikeLightButton));
                        // Use JavaScript click to bypass any overlay
                        _js.ExecuteScript("arguments[0].click();", button);
                        break;
                        
                    default:
                        throw new ArgumentException($"Product '{productName}' is not supported");
                }
                
                // Wait for cart to update
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding product: {ex.Message}");
                throw;
            }
        }

        public string GetCartItemCount()
        {
            try
            {
                // Wait for cart badge to update
                Thread.Sleep(500);
                var badge = _driver.FindElement(CartBadge);
                return badge.Text;
            }
            catch (NoSuchElementException)
            {
                return "0";
            }
        }

        public void NavigateToCart()
        {
            _driver.FindElement(CartIcon).Click();
            _wait.Until(d => d.Url.Contains("cart.html"));
        }
    }
}