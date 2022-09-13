using Automated_SpecFlow_Project.Hooks;
using OpenQA.Selenium;
using System;
using System.Globalization;
using TechTalk.SpecFlow;

namespace Automated_SpecFlow_Project.StepDefinitions
{
    [Binding]
    public class EmployeeStepDefinitions
    {
        private AutomationHooks hooks;

        public string firstName;
        public string middleName;
        public string lastName;

        // dependecy injection
        EmployeeStepDefinitions(AutomationHooks hooks)
        {
            this.hooks = hooks;
        }

        [When(@"I click on PIM")]
        public void WhenIClickOnPIM()
        {
            hooks.driver.FindElement(By.XPath("//span[text()='PIM']")).Click();
        }

        [When(@"I click on Add Employee")]
        public void WhenIClickOnAddEmployee()
        {
            hooks.driver.FindElement(By.XPath("//a[text()='Add Employee']")).Click();
        }

        [When(@"I fill the add employee section")]
        public void WhenIFillTheAddEmployeeSection(Table table)
        {
            firstName = table.Rows[0]["firstname"].ToString();
            middleName = table.Rows[0]["middlename"].ToString();
            lastName = table.Rows[0]["lastname"].ToString();
            string employeeId = table.Rows[0]["employee_id"].ToString();
            string toggleLoginDetails = table.Rows[0]["toggle_login_details"].ToString();
            string username = table.Rows[0]["username"].ToString();
            string password = table.Rows[0]["password"].ToString();
            string confirmPassword = table.Rows[0]["confirm_password"].ToString();
            string status = table.Rows[0]["status"].ToString();

            // firstname
            hooks.driver.FindElement(By.Name("firstName")).SendKeys(firstName);
            
            // middlename
            hooks.driver.FindElement(By.Name("middleName")).SendKeys(middleName);
            
            // lastname
            hooks.driver.FindElement(By.Name("lastName")).SendKeys(lastName);

            // employee id
            hooks.driver.FindElement(By.XPath("//label[text() = 'Employee Id']/following::input")).Clear();
            hooks.driver.FindElement(By.XPath("//label[text() = 'Employee Id']/following::input")).SendKeys(employeeId);

            // login details
            if (toggleLoginDetails.Equals("on"))
            {
                hooks.driver.FindElement(By.XPath("//span[contains(@class,'oxd-switch-input')]")).Click();

                // Username
                hooks.driver.FindElement(By.XPath("//label[contains(text(), 'Username')]/following::input")).SendKeys(username);
                
                // Password
                hooks.driver.FindElement(By.XPath("//label[contains(text(), 'Password')]/following::input")).SendKeys(password);

                // Confirm Password
                hooks.driver.FindElement(By.XPath("//label[contains(text(), 'Confirm Password')]/following::input")).SendKeys(confirmPassword);

                // status
                if (status.Equals("disabled"))
                {
                    hooks.driver.FindElement(By.XPath("//label[text() = 'Enabled']")).Click();
                }
                else
                {
                    hooks.driver.FindElement(By.XPath("//label[text() = 'Disabled']")).Click();
                }
            }

        }

        [When(@"I click on save employee")]
        public void WhenIClickOnSaveEmployee()
        {
            hooks.driver.FindElement(By.CssSelector("button[type='submit']")).Click();
        }

        [Then(@"I shopuld be navigated to personal details section with employee records")]
        public void ThenIShopuldBeNavigatedToPersonalDetailsSectionWithEmployeeRecords()
        {
            // Asserting First Name
            string actualFirstName = hooks.driver.FindElement(By.Name("firstName")).GetAttribute("value");
            Assert.Equal(firstName, actualFirstName);

            // Asserting Middle Name
            string actualMiddleName = hooks.driver.FindElement(By.Name("middleName")).GetAttribute("value");
            Assert.Equal(middleName, actualMiddleName);

            // Asserting Last Name
            string actualLastName = hooks.driver.FindElement(By.Name("lastName")).GetAttribute("value");
            Assert.Equal(lastName, actualLastName);
        }
    }
}
