using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace AbcHealthcareTesting.StepDefinitions
{
    [Binding]
    public class OrderConfirmationStepDefinitions
    {

        private String searchKeyword;
        private ChromeDriver chromeDriver;
        public OrderConfirmationStepDefinitions() => chromeDriver = new ChromeDriver("C:\\Users\\sahil.shaikh\\Downloads\\chromedriver_win32");


        [Given(@"I navigate to  website")]
        public void GivenINavigateToWebsite()
        {
            chromeDriver.Navigate().GoToUrl("http://localhost:3000/");
            WebDriverWait wait = new WebDriverWait(chromeDriver, TimeSpan.FromMilliseconds(9500));
        }

        [Then(@"I click on Login button as I already have an account")]
        public void ThenIClickOnLoginButtonAsIAlreadyHaveAnAccount()
        {
            WebDriverWait wait = new WebDriverWait(chromeDriver, TimeSpan.FromMilliseconds(9500));
            chromeDriver.FindElement(By.XPath("/html/body/div/div/div/form/a")).Click();
        }

        [Then(@"I enter an Username and Password")]
        public void ThenIEnterAnUsernameAndPassword()
        {
            WebDriverWait wait = new WebDriverWait(chromeDriver, TimeSpan.FromMilliseconds(9500));
            chromeDriver.FindElement(By.XPath("/html/body/div/div/div/form/div[1]/div/input")).SendKeys("Rahul");
            chromeDriver.FindElement(By.XPath("/html/body/div/div/div/form/div[2]/div/input")).SendKeys("Rahul@12");
        }

        [When(@"I click on Login")]
        public void WhenIClickOnLogin()
        {
            WebDriverWait wait = new WebDriverWait(chromeDriver, TimeSpan.FromMilliseconds(9500));
            chromeDriver.FindElement(By.XPath("/html/body/div/div/div/form/a[1]")).Click();
        }

        [Then(@"I should see homepage of website")]
        public void ThenIShouldSeeHomepageOfWebsite()
        {
            WebDriverWait wait = new WebDriverWait(chromeDriver, TimeSpan.FromMilliseconds(9500));
        }

        [Then(@"I click on Inventory")]
        public void ThenIClickOnInventory()
        {
            WebDriverWait wait = new WebDriverWait(chromeDriver, TimeSpan.FromMilliseconds(9500));
            chromeDriver.FindElement(By.XPath("/html/body/div/header/div/div[2]/ul/a")).Click();
        }

        [Then(@"I add some medicines to Cart")]
        public void ThenIAddSomeMedicinesToCart()
        {
            WebDriverWait wait = new WebDriverWait(chromeDriver, TimeSpan.FromMilliseconds(9500));
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            chromeDriver.FindElement(By.XPath("/html/body/div/div/div/div[1]/div/div[3]/button")).Click();
            chromeDriver.FindElement(By.XPath("/html/body/div/div/div/div[1]/div/div[3]/button")).Click();
            chromeDriver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/div[3]/button")).Click();
            chromeDriver.FindElement(By.XPath("/html/body/div/div/div/div[1]/div/div[3]/button")).Click();
            chromeDriver.FindElement(By.XPath("/html/body/div/div/div/div[1]/div/div[3]/button")).Click();
            chromeDriver.FindElement(By.XPath("/html/body/div/div/div/div[1]/div/div[3]/button")).Click();
        }

        [When(@"I click on Cart icon")]
        public void WhenIClickOnCartIcon()
        {
            WebDriverWait wait = new WebDriverWait(chromeDriver, TimeSpan.FromMilliseconds(9500));
            chromeDriver.FindElement(By.XPath("/html/body/div/header/div/div[2]/a")).Click();
        }

        [Then(@"I should see Cart page")]
        public void ThenIShouldSeeCartPage()
        {
            WebDriverWait wait = new WebDriverWait(chromeDriver, TimeSpan.FromMilliseconds(9500));
        }

        [When(@"I click on Checkout")]
        public void WhenIClickOnCheckout()
        {
            WebDriverWait wait = new WebDriverWait(chromeDriver, TimeSpan.FromMilliseconds(9500));
            chromeDriver.FindElement(By.XPath("/html/body/div/div/div[2]/div[2]/a")).Click();
        }

        [Then(@"Order should be confirmed")]
        public void ThenOrderShouldBeConfirmed()
        {
            WebDriverWait wait = new WebDriverWait(chromeDriver, TimeSpan.FromMilliseconds(9500));
        }
    }
}
