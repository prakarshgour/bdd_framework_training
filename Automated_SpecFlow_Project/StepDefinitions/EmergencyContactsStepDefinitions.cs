using Automated_SpecFlow_Project.Hooks;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace Automated_SpecFlow_Project.StepDefinitions
{
    [Binding]
    public class EmergencyContactsStepDefinitions
    {
        public string name;
        public string relationship;
        public string homeTelephone;
        public string mobile;
        public string workTelephone;

        [When(@"I click on My Info")]
        public void WhenIClickOnMyInfo()
        {
            AutomationHooks.driver.FindElement(By.XPath("//span[text()='My Info']")).Click();
        }

        [When(@"I click on Emergency Contacts")]
        public void WhenIClickOnEmergencyContacts()
        {
            AutomationHooks.driver.FindElement(By.XPath("//a[text() = 'Emergency Contacts']")).Click();
        }

        [When(@"I click on Add")]
        public void WhenIClickOnAdd()
        {
            AutomationHooks.driver.FindElement(By.XPath("//i[@class = 'oxd-icon bi-plus oxd-button-icon']")).Click();
        }

        [When(@"I fill emergency contact details")]
        public void WhenIFillEmergencyContactDetails(Table table)
        {
            name = table.Rows[0]["name"].ToString();
            relationship = table.Rows[0]["relationship"].ToString();
            homeTelephone = table.Rows[0]["home_telephone"].ToString();
            mobile = table.Rows[0]["mobile"].ToString();
            workTelephone = table.Rows[0]["work_telephone"].ToString();

            // Name
            AutomationHooks.driver.FindElement(By.XPath("//label[text() = 'Name']/following::input")).SendKeys(name);

            // Relationship
            AutomationHooks.driver.FindElement(By.XPath("//label[text() = 'Relationship']/following::input")).SendKeys(relationship);

            // Home Telephone
            AutomationHooks.driver.FindElement(By.XPath("//label[text() = 'Home Telephone']/following::input")).SendKeys(homeTelephone);

            // Mobile
            AutomationHooks.driver.FindElement(By.XPath("//label[text() = 'Mobile']/following::input")).SendKeys(mobile);

            // Work Telephone
            AutomationHooks.driver.FindElement(By.XPath("//label[text() = 'Work Telephone']/following::input")).SendKeys(workTelephone);
        }

        [When(@"I click on save contact")]
        public void WhenIClickOnSaveContact()
        {
            AutomationHooks.driver.FindElement(By.CssSelector("button[type = 'submit']")).Click();
        }

        [Then(@"I shopuld be navigated to view emergency contacts section")]
        public void ThenIShopuldBeNavigatedToViewEmergencyContactsSection()
        {
            
        }
    }
}
