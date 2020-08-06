using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OrangeHRMProject;
using System.Threading;

namespace HRMTests
{
    [TestClass]
    public class HRMTests
    {
        OpenAndClose setup;
        IWebDriver driver;

        [TestInitialize]
        public void SetUp()
        {
            setup = new OpenAndClose();
            driver = setup.Open(null);
        }

        [TestCleanup]
        public void TearDown()
        {
            setup.Close();
        }

        [TestMethod]
        public void TestLoginPageLogoAndLoginHeader()
        {
            LoginPage login = new LoginPage(driver);
            //verifies Login page Logo
            Assert.AreEqual("", login.Logo.Text, "Text doesn't match");
            //verifies login page Header
            Assert.AreEqual("LOGIN Panel", login.LoginHeading.Text, "Heading doesn't match");
        }

        [TestMethod]
        [DataRow("Admin", "admin123", null)]
        [DataRow("Admin", "q2343254", "Invalid credentials")]
        [DataRow("asdfds890", "admin123", "Invalid credentials")]
        [DataRow("", "admin123", "Username cannot be empty")]
        [DataRow("Admin", "", "Password cannot be empty")]
        [DataRow("", "", "Username cannot be empty")]
        [DataRow("null", "null", "Invalid credentials")]
        [DataRow("-23@@#$", "+_@#$3", "Invalid credentials")]
        public void TestLoginPanel(string username, string password, string errormsg = null)
        {
            //logs in
            LoginPage login = Login(username, password);
            Thread.Sleep(1000);
            if (errormsg == null)
            {
                Assert.AreEqual("OrangeHRM", driver.Title, "Title does not match");
            }
            else if (errormsg != null)
            {
                Assert.AreEqual(errormsg, login.ErrorMessageField.Text, "Error msg does not match");
            }
        }
        //helper method to Login
        private LoginPage Login(string username, string password)
        {
            Thread.Sleep(1000);
            LoginPage login = new LoginPage(driver);
            login.UsernameTextBox.Click();
            login.UsernameTextBox.SendKeys(username);
            login.PasswordTextBox.Clear();
            login.PasswordTextBox.SendKeys(password);
            login.LoginButton.Click();
            return login;
        }

        [TestMethod]
        public void TestForgotYourPassword()
        {
            LoginPage login = new LoginPage(driver);
            login.ForgotPasswordLink.Click();
            Assert.AreEqual("Forgot Your Password?", login.ForgotPasswordHeader.Text, "Heading doesn't match");
            login.HrmUserNameTextBox.SendKeys("Admin");
            login.ResetPasswordButton.Click();
            Thread.Sleep(1000);
            login.CancelButton.Click();
            Assert.AreEqual("OrangeHRM", driver.Title, "Title doesn't match");
        }

        [TestMethod]
        [DataRow("Admin", "admin123")]
        public void TestAdminMenuTab(string username, string password)
        {
            LoginPage signin = Login(username, password);
            HomePage home = new HomePage(driver);
            //tests admin tab
            home.AdminMenuTab.Click();
            Assert.AreEqual("Username", home.UserNameHeading.Text, "Heading doesn't match");
            home.UserNameTextBox.SendKeys("linda.anderson");
            home.UserRoleEss.Click();
            home.SearchButton.Click();
            Assert.AreEqual("linda.anderson", home.UserNameResult.Text, "Result doesn't match");
            home.ResetButton.Click();
            Assert.AreEqual("OrangeHRM", driver.Title, "Title doesn't match");
        }

        [TestMethod]
        [DataRow("Admin", "admin123")]
        public void TestPIMSearchByEmployeeName(string username, string password)
        {
            LoginPage signin = Login(username, password);
            HomePage home = new HomePage(driver);
            //test PIM tab by Employee name
            home.PIMMenuTab.Click();
            Assert.AreEqual("Employee Name", home.EmpNameLabel.Text, "Label doesn't match");
            home.EmpNameTextbox.SendKeys("John Smith");
            home.PimSearchButton.Click();
            Assert.AreEqual("John", home.EmpNameResult.Text, "Result doesn't match");
            home.PimResetButton.Click();
        }

        [TestMethod]
        [DataRow("Admin", "admin123")]
        public void TestPIMSearchByID(string username, string password)
        {
            LoginPage signin = Login(username, password);
            HomePage home = new HomePage(driver);
            //test PIM tab by ID
            home.PIMMenuTab.Click();
            Assert.AreEqual("Employee Name", home.EmpNameLabel.Text, "Label doesn't match");
            home.IDTextbox.SendKeys("0006");
            home.PimSearchButton.Click();
            Assert.AreEqual("0006", home.IDResult1.Text, "Result doesn't match");
            home.PimResetButton.Click();
        }

        [TestMethod]
        [DataRow("Admin", "admin123")]
        public void TestPIMSearchBySupervisorName(string username, string password)
        {
            LoginPage signin = Login(username, password);
            HomePage home = new HomePage(driver);
            //test PIM tab by Supervisor name
            home.PIMMenuTab.Click();
            Assert.AreEqual("Employee Name", home.EmpNameLabel.Text, "Label doesn't match");
            home.SupervisorNameTexbox.SendKeys("John Smith");
            home.PimSearchButton.Click();
            Assert.AreEqual("John Smith", home.SupervisorResult.Text, "Result doesn't match");
            home.PimResetButton.Click();
        }
        [TestMethod]
        [DataRow("Admin", "admin123")]
        public void TestPersonalDetails(string username, string password)
        {
            LoginPage signin = Login(username, password);
            HomePage home = new HomePage(driver);

            PersonalDetails(home);
            Thread.Sleep(1000);
            Assert.AreEqual("Full Name", home.FullNameHeader.Text, "Header doesn't match");
            //edits personal details
            home.EditSaveButton.Click();
            Thread.Sleep(500);
            home.FirstNameTextbox.Clear();
            home.FirstNameTextbox.SendKeys("Bradddd");
            home.MiddleNameTextbox.Clear();
            home.MiddleNameTextbox.SendKeys("SSS");
            home.FemaleRadio.Click();
            //home.NationalityDropdown.Click();
            home.DOBDatePicker.Clear();
            home.DOBDatePicker.SendKeys("1980-10-07");
            home.EditSaveButton.Click();
        }

        //helper method to navigate to Personal details page
        private static void PersonalDetails(HomePage home)
        {
            home.PIMMenuTab.Click();
            Assert.AreEqual("Employee Name", home.EmpNameLabel.Text, "Label doesn't match");
            home.IDTextbox.SendKeys("0009");
            home.PimSearchButton.Click();
            Assert.AreEqual("0009", home.IDResult2.Text, "Result doesn't match");
            Thread.Sleep(1000);
            home.IDResult2.Click();
        }

        [TestMethod]
        [DataRow("Admin", "admin123")]
        public void TestContactDetails(string username, string password)
        {
            LoginPage signin = Login(username, password);
            HomePage home = new HomePage(driver);

            PersonalDetails(home);
            Thread.Sleep(1000);
            home.ContactDetailsMenu.Click();
            home.EditSaveButton.Click();
            home.AddressStreet1.Clear();
            home.AddressStreet1.SendKeys("3938 Factoria Sq Mall SE");
            home.City.Clear();
            home.City.SendKeys("Bellevue");
            home.State.Clear();
            home.State.SendKeys("WA");
            home.Zipcode.Clear();
            home.Zipcode.SendKeys("98006");
            home.HomePhone.Clear();
            home.HomePhone.SendKeys("234-456-7890");
            home.OtherEmail.Clear();
            home.OtherEmail.SendKeys("brad@gmail.com");
            home.EditSaveButton.Click();
        }

        [TestMethod]
        [DataRow("Admin", "admin123")]
        public void TestEmergencyContacts(string username, string password)
        {
            LoginPage signin = Login(username, password);
            HomePage home = new HomePage(driver);

            PersonalDetails(home);
            Thread.Sleep(1000);
            home.EmergencyContactTab.Click();
            home.EmerConAddBtn.Click();
            Thread.Sleep(500);
            home.EmerCancelBtn.Click();
            Thread.Sleep(500);
            home.EmerConAddBtn.Click();
            home.EmerName.SendKeys("Tom Hanks");
            home.EmerRelationship.SendKeys("Spouse");
            home.EmerHomePhone.SendKeys("789-221-8900");
            home.EmerSaveContactBtn.Click();
        }

        [TestMethod]
        [DataRow("Admin", "admin123")]
        public void TestEmergencyContactsDeleteButton(string username, string password)
        {
            LoginPage signin = Login(username, password);
            HomePage home = new HomePage(driver);

            PersonalDetails(home);
            Thread.Sleep(1000);
            home.EmergencyContactTab.Click();
            Thread.Sleep(500);
            home.EmerConCheckBox.Click();
            home.EmerConDeleteBtn.Click();
        }
    }
}
