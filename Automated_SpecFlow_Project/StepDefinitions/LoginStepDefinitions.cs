using Automated_SpecFlow_Project.Hooks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace Automated_SpecFlow_Project.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        [Given(@"I have a browser with orangehrm page")]
        public void GivenIHaveABrowserWithOrangehrmPage()
        {
            AutomationHooks.driver = new ChromeDriver();
            AutomationHooks.driver.Manage().Window.Maximize();
            AutomationHooks.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            AutomationHooks.driver.Url = "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login";
        }

        [When(@"I enter username as '([^']*)'")]
        public void WhenIEnterUsernameAs(string username)
        {
            AutomationHooks.driver.FindElement(By.Name("username")).SendKeys(username);
        }

        [When(@"I enter password as '([^']*)'")]
        public void WhenIEnterPasswordAs(string password)
        {
            AutomationHooks.driver.FindElement(By.Name("password")).SendKeys(password);
        }

        [When(@"I click on login")]
        public void WhenIClickOnLogin()
        {
            AutomationHooks.driver.FindElement(By.CssSelector("button[type='submit']")).Click();
        }

        [Then(@"I should be navigated to '([^']*)' dashboard screen")]
        public void ThenIShouldBeNavigatedToDashboardScreen(string expectedValue)
        {
            Console.WriteLine(expectedValue);
        }

        [Then(@"I should get error message as '([^']*)'")]
        public void ThenIShouldGetErrorMessageAs(string expectedError)
        {
            Console.WriteLine(expectedError);
        }

    }
}
