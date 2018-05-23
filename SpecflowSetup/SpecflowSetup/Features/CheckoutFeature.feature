Feature: CheckoutFeature
	

@mytag
Scenario: Discount is present
	Given the user is in checkout
	And  there is product 20093 with quantity 105 in cart
	When the user apply a priority code
	Then the discount is present