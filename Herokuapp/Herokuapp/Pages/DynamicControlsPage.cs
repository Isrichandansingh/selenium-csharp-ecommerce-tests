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
   public class DynamicControlsPage
    {

        private IWebDriver _driver;
        private WebDriverWait wait;

       public By _removeButton = By.XPath("//button[text()='Remove']");
       public By _addButton = By.XPath("//button[text()='Add']");
       public By _checkbox = By.Id("checkbox");

        public DynamicControlsPage(IWebDriver driver)
        {
            _driver = driver;
            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        public DynamicControlsPage(IWebDriver driver, WebDriverWait wait) : this(driver)
        {
        }

        public void ClickRemoveButton()
        {
            _driver.FindElement(_removeButton).Click();
        }

        public void ClickAddButton()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(_addButton)).Click();
            //_driver.FindElement(_addButton).Click();
        }

        public void IsCheckboxDisplayed()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(_checkbox));
            Assert.True(_driver.FindElement(_checkbox).Displayed, "Checkbox should be visible after being added.");
            
        }
    }
}