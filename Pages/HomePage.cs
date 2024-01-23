using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Utilities;
using OpenQA.Selenium;

namespace ConsoleApp1.Pages
{
    public class HomePage
    {
        public void GoToLanguagePage(IWebDriver driver)   
        {
             Thread.Sleep(3000);

            // Navigate to Languages tab
            IWebElement languagesTab = driver.FindElement(By.XPath("//a[text()='Languages']"));
            languagesTab.Click();

            Waits.WaitToExist(driver, "XPath", "//a[text()='Languages']", 5);

        }
    }
}
