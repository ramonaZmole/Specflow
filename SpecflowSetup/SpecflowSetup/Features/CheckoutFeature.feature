Feature: CheckoutFeature

Background:
Given the user is in cart
And there is product 20093 with quantity 105 in cart


Scenario: Discount is present
	And the user goes to checkout
	When the user apply a priority code
	Then the discount is present