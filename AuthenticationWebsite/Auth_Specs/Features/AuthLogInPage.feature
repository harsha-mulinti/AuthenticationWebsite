Feature: AuthLogInPage
		As a User I want to be able to LogIn Successfully

@LogIn @IncorrectPassword @Error
Scenario Outline: LogIn with Incorrect Password
	Given I enter the <username> and <incorrect password>
	When I click on SignIn Button
	Then I should be able to see the Error message as "Invalid email or password, please try again."

	Examples: 

	| username                 | incorrect password |
	| lnpmsapi+qatestlatest72@gmail.com | Password           |

@LogIn @Captcha
Scenario Outline: Display Captcha on typing incorrect password
	Given I have Auth Site LogIn page in the browser
	When I enter three times the <username> and <incorrect password>
	Then I should be able to see security check to enter the captcha 

	Examples: 

	| username                 | incorrect password |
	| lnpmsapi+qatestlatest72@gmail.com | Password           |

@ForgotPassword @InvalidEmail @Error
Scenario: Invalid Email in Forgot Password
	Given I have Auth Site LogIn page in the browser
	When I click on Forgot Password
	Then I should be redirected to Forgot Password page asking for Email Address
	When I enter Invalid Email "Anand@LexisNexis.com" and click on Next
	Then I should get Error Message "Already have an account?"
	When I click on Cancel Button
	Then I should see Auth LogIn page
	And I close the Browser

@ForgotPassword @InvalidEmail @Error
Scenario: Improper Email in Forgot Password
	Given I have Auth Site LogIn page in the browser
	When I click on Forgot Password
	Then I should be redirected to Forgot Password page asking for Email Address
	When I enter Improper Email "Anand"
	And I Press Tab Key
	Then I should be able to see the Error message as "Please enter a valid email address."
	When I click on Cancel Button
	Then I should see Auth LogIn page
	And I close the Browser

@ForgotPassword @AlternateEmail @PhoneNumber
Scenario: Email and Phone validation in Forgot Password
	Given I have Auth Site LogIn page in the browser
	When I click on Forgot Password
	Then I should be redirected to Forgot Password page asking for Email Address
	When I enter Valid Email "lnpmsapi+qatestlatest72@gmail.com" and click on Next
	Then I should be displayed the Alternate Email and Phone Number Details	
	When I click on Cancel Button
	Then I should see Auth LogIn page
	And I close the Browser