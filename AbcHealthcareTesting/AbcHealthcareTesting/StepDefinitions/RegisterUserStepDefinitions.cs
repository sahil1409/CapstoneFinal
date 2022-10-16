using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace AbcHealthcareTesting.StepDefinitions
{
    [Binding]
    public class RegisterUserStepDefinitions
    {

        private String searchKeyword;
        private ChromeDriver chromeDriver;
        public RegisterUserStepDefinitions() => chromeDriver = new ChromeDriver("C:\\Users\\sahil.shaikh\\Downloads\\chromedriver_win32");


        [Given(@"I navigate to website")]
        public void GivenINavigateToWebsite()
        {
            chromeDriver.Navigate().GoToUrl("http://localhost:3000/");
            WebDriverWait wait = new WebDriverWait(chromeDriver, TimeSpan.FromMilliseconds(9500));
        }

        [Then(@"I enter Username Email and Password")]
        public void ThenIEnterUsernameEmailAndPassword()
        {
            WebDriverWait wait = new WebDriverWait(chromeDriver, TimeSpan.FromMilliseconds(9500));
            chromeDriver.FindElement(By.XPath("/html/body/div/div/div/form/div[1]/div/input")).SendKeys("Rahul");
            chromeDriver.FindElement(By.XPath("/html/body/div/div/div/form/div[2]/div/input")).SendKeys("rahul123@test.com");
            chromeDriver.FindElement(By.XPath("/html/body/div/div/div/form/div[3]/div/input")).SendKeys("Rahul@12");
        }

        [Then(@"I click on Register button")]
        public void ThenIClickOnRegisterButton()
        {
            WebDriverWait wait = new WebDriverWait(chromeDriver, TimeSpan.FromMilliseconds(9500));
            chromeDriver.FindElement(By.XPath("/html/body/div/div/div/form/button")).Click();
        }
    }
}
