Feature: UserLogin

Logging a user into the website

@tag1
Scenario: Login user into the website
	Given I navigate to the website
	Then I click on Login button as I already have account
	Then I enter Username and Password
	And I click on Login
	Then I should see Homepage of website
