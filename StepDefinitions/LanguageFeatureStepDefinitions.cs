using System;
using System.Reflection.Emit;
using ConsoleApp1.Pages;
using ConsoleApp1.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace ConsoleApp1.StepDefinitions
{
    [Binding]
    public class LanguageFeatureStepDefinitions : CommonDriver
    {
        LoginPage loginPageObj = new LoginPage();
        HomePage homePageObj = new HomePage();
        ProfilePage languagePageObj = new ProfilePage();

        [Given(@"I logged into the Mars portal successfully")]
        public void GivenILoggedIntoTheMarsPortalSuccessfully()
        {
            //Open Chrome browser 
            driver = new ChromeDriver();

            //Login Page object initialization and definition
            loginPageObj.LoginActions(driver);

        }

        [When(@"I navigate to the user profile")]
        public void WhenINavigateToTheUserProfile()
        {
            //Home Page object initialization and definition
            homePageObj.GoToLanguagePage(driver);
        }

        [When(@"I Add new language")]
        public void WhenINavigateToTheLanguagesTab()
        {

            //Language Page object initialization and definition 
            languagePageObj.AddNewLangauge(driver);
        }

        [When(@"I add new language '([^']*)'")]
        public void WhenIAddNewLanguage(string language)
        {
            languagePageObj.AddNewLangauge(driver, language);
        }


        [Then(@"the record should be created successfully")]
        public void ThenTheRecordShouldBeCreatedSuccessfully()
        {
            
        }

        [Then(@"the record '([^']*)' should be created successfully")]
        public void ThenTheRecordShouldBeCreatedSuccessfully(string language)
        {
            Boolean isExist = languagePageObj.CheckIfLanguageExists(driver, language);

            Assert.That(isExist, Is.True, "Language is not created!");
        }



        [When(@"I update the '([^']*)','([^']*)' of  existing language under user profile")]
        public void WhenIUpdateTheOfExistingLanguageUnderUserProfile(string language, string level)
        {
            languagePageObj.EditLangauge(driver, language,level);
        }

        [Then(@"the the record should be updated '([^']*)', '([^']*)' successfully")]
        public void ThenTheTheRecordShouldBeUpdatedSuccessfully(string language, string level)
        {
            string editedlanguage = languagePageObj.GetEditedLanguage(driver, language);  
            string editedLevel = languagePageObj.GetEditedLevel(driver, level);

            Assert.That(editedlanguage, Is.EqualTo(language),"Actual Language and updated language donot match");
            Assert.That(editedLevel, Is.EqualTo(level), "Actual Language level and updated level donot match");
                
        }

        [When(@"I delete an existing language '([^']*)'")]
        public void WhenIDeleteAnExistingLanguage(string language)
        {
            languagePageObj.DeleteLangauge(driver, language);
        }

        [Then(@"the record '([^']*)' should be deleted successfully")]
        public void ThenTheRecordShouldBeDeletedSuccessfully(string language)
        {
            Boolean isExist = languagePageObj.CheckIfLanguageExists(driver, language);

            Assert.That(isExist, Is.False, "Language is not deleted!");

        }

    }
}
