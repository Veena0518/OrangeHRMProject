using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace OrangeHRMProject
{
    public class OpenAndClose
    {
        private IWebDriver driver;

        //Orange HRM url
        private const string OrangeHRMUrl = @"https://opensource-demo.orangehrmlive.com/";

        //open method
        public IWebDriver Open(string type)
        {
            if (string.IsNullOrEmpty(type) || type == "chrome")
            {
                driver = new ChromeDriver();
            }
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(OrangeHRMUrl);
            return driver;
        }

        //close method
        public void Close()
        {
            driver.Quit();
        }
    }
}
