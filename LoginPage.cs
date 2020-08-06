using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrangeHRMProject
{
    public class LoginPage
    {
        private IWebDriver driver;

        private By logo;
        private By loginHeading;
        private By userName;
        private By password;
        private By loginButton;
        private By errorMsgField;
        private By forgotPasswordLink;
        private By forgotPasswordHeader;
        private By hrmUsernameTextBox;
        private By resetPasswordButton;
        private By cancelButton;
        //private By forgotPasswordHeader;


        public IWebElement Logo { get { return this.driver.FindElement(logo); } }
        public IWebElement LoginHeading { get { return this.driver.FindElement(loginHeading); } }
        public IWebElement UsernameTextBox { get { return this.driver.FindElement(userName); } }
        public IWebElement PasswordTextBox { get { return this.driver.FindElement(password); } }
        public IWebElement LoginButton { get { return this.driver.FindElement(loginButton); } }
        public IWebElement ErrorMessageField { get { return this.driver.FindElement(errorMsgField); } }
        public IWebElement ForgotPasswordLink { get { return this.driver.FindElement(forgotPasswordLink); } }
        public IWebElement ForgotPasswordHeader { get { return this.driver.FindElement(forgotPasswordHeader); } }
        public IWebElement HrmUserNameTextBox { get { return this.driver.FindElement(hrmUsernameTextBox); } }
        public IWebElement ResetPasswordButton { get { return this.driver.FindElement(resetPasswordButton); } }
        public IWebElement CancelButton { get { return this.driver.FindElement(cancelButton); } }
        //public IWebElement ErrorMessageField { get { return this.driver.FindElement(errorMsgField); } }


        //helper method to find elements
        private void Init()
        {
            loginHeading = By.Id("logInPanelHeading");
            logo = By.XPath("//div[@id='divLogo']//img");
            userName = By.Id("txtUsername");
            password = By.Id("txtPassword");
            loginButton = By.Id("btnLogin");
            errorMsgField = By.Id("spanMessage");
            forgotPasswordLink = By.XPath("//a[contains(text(),'Forgot your password?')]");
            forgotPasswordHeader = By.XPath("//h1[contains(text(),'Forgot Your Password?')]");
            hrmUsernameTextBox = By.Id("securityAuthentication_userName");
            resetPasswordButton = By.Id("btnSearchValues");
            cancelButton = By.Id("btnCancel");
            //hrmUsernameTextBox = By.Id("logInPanelHeading");
            //resetPasswordButton = By.XPath("//div[@id='divLogo']//img");
        }

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            //calls Init method
            this.Init();
        }
        
    }
}
