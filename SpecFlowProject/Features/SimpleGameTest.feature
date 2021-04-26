@SimpleAndroidGameTest
Feature: SimpleGameTest

Background:
	Given I opened the game
	
Scenario: Check if the game was open
	Then I should see main menu
	Then I close the game

Scenario: Press Space and check if player in the room
	Given I pressed Space button
	When the player enter to the room
	Then I close the game

Scenario Outline: Type player name in the input field and check input field name
	Given I typed <playerName> in the input field
	Then I should see <playerName> in the input field
	Then I close the game
	
	Examples:
	    | playerName |
		| admin 	 |
		| PlAyEr	 |
		| Artem		 |
	
