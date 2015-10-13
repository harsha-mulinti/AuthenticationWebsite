using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AuthenticationWebsite.Auth_Specs.UIMAP
{
    /// <summary>
    /// This file contains all the object propeties used in the application
    /// </summary>
    class UIMAP_Repository
    {
      //LogIn Page
        public static string LogInUserId = "Email";
        public static string LogInPassword = "Password";
        public static string SignInButton = "Sign in";
        public static string ForgotPasswordLink = "ForgotPassword";
        public static string LogInPageText = "text-center visible-md-block visible-lg-block sign-in-text";
        public static string LogInError = "validation-summary";
        public static string RecaptchaImage = "recaptcha_image";
        
        //Account Information Page
        public static string AccInfoLink = "/app/Account/AccountInformation";
        public static string AccInfoIcon = "glyphicon glyphicon-user";
        public static string AccInfoPageText = "panel-heading";
        public static string EmailAddress = "Email";
        public static string AlternateEmail = "AlternateEmail";
        public static string AlternateEmailError = "AlternateEmail";
        public static string MobileNumber = "MobilePhoneNumber";
        public static string MobileNumberError = "field-validation-error";

        //Common
        public static string AccountDropdown = "glyphicon glyphicon-triangle-bottom";
        public static string AccDropdownMenu = "dropdown-menu dropdown-menu-right";
        public static string SubmitButton = "Submit";
        public static string SuccessMessage = "toast-message";
        public static string ValidationError = "field-validation-error";

        //Change Password Page
        public static string ChangePasswordLink = "/app/Account/ChangePassword";
        public static string ChangePasswordIcon = "icon-key";
        //public static string ChangePasswordIcon = "glyphicon glyphicon-pencil";
        public static string OldPassword = "OldPassword";
        public static string NewPassword = "Password";
        public static string ConfirmPassword = "ConfirmPassword";
        public static string NewPasswordError = "Password";
        public static string ConfirmPasswordError = "ConfirmPassword";
        public static string PasswordValidationError = "validation-summary-errors alert alert-danger login-error'";
        
        //Forgot Password Page
        public static string NextButton = "Next";
        public static string CancelButton = "btn btn-default active";
        //public static string CancelButton = "btn btn-primary";  
        public static string VerifyAlternateEmail = "form-control";
        public static string EmailError = "Email";
        public static string AccountValidationError = "validation-summary-errors alert alert-danger";

    }
}
