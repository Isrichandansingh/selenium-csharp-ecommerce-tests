using AngleSharp.Dom;
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
    public class FileUploadPage
    {

        private IWebDriver _driver;
        private WebDriverWait wait;


        private By _fileUploadButton = By.Id("file-upload");
        private By _uploadButton = By.Id("file-submit");
        private By _fileUploadConfirmation = By.XPath("//h3");
        private readonly By uploadedMessage = By.Id("uploaded-files");

        private readonly By _uploadInput = By.Id("file-upload");      
       

        public FileUploadPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public FileUploadPage(IWebDriver driver, WebDriverWait wait) : this(driver)
        {
        }

       

        public bool IsFileUploaded()
        {
            return _driver.FindElement(_fileUploadConfirmation).Displayed;
        }
        public string GetUploadedText()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(uploadedMessage)).Text;
        }

        public void UploadFile(string fileName)
        {
           
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestFiles", fileName);

            Console.WriteLine("File path: " + filePath);

            if (!File.Exists(filePath))
                throw new FileNotFoundException("File not found: " + filePath);

            
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement uploadInput = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("file-upload")));

            uploadInput.SendKeys(filePath);
            
        }
    }
}
    

