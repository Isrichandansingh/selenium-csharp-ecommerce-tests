using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herokuapp.Pages
{
    public class AlertPage
    {
        private IWebDriver _driver;

        private By _alertButton = By.XPath("//button[text()='Click for JS Alert']");
        private By _confirmButton = By.XPath("//button[text()='Click for JS Confirm']");
        private By _promptButton = By.XPath("//button[text()='Click for JS Prompt']");
        private By _result = By.Id("result");

        public AlertPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public AlertPage(IWebDriver driver, WebDriverWait wait) : this(driver)
        {
        }

        public void ClickAlertButton()
        {
            _driver.FindElement(_alertButton).Click();
        }

        public void HandleSimpleAlert()
        {
            IAlert alert = _driver.SwitchTo().Alert();
            Console.WriteLine("Alert Text: " + alert.Text);
            alert.Accept(); 
        }
        public void ClickonokButton()
        {
            _driver.SwitchTo().Alert().Accept();
        }
        public void ClickConfirmButton()
        {
            _driver.FindElement(_confirmButton).Click();
        }

        public void ClickPromptButton()
        {
            _driver.FindElement(_promptButton).Click();
        }

        public void EnterTextinpromptAlert(string text)
        {
            IAlert alert = _driver.SwitchTo().Alert();
            alert.SendKeys(text);
            alert.Accept();


        }
        public string GetResultText()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            return wait.Until(driver => driver.FindElement(_result)).Text;
        }
    }
}
