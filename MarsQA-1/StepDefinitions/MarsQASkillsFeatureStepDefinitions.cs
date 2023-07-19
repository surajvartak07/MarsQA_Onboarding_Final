using MarsQA_1.SpecflowPages.Pages;
using NUnit.Framework;
using System.Threading;
using TechTalk.SpecFlow;

namespace MarsQA_1.StepDefinitions
{
    [Binding]
    public class MarsQASkillsFeatureStepDefinitions
    {
        private readonly Skills skillsObj;

        public MarsQASkillsFeatureStepDefinitions()
        {
            skillsObj = new Skills();
        }

        [Given(@"User moves to the skills tab")]
        public void GivenUserMovesToTheSkillsTab()
        {
            skillsObj.NavigateToSkillsTab();
        }

        [When(@"User adds new Skill including '([^']*)','([^']*)'")]
        public void WhenUserAddsNewSkillIncluding(string skillName, string skillLevel)
        {
            skillsObj.AddNewSkill(skillName, skillLevel);
        }

        [Then(@"Newly added skill is displayed including '([^']*)','([^']*)' in the skills list on user profile")]
        public void ThenNewlyAddedSkillIsDisplayedIncludingInTheSkillsListOnUserProfile(string skillName, string skillLevel)
        {
            string addedSkill = skillsObj.ValidateAddedSkill(skillName);
            Assert.That(addedSkill == skillName, $"{skillName} skill could not be added");
        }

        [When(@"User edits newly added skill")]
        public void WhenUserEditsNewlyAddedSkill()
        {
            skillsObj.EditSkill();
        }

        [Then(@"Skill is edited successfully")]
        public void ThenSkillIsEditedSuccessfully()
        {
            string editedSkill = skillsObj.ValidateEditedSkill();
            Assert.That(editedSkill == "Edited", "Skill could not be edited");
        }

        [When(@"User deletes newly added skills")]
        public void WhenUserDeletesNewlyAddedSkills()
        {
            skillsObj.CleanSkillsTable();
        }

        [Then(@"Skills is deleted successfully")]
        public void ThenSkillsIsDeletedSuccessfully()
        {
            bool del = skillsObj.ValidateSkillIsDeleted();
            Assert.That(del == true, "Skill could not be deleted");
        }

        [When(@"User enters the values for skill name and skill level")]
        public void WhenUserEntersTheValuesForSkillNameAndSkillLevel()
        {
            skillsObj.AddSkillPartially();
        }

        [When(@"User clicks on Cancel button")]
        public void WhenUserClicksOnCancelButton()
        {
            skillsObj.CancelAdding();
        }

        [Then(@"The changes made by user are not saved and the skill is not added")]
        public void ThenTheChangesMadeByUserAreNotSavedAndTheSkillIsNotAdded()
        {
            bool cancel = skillsObj.ValidateSkillNotAdded();
            Assert.That(cancel = true, "Skill added even after canceling");
        }

        [When(@"User tries to add same skill twice")]
        public void WhenUserTriesToAddSameSkillTwice()
        {
            var skillName = "Specflow";
            var skillLevel = "Beginner";
            skillsObj.AddNewSkill(skillName, skillLevel);
            Thread.Sleep(2000);
            skillsObj.AddNewSkill(skillName, skillLevel);
        }

        [Then(@"Error is displayed and user is not able to add duplicate skill")]
        public void ThenErrorIsDisplayedAndUserIsNotAbleToAddDuplicateSkill()
        {
            string popupText = skillsObj.ValidatePopup();
            Assert.That(popupText == "This skill is already exist in your skill list.", "User was able to add duplicate skill");
        }

    }
}
