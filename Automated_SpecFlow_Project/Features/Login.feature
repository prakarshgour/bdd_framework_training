Feature: Login
	In order to maintain employee records
	As a user
	I want to login into the portal

	@high @valid
Scenario: Valid Credentials
	Given I have a browser with orangehrm page
	When I enter username as 'Admin'
	And I enter password as 'admin123'
	And I click on login
	Then I should be navigated to 'PIM' dashboard screen

	@low @invalid
Scenario Outline: Invalid Credentials
	Given I have a browser with orangehrm page
	When I enter username as '<username>'
	And I enter password as '<password>'
	And I click on login
	Then I should get error message as '<error>'

	Examples: 
	| username | password | error               |
	| john     | john123  | Invalid Credentials |
	| saul     | saul123  | Invalid Credentials |