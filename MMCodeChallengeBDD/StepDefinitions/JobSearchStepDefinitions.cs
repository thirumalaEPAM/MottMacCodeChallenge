using System;
using TechTalk.SpecFlow;
using ObjectRepository;
using NUnit.Framework;

namespace MMCodeChallengeBDD.StepDefinitions
{
    [Binding]
    public class JobSearchStepDefinitions
    {
        bool flag=false;
        [Given(@"I can Navigate to Mottmac career page ""([^""]*)""")]
        public void GivenICanNavigateToMottmacCareerPage(string p0)
        {
            SingletonBaseClass.getDriverInstance().launchBrowser(p0);


        }

        [Given(@"I can search with relavent job as (.*) in searchbox")]
        public void GivenICanSearchWithRelaventJobAsInSearchbox(string job)
        {
            MyHooks.help.ButtonClick(HomePageRepo.elementSelecEnglish);
            MyHooks.help.WriteLog("Navigated MottMac Home page and Selected the requred language");
            MyHooks.help.SendText(CareerPageRepo.elementSearchKeyWord, job);
            
        }

        [When(@"Click on Search icon")]
        public void WhenClickOnSearchIcon()
        {
           MyHooks.help.ButtonClick(CareerPageRepo.elementSearchIcon);
        }

        [Then(@"I can view the search results")]
        public void ThenICanViewTheSearchResults()
        {
            MyHooks.help.pageScrollDown();
            flag = MyHooks.help.CheckSearchResults(CareerPageRepo.elementSearchResults);
            if (flag)
            {
                MyHooks.help.WriteLog("Search results are available");
            }
            else
            {
                MyHooks.help.WriteLog("There is no Search results");
            }
            
        }

        [Then(@"click on View Job button")]
        public void ThenClickOnViewJobButton()
        {
            MyHooks.help.WriteLog("Click on View Job button on top search result");
            if (flag)
            {
                MyHooks.help.ButtonClick(CareerPageRepo.elementViewJob);
            }
        }


        [Then(@"I can view the Job details")]
        public void ThenICanViewTheJobDetails()
        {
            MyHooks.help.WriteLog("Validate the Job deatials");
            Assert.AreEqual(Constants.jd, MyHooks.help.GetText(CareerPageRepo.elementJobDesc));
            MyHooks.help.pageScrollDown();
            MyHooks.help.pageScrollDown();
            Assert.AreEqual(Constants.Apply, MyHooks.help.GetHiddentext(CareerPageRepo.elementApplyBtn));

            MyHooks.help.WriteLog("----Success-----");
        }
    }
}
