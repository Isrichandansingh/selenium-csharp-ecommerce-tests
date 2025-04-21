using OpenQA.Selenium;

namespace Ecommerce.Pages
{
    public class CheckoutPage
    {
        private readonly IWebDriver _driver;

        public CheckoutPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement FirstName => _driver.FindElement(By.Id("first-name"));
        public IWebElement LastName => _driver.FindElement(By.Id("last-name"));
        public IWebElement ZipCode => _driver.FindElement(By.Id("postal-code"));
        public IWebElement ContinueButton => _driver.FindElement(By.Id("continue"));

        public void EnterFirstName(string firstName)
        {
            FirstName.Clear();
            FirstName.SendKeys(firstName);
        }

        public void EnterLastName(string lastName)
        {
            LastName.Clear();
            LastName.SendKeys(lastName);
        }

        public void EnterZipCode(string zipCode)
        {
            ZipCode.Clear();
            ZipCode.SendKeys(zipCode);
        }

        public void ContinueCheckout()
        {
            ContinueButton.Click();
        }

        public void FillCheckoutDetails(string firstName, string lastName, string zipCode)
        {
            EnterFirstName(firstName);
            EnterLastName(lastName);
            EnterZipCode(zipCode);
            ContinueCheckout();
        }
    }
}
