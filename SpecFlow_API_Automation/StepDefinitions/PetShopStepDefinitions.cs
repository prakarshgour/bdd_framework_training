using RestSharp;
using SpecFlow_API_Automation.Hooks;
using System;
using TechTalk.SpecFlow;

namespace SpecFlow_API_Automation.StepDefinitions
{
    [Binding]
    public class PetShopStepDefinitions
    {
        [Given(@"I have base url '([^']*)' and resource '([^']*)'")]
        public void GivenIHaveBaseUrlAndResource(string baseUrl, string resourceUrl)
        {
            APIAutomationHooks.client = new RestClient(baseUrl+ resourceUrl);
        }

        [When(@"I do the Get Request")]
        public void WhenIDoTheGetRequest()
        {
            APIAutomationHooks.request = new RestRequest();
            APIAutomationHooks.response = APIAutomationHooks.client.Execute(APIAutomationHooks.request);
        }

        [Then(@"I should get a response as (.*)")]
        public void ThenIShouldGetAResponseAs(int expectedResponseCode)
        {
            int actualStatusCode = (int)APIAutomationHooks.response.StatusCode;
            Assert.Equal(expectedResponseCode, actualStatusCode);
        }

        [Then(@"I should get the details of pet in json format")]
        public void ThenIShouldGetTheDetailsOfPetInJsonFormat()
        {
            
        }

        [Then(@"I should get a message as '([^']*)'")]
        public void ThenIShouldGetAMessageAs(string expectedResponseMessage)
        {
            string actualResponseMessage = APIAutomationHooks.response.Content;
            Assert.Contains(expectedResponseMessage, actualResponseMessage);
        }

        [Given(@"I need to add api_key '([^']*)' in the header")]
        public void GivenINeedToAddApi_KeyInTheHeader(string apiKey)
        {
            APIAutomationHooks.client.AddDefaultHeader("api_key", apiKey);
        }

        [When(@"I do Delete Request")]
        public void WhenIDoDeleteRequest()
        {
            APIAutomationHooks.request = new RestRequest("", Method.Delete);
            APIAutomationHooks.response = APIAutomationHooks.client.Execute(APIAutomationHooks.request);
        }
    }
}
