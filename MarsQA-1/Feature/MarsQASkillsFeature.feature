Feature: MarsQASkillsFeature


Scenario: 01 User Logs in and is taken to profile page
	Given User is logged into MarsQA application
	Then User is taken to their Profile page

Scenario Outline: 02 User adds Skills to the profile
	Given User is logged into MarsQA application
	And User moves to the skills tab
	When User adds new Skill including '<SkillName>','<SkillLevel>'
	Then Newly added skill is displayed including '<SkillName>','<SkillLevel>' in the skills list on user profile
Examples:
	| SkillName          | SkillLevel   |
	| Cooking            | Intermediate |
	| Swimming           | Intermediate |
	| Automation Testing | Intermediate |
	| Manual Testing     | Expert       |
	| Pet Sitting        | Expert       |

Scenario: 03 User edits newly added skill 
	Given User is logged into MarsQA application 
	And User moves to the skills tab
	When User edits newly added skill 
	Then Skill is edited successfully 

Scenario: 04 User deletes newly added skills 
	Given User is logged into MarsQA application 
	And User moves to the skills tab
	When User deletes newly added skills
	Then Skills is deleted successfully

Scenario: 05 User cancels while adding a skill 
	Given User is logged into MarsQA application
	And User moves to the skills tab
	When User enters the values for skill name and skill level
	And User clicks on Cancel button 
	Then The changes made by user are not saved and the skill is not added 

Scenario: 06 User can't add duplicate skill
	Given User is logged into MarsQA application
	And User moves to the skills tab
	When User tries to add same skill twice 
	Then Error is displayed and user is not able to add duplicate skill
