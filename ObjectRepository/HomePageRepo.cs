using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectRepository
{
    public class HomePageRepo
    {
        public static By elementSelecEnglish = By.XPath("//a[text()='Global (English)']");
        public static By elementAllLinks = By.TagName("a");
    }
}
