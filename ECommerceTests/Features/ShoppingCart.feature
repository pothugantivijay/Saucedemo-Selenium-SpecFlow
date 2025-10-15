Feature: Shopping Cart
    As a logged in user
    I want to add items to my Cart
    So that i can purchase them
    
    Background:
    Given I navigate to SauceDemo login page
    And I login with username "standard_user" and password "secret_sauce"

    @cart@positive
    Scenario: Add single item to the cart
    When I add "Backpack" to the cart
    Then the cart badge should show "1"

    @cart@positive
    Scenario: Add multiple items to the cart
    When I add "Backpack" to the cart 
    And I add "Bike Light" to the cart
    Then the cart badge should show "2"

    @cart@positive
    Scenario: Verify cart contains added items
    When I add "Backpack" to the cart
    And I navigate to the cart
    Then I should see the cart page
    And the cart should contain 1 item
    