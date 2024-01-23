using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ConsoleApp1.Pages
{
    public class ProfilePage
    {
        By addNewBtn = By.XPath("//div[@class='ui bottom attached tab segment active tooltip-target']//div[text()='Add New']");
        By addLangBtn = By.XPath("//div[@class='ui bottom attached tab segment active tooltip-target']//div[text()='Add New']");
        By chooseLangLevelBtn = By.XPath("//div[@class='ui bottom attached tab segment active tooltip-target']//div[text()='Add New']");
        By addButtonBtn = By.XPath("//div[@class='ui bottom attached tab segment active tooltip-target']//div[text()='Add New']");


        #region Languages

        public void delete_All_Records()
        { 
            Thread.Sleep(8000);
            //Delete all records in the language list

           
        }

        public void AddNewLangauge(IWebDriver driver)
        {
            //Identify AddNew button and click on Addnew Button
            IWebElement addNewButton = driver.FindElement(addNewBtn);
            addNewButton.Click();

            //Navigate AddLanguage textbox send values
            IWebElement addLang = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input"));
            addLang.SendKeys("English");

            //choose language level
            IWebElement chooseLangLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select"));
            chooseLangLevel.SendKeys("Basic");

            IWebElement addButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
            addButton.Click();
        }

        public void AddNewLangauge(IWebDriver driver, String language)
        {
            //Identify AddNew button and click on Addnew Button
            IWebElement addNewButton = driver.FindElement(addNewBtn);
            addNewButton.Click();

            //Navigate AddLanguage textbox send values
            IWebElement addLang = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input"));
            addLang.SendKeys(language);

            //choose language level
            IWebElement chooseLangLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select"));
            chooseLangLevel.SendKeys("Basic");

            IWebElement addButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
            addButton.Click();
        }

        public void EditLangauge(IWebDriver driver, string language, string level)
        {
            //Identify Edit tab and click on Edit button 
            IWebElement editButton = driver.FindElement(By.XPath("//div[@data-tab='first']//table[@class='ui fixed table']/tbody/tr/td[3]/span[1]"));
            editButton.Click();

            Waits.WaitToBeClickable(driver, "XPath", "//*/div/table/tbody[last()]/tr/td/div/div[1]/input", 6);


            //Navigate to language text box and edit value 
            IWebElement editLanguage = driver.FindElement(By.XPath("//*/div/table/tbody[last()]/tr/td/div/div[1]/input"));

            //(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td/div/div[1]/input"));
            editLanguage.Clear();
            editLanguage.SendKeys(language);

            Waits.WaitToBeClickable(driver,"XPath", "//*/tbody[last()]/tr/td/div/div[2]/select", 5);

            //Navigate to language level drop down and edit value
            IWebElement editLanguLevel = driver.FindElement(By.XPath("//*/tbody[last()]/tr/td/div/div[2]/select"));

            editLanguLevel.SendKeys(level);

            Thread.Sleep(3000);

            try
            {


            }
            catch (Exception)
            {
                Assert.Fail("Go to last page button hasn't been found.");
            }

            //Navigate Update Button and click on Update button
            IWebElement updateButton = driver.FindElement(By.XPath("//*/tbody[last()]/tr/td/div/span/input[1]"));
            updateButton.Click();

            Waits.WaitToExist(driver, "XPath", "//*/tbody[last()]/tr/td/div/span/input[1]", 6);
            
        }

        public string GetEditedLanguage(IWebDriver driver, String language)
        {
            IWebElement editedlanguage = driver.FindElement(By.XPath("//td[normalize-space()='"+ language +"']"));
            return editedlanguage.Text;

        }

        public string GetEditedLevel(IWebDriver driver , String level)
        {
            IWebElement editedLevel = driver.FindElement(By.XPath("//td[normalize-space()='"+ level +"']"));
            return editedLevel.Text;

        }
        public void DeleteLangauge(IWebDriver driver, String language)
        {
            //Navigate Delete Button and click on delete button
            
            Waits.WaitToBeClickable(driver, "XPath", "//td[normalize-space()='" + language + "']/following-sibling::td[@class='right aligned']/span[2]", 5);

            IWebElement deleteButton = driver.FindElement(By.XPath("//td[normalize-space()='"+ language + "']/following-sibling::td[@class='right aligned']/span[2]"));
            deleteButton.Click();
        }

        public Boolean CheckIfLanguageExists(IWebDriver driver, String language)
        {
            Thread.Sleep(6000);
            Boolean isExist = true;

            try
            {
                IWebElement deletedLanguage = driver.FindElement(By.XPath("//td[normalize-space()='" + language + "']"));
            }
            catch(NoSuchElementException ex)
            {
                isExist = false;
            }

            return isExist;
        }

        #endregion
  
    }
}
