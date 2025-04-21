using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Pages
{
    public class CartPage
    {
        private readonly IWebDriver _driver;

        public CartPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IReadOnlyCollection<IWebElement> CartItems => _driver.FindElements(By.ClassName("cart_item"));
        public IWebElement CheckoutButton => _driver.FindElement(By.Id("checkout"));
        public IWebElement RemoveButton => _driver.FindElement(By.ClassName("cart_button"));



        public int GetCartItemCount()
        {
            int itemCount = CartItems.Count;
            Console.WriteLine($"Cart item count: {itemCount}");
            return CartItems.Count;
        }

        public void RemoveFirstItem()
        {
            RemoveButton.Click();
        }

        public void ClickCheckout()
        {
            CheckoutButton.Click();
        }
    }
}
