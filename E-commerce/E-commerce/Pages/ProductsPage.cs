using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Pages
{
    public class ProductsPage
    {
        private readonly IWebDriver _driver;

        public ProductsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement Title => _driver.FindElement(By.ClassName("title"));
        private IWebElement SortDropdown => _driver.FindElement(By.ClassName("product_sort_container"));
        private IReadOnlyCollection<IWebElement> InventoryItems => _driver.FindElements(By.ClassName("inventory_item"));
        private IReadOnlyCollection<IWebElement> AddToCartButtons => _driver.FindElements(By.XPath("//button[contains(text(),'Add to cart')]"));
        private IWebElement CartBadge => _driver.FindElement(By.ClassName("shopping_cart_badge"));
        private IWebElement CartIcon => _driver.FindElement(By.ClassName("shopping_cart_link"));

        
        public string GetPageTitle()
        {
            return Title.Text;
        }

        public void SortBy(string option)
        {
            SortDropdown.Click();
            SortDropdown.FindElement(By.XPath($"//option[text()='{option}']")).Click();
        }

        public void AddFirstNItemsToCart(int count)
        {
            var buttons = AddToCartButtons.Take(count);
            foreach (var button in buttons)
            {
                button.Click();
            }
        }

        public int GetCartBadgeCount()
        {
            return int.Parse(CartBadge.Text);
        }

        public void ClickCartIcon()
        {
            CartIcon.Click();
        }

        
    }
}
