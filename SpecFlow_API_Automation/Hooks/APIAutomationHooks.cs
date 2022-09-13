using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace SpecFlow_API_Automation.Hooks
{
    [Binding]
    public class APIAutomationHooks
    {
        public static RestClient client;
        public static RestRequest request;
        public static RestResponse response;
    }
}
