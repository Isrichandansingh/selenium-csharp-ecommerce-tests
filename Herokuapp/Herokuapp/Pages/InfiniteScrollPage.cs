using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;


namespace YourNamespace.PageObjects
{
    public class InfiniteScrollPage
    {
        private IWebDriver _driver;

        public By _scrollableArea = By.Id("scrollable-area");

        public InfiniteScrollPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public InfiniteScrollPage(IWebDriver driver, WebDriverWait wait) : this(driver)
        {
        }

        public void ScrollToBottom()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;

            for (int i = 0; i < 5; i++)
            {
                js.ExecuteScript("window.scrollBy(0,1000)");

            }


        }

        public void CaptureScreenshot()
        {
            Screenshot screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Screenshots");
            Directory.CreateDirectory(folderPath); 

            
            string fileName = $"screenshot_{DateTime.Now:yyyyMMdd_HHmmss}.png";
            string filePath = Path.Combine(folderPath, fileName);

            // Save the screenshot to file
            SaveScreenshotToFile(screenshot, filePath);
        }
        static void SaveScreenshotToFile(Screenshot screenshot, string filePath)
        {
            File.WriteAllBytes(filePath, screenshot.AsByteArray);
        }
    }
}
