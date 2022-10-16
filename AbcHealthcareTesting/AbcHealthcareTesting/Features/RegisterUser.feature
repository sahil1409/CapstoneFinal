Feature: RegisterUser

A basic feature to test registration

@tag1
Scenario: Registration of User
	Given I navigate to website
	Then I enter Username Email and Password
	And I click on Register button
