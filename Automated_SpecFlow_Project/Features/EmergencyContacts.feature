Feature: EmergencyContacts
	In order to fetch the employee relation on emergency
	As an admin
	I should have access to add, edit, delete employee emergency contacts

	@low
Scenario Outline: Add Emergency Contact
	Given I have a browser with orangehrm page
	When I enter username as '<username>'
	And I enter password as '<password>'
	And I click on login
	And I click on My Info
	And I click on Emergency Contacts
	And I click on Add
	And I fill emergency contact details
	| name   | relationship   | home_telephone   | mobile   | work_telephone   |
	| <name> | <relationship> | <home_telephone> | <mobile> | <work_telephone> |
	And I click on save contact
	Then I shopuld be navigated to view emergency contacts section
	Examples: 
	| username | password | name  | relationship | home_telephone | mobile  | work_telephone |
	| Admin    | admin123 | Jimmy | Brother      | 79845461       | 9848965 | 4548113        |
	| Admin    | admin123 | Saul  | Father       | 9634374        | 1328679 | 7945132        |