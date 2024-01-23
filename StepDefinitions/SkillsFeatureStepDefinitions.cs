using System;
using TechTalk.SpecFlow;
using System;
using System.Reflection.Emit;
using ConsoleApp1.Pages;
using ConsoleApp1.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ConsoleApp1.StepDefinitions
{
    [Binding]
    public class SkillsFeatureStepDefinitions : CommonDriver
    {
        LoginPage loginPageObj = new LoginPage();
        SkillsPage skillPageObj = new SkillsPage();


        [When(@"I navigate to the skills")]
        public void WhenINavigateToTheSkills()
        {
            skillPageObj.GoToSkillsPage(driver);
        }

        [When(@"I add new skill '([^']*)' and skill level '([^']*)'")]
        public void WhenIAddNewSkillAndSkillLevel(string addSkill, string skillLevel)
        {
            skillPageObj.AddNewSkill(driver, addSkill, skillLevel);
        }

        [When(@"I update skill to '([^']*)' and skill level '([^']*)'")]
        public void WhenIUpdateSkillToAndSkillLevel(string updatedSkill, string updatedSkillLevel)
        {
            skillPageObj.UpdateSkill(driver,updatedSkill, updatedSkillLevel);
        }

        [Then(@"the record '([^']*)' and skill level '([^']*)'should be updated successfully")]
        public void ThenTheRecordAndSkillLevelShouldBeUpdatedSuccessfully(string skill, string slevel)
        {
            string editedSkill = skillPageObj.GetEditedSkill(driver, skill);
            string editedLevel = skillPageObj.GetEditedLevel(driver, slevel);

            Assert.That(editedSkill, Is.EqualTo(skill), "Actual Skill and updated Skill donot match");
            Assert.That(editedLevel, Is.EqualTo(slevel), "Actual Skill level and updated skill level donot match");
        }

        [When(@"I delete an existing skill '([^']*)' and skill level '([^']*)'")]
        public void WhenIDeleteAnExistingSkillAndSkillLevel(string deletedSkill, string deletedSkillLevel)
        {
            skillPageObj.DeleteSkillButton(driver, deletedSkill,deletedSkillLevel);
        }

        [Then(@"the record '([^']*)' should be deleted successfully from the profile")]
        public void ThenTheRecordShouldBeDeletedSuccessfullyFromTheProfile(string skill)
        {
            Boolean isExist = skillPageObj.CheckIfSkillExists(driver, skill);

            Assert.That(isExist, Is.False, "Skill is not deleted!");

        }


    }
}
