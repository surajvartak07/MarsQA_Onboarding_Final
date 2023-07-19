using MarsQA_1.Helpers;
using MarsQA_1.SpecflowPages.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace MarsQA_1.StepDefinitions
{
    [Binding]
    public class MarsQAFeatureStepDefinitions
    {
        //Page Object for Languages
        private readonly Languages languagesObj;
        private readonly ProfilePage profilePageObj;


        public MarsQAFeatureStepDefinitions()
        {
            languagesObj = new Languages();
            profilePageObj = new ProfilePage();

        }

        [Given(@"User is logged into MarsQA application")]
        public void GivenUserIsLoggedIntoMarsQAApplication()
        {
            //this is being done by calling SignIn.SignInStep from Start.cs class
        }

        [Then(@"User is taken to their Profile page")]
        public void ThenUserIsTakenToTheirProfilePage()
        {
            string ValidateTitle = profilePageObj.ValidateProfilePage();
            Assert.That(ValidateTitle == "Profile", "User is not navigated to Profile page after login");
        }


        [When(@"User adds new language including '([^']*)','([^']*)'")]
        public void WhenUserAddsNewLanguageIncluding(string LanguageName, string LanguageLevel)
        {
            languagesObj.AddLanguage(LanguageName, LanguageLevel);
        }

        [Then(@"Newly added language is displayed including '([^']*)','([^']*)' in the languages list on user profile")]
        public void ThenNewlyAddedLanguageIsDisplayedIncludingInTheLanguagesListOnUserProfile(string LanguageName, string LanguageLevel)
        {
            string addedLanguage = languagesObj.ValidateAddedLanguage(LanguageName);
            Assert.That(addedLanguage == LanguageName, $"{LanguageName} language could not be added");
        }

        [When(@"User adds four new languages")]
        public void WhenUserAddsFourNewLanguages()
        {
            languagesObj.AddFourLanguages();
        }

        [Then(@"User is not able to add any more languages because Add New button is not visible")]
        public void ThenUserIsNotAbleToAddAnyMoreLanguagesBecauseAddNewButtonIsNotVisible()
        {
            bool limit = languagesObj.ValidateMaxLanguageLimit();
            Assert.That(limit == true);
        }

        [When(@"User edits newly added language")]
        public void WhenUserEditsNewlyAddedLanguage()
        {
            languagesObj.EditLanguage();
        }

        [Then(@"Language is edited successfully")]
        public void ThenLanguageIsEditedSuccessfully()
        {
            string editedLanguage = languagesObj.ValidateEditedLanguage();
            Assert.That(editedLanguage == "MarathiEdited", "Language could not be edited");
        }

        [When(@"User deletes all existing languages")]
        public void WhenUserDeletesAllExistingLanguages()
        {
            languagesObj.CleanLanguageTable();
        }

        [Then(@"All Languages are deleted successfully")]
        public void ThenAllLanguagesAreDeletedSuccessfully()
        {
            bool del = languagesObj.ValidateLanguageIsDeleted();
            Assert.That(del == true, "Language could not be deleted");
        }

        [Given(@"User deletes all existing languages")]
        public void GivenUserDeletesAllExistingLanguages()
        {
            languagesObj.CleanLanguageTable();
        }

        [When(@"User enters the values for language name and language level")]
        public void WhenUserEntersTheValuesForLanguageNameAndLanguageLevel()
        {
            languagesObj.AddLanguagePartially();
        }

        [When(@"Clicks on Cancel button")]
        public void WhenClicksOnCancelButton()
        {
            languagesObj.CancelAdding();
        }

        [Then(@"The changes made by user are not saved and the language is not added")]
        public void ThenTheChangesMadeByUserAreNotSavedAndTheLanguageIsNotAdded()
        {
            bool cancel = languagesObj.ValidateNotAdded();
            Assert.That(cancel == true, "Action could not be canceled");
        }


        [When(@"User tries to add same language twice")]
        public void WhenUserTriesToAddSameLanguageTwice()
        {
            var languageName = "Hindi";
            var languageLevel = "Fluent";

            languagesObj.AddLanguage(languageName, languageLevel);

            //Add the same language again
            languagesObj.AddLanguage(languageName, languageLevel);
        }

        [Then(@"Error is displayed and user is not able to add duplicate language")]
        public void ThenErrorIsDisplayedAndUserIsNotAbleToAddDuplicateLanguage()
        {
            var popupText = languagesObj.ValidatePopup();
            Assert.That(popupText == "This language is already exist in your language list.", "User can add duplicate language.");

        }

        [When(@"User tries to add new Language without providing Language name")]
        public void WhenUserTriesToAddNewLanguageWithoutProvidingLanguageName()
        {
            languagesObj.AddLanguageWithoutName();
        }

        [Then(@"Error is displayed and user is not able to add language without providing Language name")]
        public void ThenErrorIsDisplayedAndUserIsNotAbleToAddLanguageWithoutProvidingLanguageName()
        {
            string poptext = languagesObj.ValidatePopup();
            Assert.That(poptext == "Please enter language and level", "User can add language without Language Name");
        }

        [When(@"User tries to add new Language without providing Language level")]
        public void WhenUserTriesToAddNewLanguageWithoutProvidingLanguageLevel()
        {
            languagesObj.AddLanguageWithoutLevel();
        }

        [Then(@"Error is displayed and user is not able to add language without providing Language lavel")]
        public void ThenErrorIsDisplayedAndUserIsNotAbleToAddLanguageWithoutProvidingLanguageLavel()
        {
            string poptext = languagesObj.ValidatePopup();
            Assert.That(poptext == "Please enter language and level", "User can add language without Language Name");
        }

        [When(@"User tries to add new Language by providing only blank spaces in Language name")]
        public void WhenUserTriesToAddNewLanguageByProvidingOnlyBlankSpacesInLanguageName()
        {
            languagesObj.AddLanguageWithSpaceAsLanguageName();
        }

        [Then(@"Error is displayed and user is not able to add language by providing only spaces in Language name")]
        public void ThenErrorIsDisplayedAndUserIsNotAbleToAddLanguageByProvidingOnlySpacesInLanguageName()
        {
            string poptext = languagesObj.ValidatePopup();
            Assert.That(poptext == "Please enter language and level", "User can add language by providing only blank spaces in Language Name");
        }

        [When(@"User tries to add language using '([^']*)','([^']*)'")]
        public void WhenUserTriesToAddLanguageUsing(string BadLanguageName, string BadLanguageLevel)
        {
            languagesObj.AddLanguage(BadLanguageName, BadLanguageLevel);
        }

        [Then(@"Language is added for '([^']*)','([^']*)'")]
        public void ThenLanguageIsAddedFor(string BadLanguageName, string BadLanguageLevel)
        {
            string addedBadLanguage = languagesObj.ValidateAddedBadLanguage(BadLanguageName);
            Assert.That(addedBadLanguage == BadLanguageName, "Language could not be added");
        }
    }
}
