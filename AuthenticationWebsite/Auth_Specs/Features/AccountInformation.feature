Feature: Account Information Page
		 As a User I want to be able to update the Informations

@LogIn @AccountInfoPage @Positive
Scenario: Auth site Login
	Given I have a valid Credentials
	And I logged into Auth UI Site
	When I select the Account Information link on the left panel
	Then I should be able to see the account information username with values

@AccountInfoPage @validations @Positive
Scenario: Update Information in Account Info Page
	Given I have a valid Credentials
	And I logged into Auth UI Site
	When I select the Account Information link on the left panel
	And I enter Alternate email value as "Anandanagarajan.Nagayan@LexisNexis.com"
	And I enter Mobile Phone value as "4692365375"
	And click on save button
	Then I Should get a Message saying "Your information has been submitted successfully"
	And I LogOut and Close the browser

@AccountInfoPage @AlternateEmail @Error @Negative
Scenario: Alternative Email Validation Empty Values
	Given I have a valid Credentials
	And I logged into Auth UI Site
	When I select the Account Information link on the left panel
	And I clear Alternate email field on Account Information Page
	And I clear Phone Number field on Account Information Page
	And click on save button
	Then I Should get a validation saying "'Alternate Email' should not be empty."
	And I Should get a validation saying "Please enter a valid Phone number."
 
@AccountInfoPage @AlternateEmail @Error @Negative
Scenario: Alternative Email Validation improper format
	Given I have a valid Credentials
	And I logged into Auth UI Site
	When I select the Account Information link on the left panel
	And I enter Alternate email value as "Anand@"
	And I Press Tab Key
	Then I Should get a validation saying "Please enter a valid email address."
	And I LogOut and Close the browser

@AccountInfoPage @AlternateEmail @Error @Negative
Scenario: Alternative Email same as LogIn Email
	Given I have a valid Credentials
	And I logged into Auth UI Site
	When I select the Account Information link on the left panel
	And I enter Alternate email value same as LogIn Email 
	And click on save button
	Then I should get Error Message "Alternate Email is same as Email"

@AccountInfoPage @PhoneNumber @Error @Negative
Scenario: Phone Number Validation improper format
	Given I have a valid Credentials
	And I logged into Auth UI Site
	When I select the Account Information link on the left panel
	And I enter Mobile Phone value as "123456"
	And I Press Tab Key
	Then I Should get a validation saying "Please enter a valid Phone number."