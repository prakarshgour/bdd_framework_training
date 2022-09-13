Feature: Store
	In order to create an environment for managing pet shop
	As a user
	I want to handle the orders

	@positive
Scenario: Find Purchase Order By ID
	Given I have base url 'https://petstore.swagger.io/v2/' and resource 'store/order/3'
	When I do the Get Request
	Then I should get a response as 200
	And I should get the details of order in json format

	@negative
Scenario: Find Purchase Order By Non-Existing ID
	Given I have base url 'https://petstore.swagger.io/v2/' and resource 'store/order/7'
	When I do the Get Request
	Then I should get a response as 404
	And I should get a message as 'Order not found'

	@negative @ignore
Scenario: Find Purchase Order By Invalid ID
	Given I have base url 'https://petstore.swagger.io/v2/' and resource 'store/order/11'
	When I do the Get Request
	Then I should get a response as 400
	And I should get a message as 'Invalid ID supplied'