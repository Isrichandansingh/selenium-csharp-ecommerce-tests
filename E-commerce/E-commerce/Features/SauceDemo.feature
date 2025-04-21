Feature: SauceDemo Shopping Flow

  Scenario: End-to-end shopping on SauceDemo site

    Given I launch the SauceDemo site
    Then I validate the login page elements
    When I try logging in with invalid credentials
    Then I should see an error message
    When I log in with valid credentials
    And I sort products by "Price (low to high)"
    And I add two items to the cart
    Then I verify the cart badge count is 2
    When I go to the cart page
    Then I verify both items are listed
    When I remove one item from the cart
    Then I verify the item is removed
    When I proceed to checkout and fill in personal details
    Then I verify the order summary and finish the purchase
    And I should see the confirmation message
    When I click back to products
    Then I should land on the products page
