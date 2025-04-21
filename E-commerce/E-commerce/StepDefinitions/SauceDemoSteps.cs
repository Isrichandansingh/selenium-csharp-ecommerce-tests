using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;


namespace Ecommerce.StepDefinitions
{
    [Binding]
    public class SauceDemoSteps
    {
        private readonly IWebDriver _driver;
        private readonly Pages.LoginPage _loginPage;
        private readonly Pages.ProductsPage _productsPage;
        private readonly Pages.CartPage _cartPage;
        private readonly Pages.CheckoutPage _checkoutPage;
        private readonly Pages.CheckoutOverviewPage _overviewPage;
        private readonly Pages.CheckoutCompletePage _completePage;

        public SauceDemoSteps(IWebDriver driver)
        {
            _driver = driver;
            _loginPage = new Pages.LoginPage(_driver);
            _productsPage = new Pages.ProductsPage(_driver);
            _cartPage = new Pages.CartPage(_driver);
            _checkoutPage = new Pages.CheckoutPage(_driver);
            _overviewPage = new Pages.CheckoutOverviewPage(_driver);
            _completePage = new Pages.CheckoutCompletePage(_driver);
        }

        [Given(@"I launch the SauceDemo site")]
        public void GivenILaunchTheSauceDemoSite()
        {
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [Then(@"I validate the login page elements")]
        public void ThenIValidateTheLoginPageElements()
        {
            _loginPage.AreLoginElementsDisplayed();
        }

        [When(@"I try logging in with invalid credentials")]
        public void WhenITryLoggingInWithInvalidCredentials()
        {
            _loginPage.Login("test", "test1234");
        }

        [Then(@"I should see an error message")]
        public void ThenIShouldSeeAnErrorMessage()
        {
            _loginPage.IsLoginErrorDisplayed();
        }

        [When(@"I log in with valid credentials")]
        public void WhenILogInWithValidCredentials()
        {
            _loginPage.Login("standard_user", "secret_sauce");
            //using Explicit Wait
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.ClassName("title")).Displayed);

        }

        [When(@"I sort products by ""(.*)""")]
        public void WhenISortProductsBy(string sortOption)
        {
            _productsPage.SortBy(sortOption);
        }

        [When(@"I add two items to the cart")]
        public void WhenIAddTwoItemsToTheCart()
        {
            _productsPage.AddFirstNItemsToCart(2);
        }

        [Then(@"I verify the cart badge count is (.*)")]
        public void ThenIVerifyTheCartBadgeCountIs(int expectedCount)
        {
            int actualCount = _productsPage.GetCartBadgeCount();
            Assert.Equal(expectedCount, actualCount);
        }

        [When(@"I go to the cart page")]
        public void WhenIGoToTheCartPage()
        {
            _productsPage.ClickCartIcon();
        }

        [Then(@"I verify both items are listed")]
        public void ThenIVerifyBothItemsAreListed()
        {
            int itemCount = _cartPage.GetCartItemCount();
            Assert.Equal(2, itemCount);
        }

        [When(@"I remove one item from the cart")]
        public void WhenIRemoveOneItemFromTheCart()
        {
            _cartPage.RemoveFirstItem();
        }

        [Then(@"I verify the item is removed")]
        public void ThenIVerifyTheItemIsRemoved()
        {
            int itemCount = _cartPage.GetCartItemCount();
            Assert.Equal(1, itemCount);
        }

        [When(@"I proceed to checkout and fill in personal details")]
        public void WhenIProceedToCheckoutAndFillInPersonalDetails()
        {
            _cartPage.ClickCheckout();
            _checkoutPage.FillCheckoutDetails("test", "Demo", "123456");
        }

        [Then(@"I verify the order summary and finish the purchase")]
        public void ThenIVerifyTheOrderSummaryAndFinishThePurchase()
        {
            Assert.True(_overviewPage.IsItemTotalDisplayed(), "Item Total is not displayed.");
            Assert.True(_overviewPage.IsTaxDisplayed(), "Tax is not displayed.");
            Assert.True(_overviewPage.IsTotalDisplayed(), "Total is not displayed.");

            _overviewPage.FinishOrder();
        }

        [Then(@"I should see the confirmation message")]
        public void ThenIShouldSeeTheConfirmationMessage()
        {
            _completePage.GetConfirmationMessage().Should().Be("Thank you for your order!");
        }

        [When(@"I click back to products")]
        public void WhenIClickBackToProducts()
        {
            _completePage.ClickBackToHome();
        }

        [Then(@"I should land on the products page")]
        public void ThenIShouldLandOnTheProductsPage()
        {
            _productsPage.GetPageTitle().Should().Be("Products");
        }
    }
}
