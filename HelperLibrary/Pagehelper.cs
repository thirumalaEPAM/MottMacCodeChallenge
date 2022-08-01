using ObjectRepository;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HelperLibrary
{
    public class Pagehelper
    {
        IWebDriver webdriver;
        CommonUtility Commonobj;

        /// <summary>
        /// Perform the Button click action using this method
        /// </summary>
        /// <param name="by"></param>
        public void ButtonClick(By by)
        {
            Commonobj.ClickElement(by);
        }
        public void waitforpageLoad()
        {
            System.Threading.Thread.Sleep(5000);
        }

        /// <summary>
        /// Send the text to webelement
        /// </summary>
        /// <param name="by"></param>
        /// <param name="text"></param>
        public void SendText(By by, string text)
        {

            Commonobj.SendText(by, text);
        }

        /// <summary>
        /// Get the Webelement text by using this method
        /// </summary>
        /// <param name="by"></param>
        /// <returns></returns>

        public string GetText(By by)
        {
            try { return Commonobj.getElementText(by); }
            catch { return "NotMatch"; }

        }

        /// <summary>
        /// Get the Hidden text using this method
        /// </summary>
        /// <param name="by"></param>
        /// <returns></returns>
        public string GetHiddentext(By by)
        {
            
            IJavaScriptExecutor js = (IJavaScriptExecutor)webdriver;
           var hiddenText= js.ExecuteScript("return arguments[0].innerHTML;",Commonobj.WaitForElement(by));
            
            return hiddenText.ToString();
        }

        /// <summary>
        /// Get All the links on the Webpage
        /// </summary>
        /// <param name="by"></param>
        /// <returns></returns>
        public List<string> getAllLinks(By by)
        {
            IList<IWebElement> links = webdriver.FindElements(By.TagName("a"));
            List<string> refLinks = new List<string>();
            foreach (IWebElement link in links)
            {
                var url = link.GetAttribute("href");
                refLinks.Add(url);              
                
            }
            return refLinks;
        }

        /// <summary>
        /// Write Log data
        /// </summary>
        /// <param name="strLog"></param>
        public void WriteLog(string strLog)
        {

            string path1 = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug\\net6.0\\", "");
            string logFilePath = path1 + "\\LogData\\log" + System.DateTime.Today.ToString("MM-dd-yyyy") + "." + "txt";
            FileInfo logFileInfo = new FileInfo(logFilePath);
            DirectoryInfo logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
            if (!logDirInfo.Exists) logDirInfo.Create();
            using (FileStream fileStream = new FileStream(logFilePath, FileMode.Append))
            {
                using (StreamWriter log = new StreamWriter(fileStream))
                {
                    log.WriteLine(strLog);
                }
            }
        }
        /// <summary>
        /// Validate the All the Links on WebPage
        /// </summary>
        /// <param name="links"></param>
        public void ValidateAllLinksonWebpage(List<string> links)
        {
            foreach (var link in links)
            {
                var _result = VerifyValidLinkAsync(link);
            }
        }
        /// <summary>
        /// Given Link is Valide or not it returns boolean
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<bool> VerifyValidLinkAsync(string url)
        {            
            HttpClient client = new HttpClient();
            var msg = new HttpRequestMessage(HttpMethod.Get, url);
            
            var response = await client.SendAsync(msg);
            var content = await response.Content.ReadAsStringAsync();
            
            try
            {                
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    WriteLog(url + " " +HttpStatusCode.OK.ToString());
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            { //TODO: Check for the right exception here
                return false;
            }
        }
        /// <summary>
        /// The Method returns the boolean , based on search results count
        /// </summary>
        /// <param name="by"></param>
        /// <returns></returns>
        public bool CheckSearchResults(By by)
        {
            bool flag = false;

                int resultCount = 0;
            try
            {
                resultCount = Commonobj.CountElements(by);

                if (resultCount > 0)
                {
                    flag = true;
                }
            }
            catch (Exception ex)
            { 
                flag=false;
            }

            WriteLog("Search results count : " + resultCount);
            return flag;
        }
        public void pageScrollDown()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)webdriver;
            js.ExecuteScript("window.scrollBy(0, -350)", "");

        }
       
        public string RondomNum()
        {

            string datetime = DateTime.Now.ToString();
            return datetime.Replace("/", "").Replace(":", "");
        }

        /// <summary>
        /// Capture the Screenshot of failed Scenario
        /// </summary>
        /// <returns></returns>
        public String TakeScreenshot()
        {
            Screenshot screenshot = ((ITakesScreenshot)webdriver).GetScreenshot();
            string path1 = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug\\net6.0\\", "");
            string path = path1 + "\\Screenshots\\" + RondomNum() + ".png";
            screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
            return path;
        }
        public Pagehelper(IWebDriver driver)
        {
            this.webdriver = driver;
            Commonobj = new CommonUtility(webdriver);
        }
    }
}
