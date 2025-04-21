using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Ecommerce.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        public LoginPage(IWebDriver driver) => _driver = driver;

        public IWebElement UsernameInput => _driver.FindElement(By.Id("user-name"));
        public IWebElement PasswordInput => _driver.FindElement(By.Id("password"));
        public IWebElement LoginButton => _driver.FindElement(By.Id("login-button"));
        public IWebElement ErrorMessage => _driver.FindElement(By.CssSelector("[data-test='error']"));

        public IWebElement OkPopup => _driver.FindElement(By.XPath("//*[text()='OK]"));


        public void AreLoginElementsDisplayed()
        {
            Assert.True(UsernameInput.Displayed, "Username input is not visible");
            Assert.True(PasswordInput.Displayed, "Password input is not visible");
            Assert.True(LoginButton.Displayed, "Login button is not visible");
        }

        public void Login(string username, string password)
        {
            UsernameInput.Clear();
            UsernameInput.SendKeys(username);
            PasswordInput.Clear();
            PasswordInput.SendKeys(password);
            LoginButton.Click();

           


        }

        public void IsLoginErrorDisplayed()
        {
            Assert.True(ErrorMessage.Displayed, "Expected error message to be displayed when login fails.");
        }
    }
}
