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
        public string firstName;
        public string middleName;
        public string lastName;

        [When(@"I click on PIM")]
        public void WhenIClickOnPIM()
        {
            AutomationHooks.driver.FindElement(By.XPath("//span[text()='PIM']")).Click();
        }

        [When(@"I click on Add Employee")]
        public void WhenIClickOnAddEmployee()
        {
            AutomationHooks.driver.FindElement(By.XPath("//a[text()='Add Employee']")).Click();
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
            AutomationHooks.driver.FindElement(By.Name("firstName")).SendKeys(firstName);
            
            // middlename
            AutomationHooks.driver.FindElement(By.Name("middleName")).SendKeys(middleName);
            
            // lastname
            AutomationHooks.driver.FindElement(By.Name("lastName")).SendKeys(lastName);

            // employee id
            AutomationHooks.driver.FindElement(By.XPath("//label[text() = 'Employee Id']/following::input")).Clear();
            AutomationHooks.driver.FindElement(By.XPath("//label[text() = 'Employee Id']/following::input")).SendKeys(employeeId);

            // login details
            if (toggleLoginDetails.Equals("on"))
            {
                AutomationHooks.driver.FindElement(By.XPath("//span[contains(@class,'oxd-switch-input')]")).Click();

                // Username
                AutomationHooks.driver.FindElement(By.XPath("//label[contains(text(), 'Username')]/following::input")).SendKeys(username);
                
                // Password
                AutomationHooks.driver.FindElement(By.XPath("//label[contains(text(), 'Password')]/following::input")).SendKeys(password);

                // Confirm Password
                AutomationHooks.driver.FindElement(By.XPath("//label[contains(text(), 'Confirm Password')]/following::input")).SendKeys(confirmPassword);

                // status
                if (status.Equals("disabled"))
                {
                    AutomationHooks.driver.FindElement(By.XPath("//label[text() = 'Enabled']")).Click();
                }
                else
                {
                    AutomationHooks.driver.FindElement(By.XPath("//label[text() = 'Disabled']")).Click();
                }
            }

        }

        [When(@"I click on save employee")]
        public void WhenIClickOnSaveEmployee()
        {
            AutomationHooks.driver.FindElement(By.CssSelector("button[type='submit']")).Click();
        }

        [Then(@"I shopuld be navigated to personal details section with employee records")]
        public void ThenIShopuldBeNavigatedToPersonalDetailsSectionWithEmployeeRecords()
        {
            // Asserting First Name
            string actualFirstName = AutomationHooks.driver.FindElement(By.Name("firstName")).GetAttribute("value");
            Assert.Equal(firstName, actualFirstName);

            // Asserting Middle Name
            string actualMiddleName = AutomationHooks.driver.FindElement(By.Name("middleName")).GetAttribute("value");
            Assert.Equal(middleName, actualMiddleName);

            // Asserting Last Name
            string actualLastName = AutomationHooks.driver.FindElement(By.Name("lastName")).GetAttribute("value");
            Assert.Equal(lastName, actualLastName);
        }
    }
}
