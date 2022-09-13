Feature: PetShop
  In order to create an environment for managing pet shop
  As a user
  I want to create, edit, delete, get pet details

Scenario: Find Pet By PetId
  Given I have base url 'https://petstore.swagger.io/v2/' and resource 'pet/102'
  When I do the Get Request
  Then I should get a response as 200
  And I should get the details of pet in json format

Scenario: Find Pet By Invalid PetId
  Given I have base url 'https://petstore.swagger.io/v2/' and resource 'pet/-102'
  When I do the Get Request
  Then I should get a response as 400
  And I should get a message as 'Invalid ID supplied'

Scenario: Find Pet By non existing PetId
  Given I have base url 'https://petstore.swagger.io/v2/' and resource 'pet/999'
  When I do the Get Request
  Then I should get a response as 404
  And I should get a message as 'Pet not found'

Scenario: Delete Pet by PetId
  Given I have base url 'https://petstore.swagger.io/v2/' and resource 'pet/10'
  And I need to add api_key 'AK888' in the header
  When I do Delete Request
  Then I should get a response as 200


Scenario: Delete Pet by Invalid PetId
  Given I have base url 'https://petstore.swagger.io/v2/' and resource 'pet/-10'
  And I need to add api_key 'AK888' in the header
  When I do Delete Request
  Then I should get a response as 400
  And I should get a message as 'Invalid ID supplied'

Scenario: Delete Pet by non existing PetId
  Given I have base url 'https://petstore.swagger.io/v2/' and resource 'pet/999'
  And I need to add api_key 'AK888' in the header
  When I do Delete Request
  Then I should get a response as 404
  And I should get a message as 'Pet not found'