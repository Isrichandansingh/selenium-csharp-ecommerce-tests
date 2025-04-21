using OpenQA.Selenium;
using TechTalk.SpecFlow;
using FluentAssertions;
using Herokuapp.Pages;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;
using OpenQA.Selenium.Interactions;
using YourNamespace.PageObjects;

namespace Herokuapp.StepDefinitions
{
    [Binding]
    public class HerokuappStepDefinitions
    {

        private readonly IWebDriver _driver;

       
        private readonly WebDriverWait _wait;

        private readonly FileUploadPage _fileUploadPage;
        private readonly iFramePage _framePage;
        private readonly AlertPage _alertsPage;
        private readonly DynamicControlsPage _dynamicControlsPage;
        private readonly InfiniteScrollPage _infiniteScrollPage;

        public HerokuappStepDefinitions(ScenarioContext scenarioContext)
        {
            _driver = (IWebDriver)scenarioContext["WebDriver"];
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _fileUploadPage = new FileUploadPage(_driver, _wait);
            _framePage = new iFramePage(_driver, _wait);
            _alertsPage = new AlertPage(_driver, _wait);
            _dynamicControlsPage = new DynamicControlsPage(_driver, _wait);
            _infiniteScrollPage = new InfiniteScrollPage(_driver, _wait);
        }


        [Given(@"I navigate to the File Upload page")]
        public void GivenINavigateToTheFileUploadPage()
        {
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/upload");
        }

        [When(@"I upload a file")]
        public void WhenIUploadAFile()
        {
            _fileUploadPage.UploadFile("sample.txt");
        }

        [Then(@"I should see the file upload confirmation message")]
        public void ThenIShouldSeeTheFileUploadConfirmationMessage()
        {
            _fileUploadPage.IsFileUploaded();
        }

        [Given(@"I navigate to the iFrame page")]
        public void GivenINavigateToTheIFramePage()
        {
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/iframe");
        }

        [When(@"I switch to the iframe and enter text ""([^""]*)""")]
        public void WhenISwitchToTheIframeAndEnterText(string p0)
        {
            //   _framePage.EnterTextInIFrame(text);
        }


        
        [Then(@"I should see the updated text in the editor")]
        public void ThenIShouldSeeTheUpdatedTextInTheEditor()
        {
            //_framePage.GetEditorText().Should().Contain("Hello Heroku");
        }
      


        [Given(@"I navigate to the JavaScript Alerts page")]
        public void GivenINavigateToTheJavaScriptAlertsPage()
        {
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");
        }

        [When(@"I click on JS Alert")]
        public void WhenIClickOnJSAlert()
        {
            _alertsPage.ClickAlertButton();
            _alertsPage.HandleSimpleAlert();
        }

        [Then(@"I should see the result message for Alert")]
        public void ThenIShouldSeeTheResultMessageForAlert()
        {
            _alertsPage.GetResultText();


        }

        [When(@"I click on JS Confirm Alert")]
        public void WhenIClickOnJSConfirmAlert()
        {
            _alertsPage.ClickAlertButton();
            _alertsPage.HandleSimpleAlert();
        }

        [Then(@"I should see the result message for Confirm")]
        public void ThenIShouldSeeTheResultMessageForConfirm()
        {
            _alertsPage.GetResultText();
        }

        [When(@"I click on Prompt Alert")]
        public void WhenIClickOnPromptAlert()
        {
            _alertsPage.ClickAlertButton();
            _alertsPage.HandleSimpleAlert();
        }

      

        [When(@"I enter the message ""([^""]*)"" in the prompt")]
        public void WhenIEnterTheMessageInThePrompt(string text)
        {
            _alertsPage.EnterTextinpromptAlert(text);
        }

        

        [Then(@"I should see the result message for Prompt")]
        public void ThenIShouldSeeTheResultMessageForPrompt()
        {
            _alertsPage.GetResultText();
        }

       

        [Given(@"I navigate to the Dynamic Controls page")]
        public void GivenINavigateToTheDynamicControlsPage()
        {
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_controls");
        }

        [When(@"I click Remove to remove the checkbox")]
        public void WhenIClickRemoveToRemoveTheCheckbox()
        {
            _dynamicControlsPage.ClickRemoveButton();


        }

        [Then(@"I should see the checkbox disappear")]
        public void ThenIShouldSeeTheCheckboxDisappear()
        {
            _dynamicControlsPage.ClickRemoveButton();

        }

        [When(@"I click Add to bring the checkbox back")]
        public void WhenIClickAddToBringTheCheckboxBack()
        {
            _dynamicControlsPage.ClickAddButton();

        }

        [Then(@"I should see the checkbox appear")]
        public void ThenIShouldSeeTheCheckboxAppear()
        {
            _dynamicControlsPage.IsCheckboxDisplayed();
        }

        [Given(@"I navigate to the Infinite Scroll page")]
        public void GivenINavigateToTheInfiniteScrollPage()
        {
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/infinite_scroll");
        }


        [When(@"I scroll to the bottom of the page")]
        public void WhenIScrollToTheBottomOfThePage()
        {

            _infiniteScrollPage.ScrollToBottom();
        }



        [Then(@"I should capture a screenshot at the bottom of the page")]
        public void ThenIShouldCaptureAScreenshotAtTheBottomOfThePage()
        {
            _infiniteScrollPage.CaptureScreenshot();

        }



       
    }
}
