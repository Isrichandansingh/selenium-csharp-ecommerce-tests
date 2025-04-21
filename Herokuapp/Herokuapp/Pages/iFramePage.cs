using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herokuapp.Pages
{
   public class iFramePage
    {

        private IWebDriver _driver;

        private By _iFrame = By.Id("mce_0_ifr");
        private By _editor = By.Id("tinymce");

        public iFramePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public iFramePage(IWebDriver driver, WebDriverWait wait) : this(driver)
        {
        }

        public void SwitchToIframe()
        {
            _driver.SwitchTo().Frame(_driver.FindElement(_iFrame));
        }

        public void EnterTextInIFrame(string text)
        {
            _driver.FindElement(_editor).Clear();
            _driver.FindElement(_editor).SendKeys(text);
        }

        public string GetEditorText()
        {
            return _driver.FindElement(_editor).Text;
        }

        public void SwitchToDefaultContent()
        {
            _driver.SwitchTo().DefaultContent();
        }
    }
}
   
