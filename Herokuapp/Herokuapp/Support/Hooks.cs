using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Herokuapp.Support
{
    [Binding]
    public class Hooks
    {
        public static ExtentReports _extent;
        private static ExtentTest _feature;
        private ExtentTest _scenario;
        private static ExtentSparkReporter _htmlReporter;
        private IWebDriver _driver;
        private ScenarioContext _scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            _htmlReporter = new ExtentSparkReporter("ExtentReport.html");
            _extent = new ExtentReports();
            _extent.AttachReporter(_htmlReporter);
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            if (_extent != null)
            {
                _feature = _extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
            }
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            if (_feature != null)
            {
                _scenario = _feature.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
            }

            new DriverManager().SetUpDriver(new ChromeConfig());
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();

            // Register WebDriver to ScenarioContext
            _scenarioContext["WebDriver"] = _driver;
        }


        [AfterScenario]
        public void AfterScenario()
        {
            _driver?.Quit();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            if (_extent != null)
            {
                _extent.Flush();
            }
        }
    }
}
