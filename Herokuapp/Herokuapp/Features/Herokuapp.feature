Feature: Automate advanced interactions on The Internet site

  Scenario: Upload a file and interact with components
    Given I navigate to the File Upload page
    When I upload a file
    Then I should see the file upload confirmation message

  Scenario: Switch to iframe and update text
    Given I navigate to the iFrame page
   #Not able to edit text have application issue
    When I switch to the iframe and enter text "Hello Heroku" 
    Then I should see the updated text in the editor

  Scenario: Handle JavaScript alerts
    Given I navigate to the JavaScript Alerts page
    When I click on JS Alert
    Then I should see the result message for Alert
    When I click on JS Confirm Alert
    Then I should see the result message for Confirm
    When I click on Prompt Alert
    Then I should see the result message for Prompt

  Scenario: Interact with Dynamic Controls
    Given I navigate to the Dynamic Controls page
    When I click Remove to remove the checkbox
    When I click Add to bring the checkbox back
    Then I should see the checkbox appear

  Scenario: Scroll down and take a screenshot
    Given I navigate to the Infinite Scroll page
    When I scroll to the bottom of the page
    Then I should capture a screenshot at the bottom of the page

