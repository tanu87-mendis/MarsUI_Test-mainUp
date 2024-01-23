using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Utilities;
using OpenQA.Selenium;

namespace ConsoleApp1.Pages
{
    public class SkillsPage
    {

        public void GoToSkillsPage(IWebDriver driver)
        {
            // User Navigate to Skills Page
            Waits.WaitToExist(driver, "XPath", "//a[text()='Skills']", 6);

            IWebElement skillsPageTab = driver.FindElement(By.XPath("//a[text()='Skills']"));
            skillsPageTab.Click();

            Thread.Sleep(3000);
        }

        public void AddNewSkill(IWebDriver driver, String addSkill, String skillLevel)
        {
            //Identify Add New Button and click on Add New Button
            IWebElement addNewButton_Skill = driver.FindElement(By.XPath("//div[@class='ui teal button']"));
            addNewButton_Skill.Click();

            //Navigate to AddSkill textbox send values
            IWebElement addSkills = driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
            addSkills.SendKeys(addSkill);

            //choose Skill level
            IWebElement skillLevels = driver.FindElement(By.XPath("//select[@name='level']"));
            skillLevels.SendKeys(skillLevel);

            //click on Add button
            IWebElement addBtn = driver.FindElement(By.XPath("//input[@value='Add']"));
            addBtn.Click();
        }

        public void UpdateSkill(IWebDriver driver, String updatedSkill, String updatedSkillLevel)
        {
            Thread.Sleep(3000);
            IWebElement editButton = driver.FindElement(By.XPath("//div[@data-tab='second']//table[@class='ui fixed table']/tbody/tr/td[3]/span[1]"));
            editButton.Click();

            //update Skill textbox send values
            IWebElement updatedSkillTextBox = driver.FindElement(By.XPath("//input[@placeholder='Add Skill']")); 
            updatedSkillTextBox.Clear();
            updatedSkillTextBox.SendKeys(updatedSkill);

            //update Skill level
            IWebElement updatedSkillLevelValue = driver.FindElement(By.XPath("//select[@name='level']"));
            updatedSkillLevelValue.SendKeys(updatedSkillLevel);

            //click on update button
            IWebElement clickOnUpdateButton = driver.FindElement(By.XPath("//input[@value='Update']"));
            clickOnUpdateButton.Click();
        }

        public string GetEditedSkill(IWebDriver driver, String skill)
        {
            Thread.Sleep(6000);
            IWebElement editedSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[1]"));
            return editedSkill.Text;

        }

        public string GetEditedLevel(IWebDriver driver, String slevel)
        {
            IWebElement editedSkillLevel = driver.FindElement(By.XPath("//td[normalize-space()='Beginner']"));
            return editedSkillLevel.Text;

        }

        public void DeleteSkillButton(IWebDriver driver, string skill, string skillLevel)
        {
            Thread.Sleep(6000);
            IWebElement deleteSkill = driver.FindElement(By.XPath("//td[normalize-space()='" + skill + "']/following-sibling::td[@class='right aligned']/span[2]"));
            deleteSkill.Click();
        }

        public Boolean CheckIfSkillExists(IWebDriver driver, string skill)
        {
            Thread.Sleep(6000);

            Boolean isExist = true;

            try
            {
                IWebElement deletedSkill = driver.FindElement(By.XPath("//td[normalize-space()='" + skill + "']/following-sibling::td[@class='right aligned']/span[2]"));
            }
            catch (NoSuchElementException ex)
            {
                isExist = false;
            }


            return isExist;
        }
    }

}
