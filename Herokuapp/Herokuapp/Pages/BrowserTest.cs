using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herokuapp.Pages
{
    public class BrowserTest
    {

        private IWebDriver _driver;

        public BrowserTest()
        {
            // Initialize the WebDriver - Open Chrome Browser
            _driver = new ChromeDriver();
        }

        [Fact]
        public void OpenBrowserTest()
        {
            // Navigate to a URL
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");

            // Optionally, assert something on the page
            Assert.Contains("The Internet", _driver.Title);

            // Close the browser after test
            _driver.Quit();
        }
    }
}

