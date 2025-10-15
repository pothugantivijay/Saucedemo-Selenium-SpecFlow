Feature: Login Functionality
    As a user of SauceDemo
    I want to be able to Login
    So that i can access the products page

    Background:
    Given I navigate to the SauceDemo Login page

    @smoke@positive
    Scenario: Successful login with valid crednetials
    When I enter username "standard_user"
    And I enter password "secret_sauce"
    And I click the login button
    Then I should see the products page

    @negative
    Scenario: Failed login with invalid crednetials
    When I enter username "inalid_user"
    And I enter password "wrong_password"
    And I click the login button
    Then I should see an error message containing "Epic sadface"

    @negative
    Scenario: Falied login with locked out user
    When I enter username "locked_out_user"
    And I enter password "secret_sauce"
    And I click the login button
    Then I should see an error message containing "locked out"
    
