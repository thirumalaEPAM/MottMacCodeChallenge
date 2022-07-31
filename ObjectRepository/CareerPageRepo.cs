using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectRepository
{
    public class CareerPageRepo
    {

        public static By elementSearchKeyWord = By.XPath("//input[@id='search-career-search-temp']");
        public static By elementSearchIcon = By.XPath("//button[@class='jst-searchBox__button searchBox__button btn-default']");
        public static By elementViewJob = By.XPath("//a[text()='View Job']");
        public static By elementApplyBtn = By.XPath("//span[text()='Apply now']");
        //public static By elementApplyBtn = By.XPath("//a[text()='icon-button page-button apply-now b-careers-btn-small j-apply-btn'");
        public static By elementJobDesc = By.XPath("//h3[text()='Job Description']");
        public static By elementSearchResults = By.XPath("//div[@class='c-careers-search__list-item']");
    }
}
