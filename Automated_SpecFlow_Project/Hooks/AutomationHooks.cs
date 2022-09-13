﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace Automated_SpecFlow_Project.Hooks
{
    [Binding]
    public class AutomationHooks
    {
        public static IWebDriver driver;
        
        [AfterScenario]
        public void EndScenario()
        {
            if (driver != null)
                driver.Quit();
        }
    }

    
}
