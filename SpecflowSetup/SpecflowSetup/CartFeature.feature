Feature: CartFeature
	In order to place order
	As a user
	I want to be able to make changes in cart

Scenario: Remove product from cart
	Given the user is in cart
	When the user removes the product from cart
	Then the cart gets empty
