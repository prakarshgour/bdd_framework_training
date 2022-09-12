Feature: Employee
	In order to add, edit, delete employee records
	As an admin
	To modify employee details in dashboard

	@high
Scenario Outline: Add Valid Employee
	Given I have a browser with orangehrm page
	When I enter username as '<username>'
	And I enter password as '<password>'
	And I click on login
	And I click on PIM
	And I click on Add Employee
	And I fill the add employee section
	| firstname   | middlename   | lastname   | employee_id   | toggle_login_details   | username   | password       | confirm_password       | status   |
	| <firstname> | <middlename> | <lastname> | <employee_id> | <toggle_login_details> | <acc_user> | <acc_password> | <acc_confirm_password> | <status> |
	And I click on save employee
	Then I shopuld be navigated to personal details section with employee records
	Examples:
	| username | password | firstname | middlename | lastname | employee_id | toggle_login_details | acc_user | acc_password | acc_confirm_password | status   |
	| Admin    | admin123 | Prakarsh  | A          | Gour     | 1097        | on                   | prakarsh | Hello@789    | Hello@789            | disabled |
	| Admin    | admin123 | Saul      | J          | Goodman  | 1001        | on                   | jimmy    | Welcome@123  | Welcome@123          | enabled  |