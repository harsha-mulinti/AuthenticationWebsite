Feature: Change Password page 
		 As a User I want to be able to update the Password

@ChangePassword
Scenario Outline: Change Password and Login
	Given I have a valid Credentials
	And I logged into Auth UI Site
	When I select the Change Password link on the left panel
	And I enter the old <Password>
	And enter values in <New Password> and <Confirm Password> as same
	And click on save button
	Then I Should get a Message saying "Your new password has been submitted successfully"
	When I Logout of the Auth Site
	And I logIn with the <username> and <New Password>
	Then I should be logged into Auth UI Site successfully
	When I select the Change Password link on the left panel
	And I revert the <New Password> changes
	And click on save button
	Then I Should get a Message saying "Your new password has been submitted successfully"
	And I LogOut and Close the browser

	Examples: 
	| username                        | Password  | New Password | Confirm Password |
	| lnpmsapi+qatestlatest72@gmail.com | Password1 | Password2    | Password2        |

@ChangePasswordPage @validations
Scenario: Change Password Page confirmation
	Given I have a valid Credentials
	And I logged into Auth UI Site
	When I select the Change Password link on the left panel
	And click on save button
	Then I Should get a validation saying "Password is required"

@ChangePasswordPage @validations
Scenario Outline: Change Password Page validation message for new password
	Given I have a valid Credentials
	And I logged into Auth UI Site
	When I select the Change Password link on the left panel
	And I enter the old <Password>
	And enter values in <New Password> and <Confirm Password> as different 
	And click on save button
	Then I Should get a validation Error saying "The password and confirm password do not match."
	
	Examples: 
	| username                        | Password  | New Password | Confirm Password |
	| lnpmsapi+qatestlatest72@gmail.com | Password1 | Password2    | Password3        |

@ChangePasswordPage @validations @IncorrectOldPassword
Scenario Outline:  Change Password Page validation message for Old password
	Given I have a valid Credentials
	And I logged into Auth UI Site
	When I select the Change Password link on the left panel
	And I enter the old <old Password> 
	And enter values in <New Password> and <Confirm Password> as same
	And click on save button
	Then I Should get a validation Error displayed as "Old password entered in not correct."
	
	Examples: 
	| old Password | New Password | Confirm Password |
	| Password123  | Password2    | Password2        |

@ChangePasswordPage @validations @IncorrectOldPassword
Scenario Outline: Change Password Page validation message for same password 
	Given I have a valid Credentials
	And I logged into Auth UI Site
	When I select the Change Password link on the left panel
	And I enter the old <old Password> 
	And enter values in <New Password> and <Confirm Password> as same
	And click on save button
	Then I should get Error Message "'New Password' must not be the same as 'Old Password'"
	
	Examples: 
	| old Password | New Password | Confirm Password |
	| Password1    | Password1    | Password1        |