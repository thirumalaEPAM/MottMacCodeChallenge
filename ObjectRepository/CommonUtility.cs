using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectRepository
{
    public class CommonUtility
    {
        IWebDriver webdriver;

        /// <summary>
        /// Wait until Webelement visible /load using this method
        /// </summary>
        /// <param name="elt"></param>
        /// <returns></returns>
        public IWebElement WaitForElement(By elt)
        {

            WebDriverWait wait = new WebDriverWait(webdriver, TimeSpan.FromSeconds(5));
            return wait.Until(X => X.FindElement(elt));
        }

        /// <summary>
        /// get the element text
        /// </summary>
        /// <param name="elt"></param>
        /// <returns></returns>
        public String getElementText(By elt)
        {

            return WaitForElement(elt).Text.ToString();
        }

        /// <summary>
        /// send the text to element
        /// </summary>
        /// <param name="elt"></param>
        /// <param name="text"></param>
        public void SendText(By elt, String text)
        {

            WaitForElement(elt).SendKeys(text);

        }

        /// <summary>
        /// Enter the text using Actions Method
        /// </summary>
        /// <param name="elt"></param>
        /// <param name="location"></param>
        public void EnterLocations(By elt, String location)
        {
            Actions act = new Actions(webdriver);
            WaitForElement(elt).SendKeys(location);
            act.SendKeys(Keys.Down);
            act.SendKeys(Keys.Enter);
            act.Perform();

        }

        /// <summary>
        /// CLick on WebElement using this method
        /// </summary>
        /// <param name="elt"></param>
        public void ClickElement(By elt)
        {
            WaitForElement(elt).Click();
        }

        /// <summary>
        /// Page Scroll up using Javascript executor
        /// </summary>
        /// <param name="elt"></param>
        public void pageScroll(By elt)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)webdriver;
            js.ExecuteScript("window.scrollBy(0, 250)", "");

        }       

        /// <summary>
        /// List element click
        /// </summary>
        /// <param name="by"></param>
        public void ClickListWebElements(By by)
        {
            IList<IWebElement> elts = webdriver.FindElements(by);
            elts[elts.Count - 1].Click();
        }

        /// <summary>
        /// This Method ,count the noumber of elements in List and returns the list count
        /// </summary>
        /// <param name="by"></param>
        /// <returns></returns>
        public int CountElements(By by)
        {
            IList<IWebElement> elts = webdriver.FindElements(by);
            return elts.Count;
        }

        /// <summary>
        /// Select the Dropdown value
        /// </summary>
        /// <param name="by"></param>
        /// <param name="value"></param>
        public void SelectValue(By by, string value)
        {
            SelectElement sel = new SelectElement(WaitForElement(by));
            sel.SelectByText(value);

        }

        /// <summary>
        /// Scroll the page and Click on the required element
        /// </summary>
        /// <param name="elt"></param>
        public void pageScrollandClick(By elt)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)webdriver;
            js.ExecuteScript("arguments[0].click();", webdriver.FindElement(elt));

        }

        /// <summary>
        /// Click the element using Mouse Actions
        /// </summary>
        /// <param name="by"></param>
        public void Mouseclick(By by)
        {
            Actions act = new Actions(webdriver);
            act.MoveToElement(WaitForElement(by)).Click();
            act.Perform();

        }
        public CommonUtility(IWebDriver driver) { this.webdriver = driver; }
    }
}
