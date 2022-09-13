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
        private AutomationHooks hooks;

        // dependency injection
        LoginStepDefinitions(AutomationHooks hooks)
        {
            this.hooks = hooks;
        }

        [Given(@"I have a browser with orangehrm page")]
        public void GivenIHaveABrowserWithOrangehrmPage()
        {
            hooks.driver = new ChromeDriver();
            hooks.driver.Manage().Window.Maximize();
            hooks.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            hooks.driver.Url = "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login";
        }

        [When(@"I enter username as '([^']*)'")]
        public void WhenIEnterUsernameAs(string username)
        {
            hooks.driver.FindElement(By.Name("username")).SendKeys(username);
        }

        [When(@"I enter password as '([^']*)'")]
        public void WhenIEnterPasswordAs(string password)
        {
            hooks.driver.FindElement(By.Name("password")).SendKeys(password);
        }

        [When(@"I click on login")]
        public void WhenIClickOnLogin()
        {
            hooks.driver.FindElement(By.CssSelector("button[type='submit']")).Click();
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
