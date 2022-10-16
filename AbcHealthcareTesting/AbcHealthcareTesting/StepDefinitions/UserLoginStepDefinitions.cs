using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace AbcHealthcareTesting.StepDefinitions
{
    [Binding]
    public class UserLoginStepDefinitions
    {

        private String searchKeyword;
        private ChromeDriver chromeDriver;
        public UserLoginStepDefinitions() => chromeDriver = new ChromeDriver("C:\\Users\\sahil.shaikh\\Downloads\\chromedriver_win32");


        [Given(@"I navigate to the website")]
        public void GivenINavigateToTheWebsite()
        {
            chromeDriver.Navigate().GoToUrl("http://localhost:3000/");
            WebDriverWait wait = new WebDriverWait(chromeDriver, TimeSpan.FromMilliseconds(9500));
        }

        [Then(@"I click on Login button as I already have account")]
        public void ThenIClickOnLoginButtonAsIAlreadyHaveAccount()
        {
            WebDriverWait wait = new WebDriverWait(chromeDriver, TimeSpan.FromMilliseconds(9500));
            chromeDriver.FindElement(By.XPath("/html/body/div/div/div/form/a")).Click();
        }

        [Then(@"I enter Username and Password")]
        public void ThenIEnterUsernameAndPassword()
        {
            WebDriverWait wait = new WebDriverWait(chromeDriver, TimeSpan.FromMilliseconds(9500));
            chromeDriver.FindElement(By.XPath("/html/body/div/div/div/form/div[1]/div/input")).SendKeys("Rahul");
            chromeDriver.FindElement(By.XPath("/html/body/div/div/div/form/div[2]/div/input")).SendKeys("Rahul@12");
        }

        [Then(@"I click on Login")]
        public void ThenIClickOnLogin()
        {
            WebDriverWait wait = new WebDriverWait(chromeDriver, TimeSpan.FromMilliseconds(9500));
            chromeDriver.FindElement(By.XPath("/html/body/div/div/div/form/a[1]")).Click();
        }

        [Then(@"I should see Homepage of website")]
        public void ThenIShouldSeeHomepageOfWebsite()
        {
            WebDriverWait wait = new WebDriverWait(chromeDriver, TimeSpan.FromMilliseconds(9500));
        }
    }
}
