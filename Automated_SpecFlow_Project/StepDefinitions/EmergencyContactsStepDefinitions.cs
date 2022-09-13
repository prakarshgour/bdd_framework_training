using Automated_SpecFlow_Project.Hooks;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace Automated_SpecFlow_Project.StepDefinitions
{
    [Binding]
    public class EmergencyContactsStepDefinitions
    {
        private AutomationHooks hooks;

        Table dataTable;

        // dependecy injection
        EmergencyContactsStepDefinitions(AutomationHooks hooks)
        {
            this.hooks = hooks;
        }

        [When(@"I click on My Info")]
        public void WhenIClickOnMyInfo()
        {
            hooks.driver.FindElement(By.XPath("//span[text()='My Info']")).Click();
        }

        [When(@"I click on Emergency Contacts")]
        public void WhenIClickOnEmergencyContacts()
        {
            hooks.driver.FindElement(By.XPath("//a[text() = 'Emergency Contacts']")).Click();
        }

        [When(@"I click on Add")]
        public void WhenIClickOnAdd()
        {
            hooks.driver.FindElement(By.XPath("//i[@class = 'oxd-icon bi-plus oxd-button-icon']")).Click();
        }

        [When(@"I fill emergency contact details")]
        public void WhenIFillEmergencyContactDetails(Table table)
        {
            dataTable = table;

            string name = table.Rows[0]["name"].ToString();
            string relationship = table.Rows[0]["relationship"].ToString();
            string homeTelephone = table.Rows[0]["home_telephone"].ToString();
            string mobile = table.Rows[0]["mobile"].ToString();
            string workTelephone = table.Rows[0]["work_telephone"].ToString();

            // Name
            hooks.driver.FindElement(By.XPath("//label[text() = 'Name']/following::input")).SendKeys(name);

            // Relationship
            hooks.driver.FindElement(By.XPath("//label[text() = 'Relationship']/following::input")).SendKeys(relationship);

            // Home Telephone
            hooks.driver.FindElement(By.XPath("//label[text() = 'Home Telephone']/following::input")).SendKeys(homeTelephone);

            // Mobile
            hooks.driver.FindElement(By.XPath("//label[text() = 'Mobile']/following::input")).SendKeys(mobile);

            // Work Telephone
            hooks.driver.FindElement(By.XPath("//label[text() = 'Work Telephone']/following::input")).SendKeys(workTelephone);
        }

        [When(@"I click on save contact")]
        public void WhenIClickOnSaveContact()
        {
            hooks.driver.FindElement(By.CssSelector("button[type = 'submit']")).Click();
        }

        [Then(@"I shopuld be navigated to view emergency contacts section")]
        public void ThenIShopuldBeNavigatedToViewEmergencyContactsSection()
        {
            string actualData = hooks.driver.FindElement(By.XPath("//div[@class='oxd-table']")).Text;
            string expectedName = dataTable.Rows[0]["name"];
            string expectedRelationship = dataTable.Rows[0]["relationship"];
            string expectedHomeTelephone = dataTable.Rows[0]["home_telephone"];
            string expectedMobile = dataTable.Rows[0]["mobile"];
            string expectedWorkTelephone = dataTable.Rows[0]["work_telephone"];

            Assert.Contains(expectedName, actualData);
            Assert.Contains(expectedRelationship, actualData);
            Assert.Contains(expectedHomeTelephone, actualData);
            Assert.Contains(expectedMobile, actualData);
            Assert.Contains(expectedWorkTelephone, actualData);
        }
    }
}
