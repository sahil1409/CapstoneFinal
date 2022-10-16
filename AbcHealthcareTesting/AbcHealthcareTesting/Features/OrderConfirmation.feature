Feature: OrderConfirmation

Confirm one order

@tag1
Scenario: Comfirming an order
	Given I navigate to  website
	Then I click on Login button as I already have an account
	Then I enter an Username and Password
	When I click on Login
	Then I should see homepage of website
	Then I click on Inventory
	And I add some medicines to Cart
	When I click on Cart icon
	Then I should see Cart page
	When I click on Checkout
	Then Order should be confirmed

