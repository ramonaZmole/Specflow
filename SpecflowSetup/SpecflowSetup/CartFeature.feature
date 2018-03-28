Feature: CartFeature
	In order to place order
	As a user
	I want to be able to make changes in cart

Background: 
	Given the user is in cart

Scenario: Remove product from cart
	And there is product 418 with quantity 1 in cart
	When the user removes the product from cart
	Then the cart gets empty

Scenario: Shipping is not free for orders under $1000
	And  there is product 418 with quantity 1 in cart
	When the user apply a zip code
	Then the shipping is not free

Scenario: Shipping is free for orders above $1000
	And  there is product 7013 with quantity 100 in cart
	When the user apply a zip code
	Then the shipping is free

Scenario: Shipping is unavailable for dropship materials 
	And there is product 18631 with quantity 1 in cart
	When the user apply a zip code
	Then the shipping is unavailable

Scenario: Empty the cart 
	And there are the following products in cart
	| material number | quantity |
	| 418             | 2        |
	| 18631           | 4        |
	| 7031            | 1        |
	When the user select Empty cart link 
	Then the cart gets empty


Scenario Outline: Check shipping 
	And there is <material> with <quantity> in cart
	When the user apply a zip code
	Then the shipping is <shipping>

Examples: 
	| material | quantity | shipping    |
	| 18631    | 1        | Unavailable |
	| 418      | 1        | 7.95        |
	| 7013     | 100      | FREE        |


