using OpenQA.Selenium;

namespace Ecommerce.Pages
{
    public class CheckoutOverviewPage
    {
        private readonly IWebDriver _driver;

        public CheckoutOverviewPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement ItemTotal => _driver.FindElement(By.ClassName("summary_subtotal_label"));
        public IWebElement Tax => _driver.FindElement(By.ClassName("summary_tax_label"));
        public IWebElement Total => _driver.FindElement(By.ClassName("summary_total_label"));
        public IWebElement FinishButton => _driver.FindElement(By.Id("finish"));

        public bool IsItemTotalDisplayed()
        {
            return ItemTotal.Displayed;
        }

        public bool IsTaxDisplayed()
        {
            return Tax.Displayed;
        }

        public bool IsTotalDisplayed()
        {
            return Total.Displayed;
        }


        public void FinishOrder()
        {
            FinishButton.Click();
        }
    }
}
