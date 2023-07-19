Feature: MarsQAFeature

As a MarsQA user, I want to be able to update my profile 
so that people looking for some skills can look into my profile
Note: to add step definitions for newly added features, click on go to definition and copy the given code and paste in step definitions


Scenario: 01 User Logs in and is taken to profile page
	Given User is logged into MarsQA application
	Then User is taken to their Profile page 

Scenario Outline: 02 User adds 4 Languages to the profile
	Given User is logged into MarsQA application
	When User adds new language including '<LanguageName>','<LanguageLevel>'
	Then Newly added language is displayed including '<LanguageName>','<LanguageLevel>' in the languages list on user profile
	Examples: 
	| LanguageName | LanguageLevel |
	| Marathi      | Basic         |
	| Sanskrit     | Conversational|
	| English      | Fluent        |
	| Hindi        | Native/Bilingual| 

Scenario: 03 User can't add more than four languages 
	Given User is logged into MarsQA application
	And User deletes all existing languages
	When User adds four new languages 
	Then User is not able to add any more languages because Add New button is not visible

Scenario: 04 User edits newly added language 
	Given User is logged into MarsQA application 
	When User edits newly added language 
	Then Language is edited successfully 

Scenario: 05 User deletes newly added language 
	Given User is logged into MarsQA application 
	When User deletes all existing languages
	Then All Languages are deleted successfully

Scenario: 06 User cancels while adding a language 
	Given User is logged into MarsQA application
	And User deletes all existing languages
	When User enters the values for language name and language level
	And Clicks on Cancel button 
	Then The changes made by user are not saved and the language is not added 

Scenario: 07 User can't add duplicate language
	Given User is logged into MarsQA application
	And User deletes all existing languages
	When User tries to add same language twice 
	Then Error is displayed and user is not able to add duplicate language 

Scenario: 08 User can't add a language without Language name 
	Given User is logged into MarsQA application
	When User tries to add new Language without providing Language name 
	Then Error is displayed and user is not able to add language without providing Language name 

Scenario: 09 User can't add a language without Language Level 
	Given User is logged into MarsQA application
	When User tries to add new Language without providing Language level 
	Then Error is displayed and user is not able to add language without providing Language lavel 

	#This test case fails because of a defect in application as user is able to add language with only spaces in language name
Scenario: 10 User can't add a language with only spaces as Language name 
	Given User is logged into MarsQA application
	When User tries to add new Language by providing only blank spaces in Language name 
	Then Error is displayed and user is not able to add language by providing only spaces in Language name
	
Scenario Outline: 11 User tries to add language with very long language name 
	Given User is logged into MarsQA application
	When User tries to add language using '<BadLanguageName>','<BadLanguageLevel>'
	Then Language is added for '<BadLanguageName>','<BadLanguageLevel>'
	Examples: 
	| BadLanguageName										 |  BadLanguageLevel |
	| abcabcabcabcabcabcskmseklnmseklvsnskslkmslksskvjlnsdkj |  Basic            |
	| 123%^*&#23JDSSS svsvnsi2378463						 |  Fluent           |