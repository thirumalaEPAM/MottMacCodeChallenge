using ObjectRepository;
using System;
using TechTalk.SpecFlow;

namespace MMCodeChallengeBDD.StepDefinitions
{
    [Binding]
    public class LinksValidationStepDefinitions
    {
        List<string> _links=new List<string>();
        [Given(@"I can Navigate to MottMac Home Page ""([^""]*)""")]
        public void GivenICanNavigateToMottMacHomePage(string p0)
        {
            SingletonBaseClass.getDriverInstance().launchBrowser(p0);
        }

        [When(@"Get All the Links in Webpage")]
        public void WhenGetAllTheLinksInWebpage()
        {
            MyHooks.help.ButtonClick(HomePageRepo.elementSelecEnglish);
            MyHooks.help.WriteLog("Navigated MottMac Home page and Selected the requred language");
            _links = MyHooks.help.getAllLinks(HomePageRepo.elementAllLinks);
            _links=_links.Distinct().ToList();
            MyHooks.help.WriteLog("Number of distinct links on the webpage :  "+_links.Count);
        }

        [Then(@"Validate All the links in Webpage")]
        public void ThenValidateAllTheLinksInWebpage()
        {
            MyHooks.help.ValidateAllLinksonWebpage(_links);
            MyHooks.help.WriteLog("Validated the All links on Home Page!!!");
        }
    }
}
