using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automated_SpecFlow_Project.Hooks
{
    [Binding]
    public class AutomationHooks
    {
        public IWebDriver driver;

        // Execution process - debug to understand the execution flow
        [BeforeTestRun]
        public static void Init()
        {
            // run only once at the beginning
        }

        [AfterTestRun]
        public static void End()
        {
            // run only once at the end
        }

        [BeforeFeature]
        public static void StartFeature()
        {
            // before every feature
        }


        [AfterFeature]
        public static void EndFeature()
        {
            // after every feature
        }

        [BeforeScenario]
        public void StartScenario()
        {
            // before every scenario
        }

        //runs after each scenario wether scenario passed or fail.  
        [AfterScenario]
        public void EndScenario()
        {
            // after every scenario

            if (driver != null)
                driver.Quit();
        }

        [BeforeStep]
        public void BeforeStep()
        {
            // before every step
        }

        [AfterStep]
        public void AfterStep()
        {
            // after every step
        }
    }
}
