using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Utilities;
using OpenQA.Selenium;

namespace ConsoleApp1.Pages
{
    public class LoginPage
    {

        public void LoginActions(IWebDriver driver)

        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();

            //Lunch Mars UI  and navigate to Login page 
            driver.Navigate().GoToUrl("http://localhost:5000/Home");

            //Identify Signin tab and click on signin 
            IWebElement clickSignIn = driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
            clickSignIn.Click();

            //Identify username textbox and entre valid username 
            IWebElement emailTextBox = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
            emailTextBox.SendKeys("gothi.mendis@gmail.com");

            //Identify password textbox and entre valid password
            IWebElement passwordTextBox = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
            passwordTextBox.SendKeys("senera8087");

            //Identify Login button and click on login button
            IWebElement loginButton = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
            loginButton.Click();

            Waits.WaitToExist(driver, "XPath", "/html/body/div[2]/div/div/div[1]/div/div[4]/button", 6);

        }
        public void Close(IWebDriver driver)
            {
            driver.Quit();
            }
    }
}
