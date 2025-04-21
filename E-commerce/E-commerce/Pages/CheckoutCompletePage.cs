using OpenQA.Selenium;

namespace Ecommerce.Pages
{
    public class CheckoutCompletePage
    {
        private readonly IWebDriver _driver;

        public CheckoutCompletePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement ConfirmationHeader => _driver.FindElement(By.ClassName("complete-header"));
        public IWebElement BackHomeButton => _driver.FindElement(By.Id("back-to-products"));

        public string GetConfirmationMessage()
        {
            return ConfirmationHeader.Text;
        }

        public void ClickBackToHome()
        {
            BackHomeButton.Click();
        }
    }
}
