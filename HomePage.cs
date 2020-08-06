using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrangeHRMProject
{
    public class HomePage
    {
        private IWebDriver driver;
        //admin menu elements
        private By adminMenuTab;
        private By userNameHeading;
        private By userNameTextBox;

        private By userRoleAll;
        private By userRoleAdmin;
        private By userRoleESS;

        private By searchButton;
        private By resetButton;
        private By userNameResult;
        //PIM Menu elements
        private By pimMenuTab;
        private By empNameLabel;
        private By empNameTextbox;
        private By idTextbox;
        private By superNameTextbox;

        private By pimSearchButton;
        private By pimResetButton;
        private By empNameResult;
        private By idResult1;
        private By idResult2;
        private By superResult;
        //Personal details
        private By fullNameHeader;
        private By editSaveButton;
        private By firstNameTextbox;
        private By middleNameTextbox;
        private By genderMale;
        private By genderFemale;
        private By nationality;
        private By dateOfBirth;
        // contact details
        private By contactDetailsMenu;
        private By contEditBtn;
        private By street1;
        private By city;
        private By state;
        private By zip;
        private By homePhone;
        private By otherEmail;
        //Emergency contacts
        private By emerContactsTab;
        private By emerAddBtn;
        private By emerDeleteBtn;
        private By emrName;
        private By emrRelation;
        private By emrHomePhone;
        private By emrSaveContact;
        private By emrCancel;
        private By emerChkbox;


        public IWebElement AdminMenuTab { get { return this.driver.FindElement(adminMenuTab); } }
        public IWebElement UserNameHeading { get { return this.driver.FindElement(userNameHeading); } }
        public IWebElement UserNameTextBox { get { return this.driver.FindElement(userNameTextBox); } }
        public IWebElement UserRoleAll { get { return this.driver.FindElement(userRoleAll); } }
        public IWebElement UserRoleAdmin { get { return this.driver.FindElement(userRoleAdmin); } }
        public IWebElement UserRoleEss { get { return this.driver.FindElement(userRoleESS); } }
        public IWebElement SearchButton { get { return this.driver.FindElement(searchButton); } }
        public IWebElement ResetButton { get { return this.driver.FindElement(resetButton); } }
        public IWebElement UserNameResult { get { return this.driver.FindElement(userNameResult); } }

        public IWebElement PIMMenuTab { get { return this.driver.FindElement(pimMenuTab); } }
        public IWebElement EmpNameLabel { get { return this.driver.FindElement(empNameLabel); } }
        public IWebElement EmpNameTextbox { get { return this.driver.FindElement(empNameTextbox); } }
        public IWebElement IDTextbox { get { return this.driver.FindElement(idTextbox); } }
        public IWebElement SupervisorNameTexbox { get { return this.driver.FindElement(superNameTextbox); } }
        public IWebElement PimSearchButton { get { return this.driver.FindElement(pimSearchButton); } }
        public IWebElement PimResetButton { get { return this.driver.FindElement(pimResetButton); } }
        public IWebElement EmpNameResult { get { return this.driver.FindElement(empNameResult); } }
        public IWebElement IDResult1 { get { return this.driver.FindElement(idResult1); } }

        public IWebElement IDResult2 { get { return this.driver.FindElement(idResult2); } }
        public IWebElement SupervisorResult { get { return this.driver.FindElement(superResult); } }
        public IWebElement FullNameHeader { get { return this.driver.FindElement(fullNameHeader); } }
        public IWebElement EditSaveButton { get { return this.driver.FindElement(editSaveButton); } }
        public IWebElement FirstNameTextbox { get { return this.driver.FindElement(firstNameTextbox); } }
        public IWebElement MiddleNameTextbox { get { return this.driver.FindElement(middleNameTextbox); } }
        public IWebElement MaleRadio { get { return this.driver.FindElement(genderMale); } }
        public IWebElement FemaleRadio { get { return this.driver.FindElement(genderFemale); } }
        public IWebElement NationalityDropdown { get { return this.driver.FindElement(nationality); } }
        public IWebElement DOBDatePicker { get { return this.driver.FindElement(dateOfBirth); } }
        public IWebElement ContactDetailsMenu { get { return this.driver.FindElement(contactDetailsMenu); } }
        public IWebElement ContactEditBtn { get { return this.driver.FindElement(contEditBtn); } }
        public IWebElement AddressStreet1 { get { return this.driver.FindElement(street1); } }
        public IWebElement City { get { return this.driver.FindElement(city); } }
        public IWebElement State { get { return this.driver.FindElement(state); } }
        public IWebElement Zipcode { get { return this.driver.FindElement(zip); } }
        public IWebElement HomePhone { get { return this.driver.FindElement(homePhone); } }
        public IWebElement OtherEmail { get { return this.driver.FindElement(otherEmail); } }
        public IWebElement EmergencyContactTab { get { return this.driver.FindElement(emerContactsTab); } }
        public IWebElement EmerConAddBtn { get { return this.driver.FindElement(emerAddBtn); } }
        public IWebElement EmerConDeleteBtn { get { return this.driver.FindElement(emerDeleteBtn); } }
        public IWebElement EmerName { get { return this.driver.FindElement(emrName); } }
        public IWebElement EmerRelationship { get { return this.driver.FindElement(emrRelation); } }
        public IWebElement EmerHomePhone { get { return this.driver.FindElement(emrHomePhone); } }
        public IWebElement EmerSaveContactBtn { get { return this.driver.FindElement(emrSaveContact); } }
        public IWebElement EmerCancelBtn { get { return this.driver.FindElement(emrCancel); } }
        public IWebElement EmerConCheckBox { get { return this.driver.FindElement(emerChkbox); } }


        //helper method to find elements
        private void Init()
        {
            adminMenuTab = By.XPath("//b[contains(text(),'Admin')]");
            userNameHeading = By.XPath("//label[contains(text(),'Username')]");
            userNameTextBox = By.Id("searchSystemUser_userName");
            userRoleAll = By.XPath("//select[@id='searchSystemUser_userType']//option[contains(text(),'All')]");
            userRoleAdmin = By.XPath("//option[contains(text(),'Admin')]");
            userRoleESS = By.XPath("//option[contains(text(),'ESS')]");
            searchButton = By.Id("searchBtn");
            resetButton = By.Id("resetBtn");
            userNameResult = By.XPath("//body//td[2]");
            //PIM MEnu
            pimMenuTab = By.XPath("//b[contains(text(),'PIM')]");
            empNameLabel = By.XPath("//label[contains(text(),'Employee Name')]");
            empNameTextbox = By.Id("empsearch_employee_name_empName");
            idTextbox = By.Id("empsearch_id");
            superNameTextbox = By.Id("empsearch_supervisor_name");
            pimSearchButton = By.Name("_search");
            pimResetButton = By.Name("_reset");
            empNameResult = By.XPath("//a[contains(text(),'John')]");
            idResult1 = By.XPath("//a[contains(text(),'0006')]");
            idResult2 = By.XPath("//a[contains(text(),'0009')]");
            superResult = By.XPath("//tr[2]//td[8]");
            //personal details
            fullNameHeader = By.XPath("//label[@class='hasTopFieldHelp']");
            editSaveButton = By.Id("btnSave");
            firstNameTextbox = By.Id("personal_txtEmpFirstName");
            middleNameTextbox = By.Id("personal_txtEmpMiddleName");
            genderMale = By.XPath("//label[contains(text(),'Male')]");
            genderFemale = By.XPath("//label[contains(text(),'Female')]");
            nationality = By.XPath("//option[contains(text(),'Australian')]");
            dateOfBirth = By.Id("personal_DOB");
            //contact details
            contactDetailsMenu = By.XPath("//a[contains(text(),'Contact Details')]");
            contEditBtn = By.Id("btnSave");
            street1 = By.Id("contact_street1");
            city = By.Id("contact_city");
            state = By.Id("contact_province");
            zip = By.Id("contact_emp_zipcode");
            homePhone = By.Id("contact_emp_hm_telephone");
            otherEmail = By.Id("contact_emp_oth_email");
            //emergency contacts
            emerContactsTab = By.XPath("//a[contains(text(),'Emergency Contacts')]");
            emerAddBtn = By.Id("btnAddContact");
            emerDeleteBtn = By.Id("delContactsBtn");
            emrName = By.Id("emgcontacts_name");
            emrRelation = By.Id("emgcontacts_relationship");
            emrHomePhone = By.Id("emgcontacts_homePhone");
            emrSaveContact = By.Id("btnSaveEContact");
            emrCancel = By.Id("btnCancel");
            emerChkbox = By.Name("chkecontactdel[]");

        }
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            //calls Init method
            this.Init();
        }
    }
}
