// CustomAddADUser
// Author: Joseph Ryan Ries, 2014
// Email:  ryanries09@gmail.com
// Web:    myotherpcisacloud.com
//
// An alternative GUI to add users to Active Directory. Designed to be a replacement for the GUI to add
// users in ADUC because it offers more flexibility by allowing certain attributes to be marked as mandatory, without
// needing to modify the AD schema.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.DirectoryServices.AccountManagement;

namespace CustomAddADUser
{
    public partial class CustomAddADUserMainForm : Form
    {
        int numOUs = 0;
        int numContainers = 0;
        int minPwdLength = 0;
        public static string domainDnsName = string.Empty;
        bool? givenNameRequired,
            middleNameRequired,
            surnameRequired,
            initialsRequired,
            displayNameRequired,
            emailAddressRequired,
            employeeIDRequired,
            employeeNumberRequired,
            descriptionRequired,
            userPrincipalNameRequired,
            telephoneNumberRequired;
        string givenNameRegex = string.Empty;
        string middleNameRegex = string.Empty;
        string surnameRegex = string.Empty;
        string initialsRegex = string.Empty;
        string displayNameRegex = string.Empty;
        string emailAddressRegex = string.Empty;
        string employeeIDRegex = string.Empty;
        string employeeNumberRegex = string.Empty;
        string descriptionRegex = string.Empty;
        string sAMAccountNameRegex = string.Empty;
        string passwordRegex = string.Empty;
        string userPrincipalNameRegex = string.Empty;
        string telephoneNumberRegex = string.Empty;
        string emailAddressSuffix = string.Empty;
        
        Dictionary<string, string> cnDnDictionary = new Dictionary<string, string>();

        public static string foundUserToCopy;
        
        // May use in the future.
        [Flags()]
        public enum UserAccountControl : int
        {
            SCRIPT = 0x00000001,
            ACCOUNTDISABLE = 0x00000002,
            HOMEDIR_REQUIRED = 0x00000008,
            LOCKOUT = 0x00000010,
            PASSWD_NOTREQD = 0x00000020,
            PASSWD_CANT_CHANGE = 0x00000040,
            ENCRYPTED_TEXT_PASSWORD_ALLOWED = 0x00000080,
            TEMP_DUPLICATE_ACCOUNT = 0x00000100,
            NORMAL_ACCOUNT = 0x00000200,
            INTERDOMAIN_TRUST_ACCOUNT = 0x00000800,
            WORKSTATION_TRUST_ACCOUNT = 0x00001000,
            SERVER_TRUST_ACCOUNT = 0x00002000,
            Unused1 = 0x00004000,
            Unused2 = 0x00008000,
            DONT_EXPIRE_PASSWD = 0x00010000,
            MNS_LOGON_ACCOUNT = 0x00020000,
            SMARTCARD_REQUIRED = 0x00040000,
            TRUSTED_FOR_DELEGATION = 0x00080000,
            NOT_DELEGATED = 0x00100000,
            USE_DES_KEY_ONLY = 0x00200000,
            DONT_REQUIRE_PREAUTH = 0x00400000,
            PASSWORD_EXPIRED = 0x00800000,
            TRUSTED_TO_AUTHENTICATE_FOR_DELEGATION = 0x01000000,
            PARTIAL_SECRETS_ACCOUNT = 0x04000000,
            USE_AES_KEYS = 0x08000000
        }

        public CustomAddADUserMainForm()
        {
            InitializeComponent();            
        }

        private void CustomAddADUserMainForm_Load(object sender, EventArgs e)
        {            
            if (LoadAppConfigSettings() == false)
            {
                MessageBox.Show("An exception occured while attempting to read the app.config file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }
            try
            {
                using (Domain currentDomain = Domain.GetCurrentDomain())
                {
                    domainDnsName = currentDomain.Name;
                    AddActivityItem(Application.ProductName + " " + Application.ProductVersion.Split('.')[0] + "." + Application.ProductVersion.Split('.')[0] + " started by " + Environment.UserDomainName + "\\" + Environment.UserName + ".");
                    AddActivityItem("Connected to " + domainDnsName + ".");
                    AddActivityItem("Loading directory, please wait...");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("This application must be run from an Active Directory domain-joined computer and must be able to communicate with a domain controller.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }
            LockUI();
            populateCreateInComboBoxBackgroundWorker.RunWorkerAsync();
        }

        private void AddDirectoryNodeToComboBox(DirectoryEntry node)
        {
            node.RefreshCache(new string[] { "canonicalName" });
            if (node.Properties["objectClass"].Count == 3 && (string)node.Properties["objectClass"][2] == "domainDNS")
            {
                minPwdLength = (int)node.Properties["minPwdLength"][0];                
                createInComboBox.Items.Add(node.Properties["canonicalName"][0]);
                cnDnDictionary.Add((string)node.Properties["canonicalName"][0], (string)node.Properties["distinguishedName"][0]);
                foreach (DirectoryEntry child in node.Children)
                {
                    AddDirectoryNodeToComboBox(child);
                }
            }
            
            if (node.Properties["objectClass"].Count == 2 && ((string)node.Properties["objectClass"][1] == "organizationalUnit") || (string)node.Properties["objectClass"][1] == "container")
            {
                if (node.Properties["showInAdvancedViewOnly"].Count == 1)
                {
                    if ((bool)node.Properties["showInAdvancedViewOnly"][0] == false)
                    {
                        if ((string)node.Properties["objectClass"][1] == "organizationalUnit")                        
                            numOUs++;                        
                        else if ((string)node.Properties["objectClass"][1] == "container")                        
                            numContainers++;
                        
                        createInComboBox.Items.Add(node.Properties["canonicalName"][0]);
                        cnDnDictionary.Add((string)node.Properties["canonicalName"][0], (string)node.Properties["distinguishedName"][0]);
                        foreach (DirectoryEntry child in node.Children)                        
                            AddDirectoryNodeToComboBox(child);                        
                    }
                }
                else
                {
                    if ((string)node.Properties["objectClass"][1] == "organizationalUnit")                    
                        numOUs++;                    
                    else if ((string)node.Properties["objectClass"][1] == "container")                    
                        numContainers++;
                    
                    createInComboBox.Items.Add(node.Properties["canonicalName"][0]);
                    cnDnDictionary.Add((string)node.Properties["canonicalName"][0], (string)node.Properties["distinguishedName"][0]);
                    foreach (DirectoryEntry child in node.Children)                    
                        AddDirectoryNodeToComboBox(child);
                    
                }
            }            
        }
        
        private bool LoadAppConfigSettings()
        {
            try
            {
                this.Text = ConfigurationManager.AppSettings.Get("MainFormTitle");
                this.Icon = new Icon(ConfigurationManager.AppSettings.Get("MainFormIcon"));
                findUserButton.Image = new Bitmap(ConfigurationManager.AppSettings.Get("SearchIcon"));
                mainFormPictureBox1.Image = new Bitmap(ConfigurationManager.AppSettings.Get("MainFormLogo"));

                string aboutPage = ConfigurationManager.AppSettings.Get("AboutPage");
                if (aboutPage.StartsWith("\\"))
                    aboutPage = aboutPage.TrimStart('\\');

                webBrowser1.Url = new Uri(Directory.GetCurrentDirectory() + "\\" + aboutPage);

                givenNameRequired = bool.Parse(ConfigurationManager.AppSettings.Get("givenNameRequired"));
                middleNameRequired = bool.Parse(ConfigurationManager.AppSettings.Get("middleNameRequired"));
                surnameRequired = bool.Parse(ConfigurationManager.AppSettings.Get("surnameRequired"));
                initialsRequired = bool.Parse(ConfigurationManager.AppSettings.Get("initialsRequired"));
                displayNameRequired = bool.Parse(ConfigurationManager.AppSettings.Get("displayNameRequired"));
                emailAddressRequired = bool.Parse(ConfigurationManager.AppSettings.Get("emailAddressRequired"));
                employeeIDRequired = bool.Parse(ConfigurationManager.AppSettings.Get("employeeIDRequired"));
                employeeNumberRequired = bool.Parse(ConfigurationManager.AppSettings.Get("employeeNumberRequired"));
                descriptionRequired = bool.Parse(ConfigurationManager.AppSettings.Get("descriptionRequired"));
                userPrincipalNameRequired = bool.Parse(ConfigurationManager.AppSettings.Get("userPrincipalNameRequired"));
                telephoneNumberRequired = bool.Parse(ConfigurationManager.AppSettings.Get("telephoneNumberRequired"));

                givenNameRegex = ConfigurationManager.AppSettings.Get("givenNameRegex");
                middleNameRegex = ConfigurationManager.AppSettings.Get("middleNameRegex");
                surnameRegex = ConfigurationManager.AppSettings.Get("surnameRegex");
                initialsRegex = ConfigurationManager.AppSettings.Get("initialsRegex");
                displayNameRegex = ConfigurationManager.AppSettings.Get("displayNameRegex");
                emailAddressRegex = ConfigurationManager.AppSettings.Get("emailAddressRegex");
                employeeIDRegex = ConfigurationManager.AppSettings.Get("employeeIDRegex");
                employeeNumberRegex = ConfigurationManager.AppSettings.Get("employeeNumberRegex");
                descriptionRegex = ConfigurationManager.AppSettings.Get("descriptionRegex");
                sAMAccountNameRegex = ConfigurationManager.AppSettings.Get("sAMAccountNameRegex");
                passwordRegex = ConfigurationManager.AppSettings.Get("passwordRegex");
                userPrincipalNameRegex = ConfigurationManager.AppSettings.Get("userPrincipalNameRegex");
                telephoneNumberRegex = ConfigurationManager.AppSettings.Get("telephoneNumberRegex");

                emailAddressSuffix = ConfigurationManager.AppSettings.Get("emailAddressSuffix");
                emailTextBox.Text = emailAddressSuffix;
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void AddActivityItem(string item)
        {
            activityListBox.BackColor = SystemColors.Window;
            activityListBox.Items.Add(DateTime.Now.ToString("MM/dd HH:mm:ss") + ": " + item);
            activityListBox.SelectedIndex = activityListBox.Items.Count - 1;
        }

        private void LockUI()
        {
            this.UseWaitCursor = true;
            this.tabControl1.Enabled = false;
            for (int i = 0; i < this.tabControl1.TabPages.Count; i++)
                foreach (Control ctrl in this.tabControl1.TabPages[i].Controls)
                    ctrl.Enabled = false;
        }

        private void UnlockUI()
        {
            this.UseWaitCursor = false;
            this.tabControl1.Enabled = true;
            for (int i = 0; i < this.tabControl1.TabPages.Count; i++)
                foreach (Control ctrl in this.tabControl1.TabPages[i].Controls)
                    ctrl.Enabled = true;
        }

        private void populateCreateInComboBoxBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {            
            using (Domain currentDomain = Domain.GetCurrentDomain())
            using (DirectoryEntry directoryEntry = currentDomain.GetDirectoryEntry())            
                AddDirectoryNodeToComboBox(directoryEntry);
        }

        private void populateCreateInComboBoxBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UnlockUI();
            createInComboBox.SelectedIndex = 0;
            AddActivityItem("Directory loaded. " + numOUs + " OUs and " + numContainers + " containers found.");
            AddActivityItem("Domain minimum password length: " + minPwdLength + ".");
        }

        private void createUserButton_Click(object sender, EventArgs e)
        {            
            if (sAMAccountNameTextBox.Text.Trim().Length < 1 || sAMAccountNameTextBox.Text.IndexOfAny("\"[]:;|=+*?<>/\\, ".ToCharArray()) != -1)
            {
                sAMAccountNameTextBox.BackColor = Color.Pink;
                AddActivityItem("sAMAccountName cannot be blank or contain the characters \"[]:;|=+*?<>/\\");
                return;
            }
            if (!Regex.Match(sAMAccountNameTextBox.Text, sAMAccountNameRegex, RegexOptions.IgnoreCase).Success)
            {
                sAMAccountNameTextBox.BackColor = Color.Pink;
                AddActivityItem("sAMAccountName must match regex pattern " + sAMAccountNameRegex + ".");
                return;
            }

            if (passwordTextBox.Text.Length < minPwdLength)
            {
                passwordTextBox.BackColor = Color.Pink;
                AddActivityItem("Password must be at least " + minPwdLength + " characters long.");
                return;
            }
            if (!Regex.Match(passwordTextBox.Text, passwordRegex).Success)
            {
                passwordTextBox.BackColor = Color.Pink;
                AddActivityItem("Password must match regex pattern " + passwordRegex + ".");
                return;
            }

            if ((bool)givenNameRequired & givenNameTextBox.Text.Length < 1)
            {
                givenNameTextBox.BackColor = Color.Pink;
                AddActivityItem("GivenName is required.");
                return;
            }
            if (givenNameTextBox.Text.Length > 0 & !Regex.Match(givenNameTextBox.Text,  givenNameRegex, RegexOptions.IgnoreCase).Success)
            {
                givenNameTextBox.BackColor = Color.Pink;
                AddActivityItem("GivenName must match regex pattern " + givenNameRegex + ".");
                return;
            }

            if ((bool)middleNameRequired & middleNameTextBox.Text.Length < 1)
            {
                middleNameTextBox.BackColor = Color.Pink;
                AddActivityItem("MiddleName is required.");
                return;
            }
            if (middleNameTextBox.Text.Length > 0 & !Regex.Match(middleNameTextBox.Text, middleNameRegex, RegexOptions.IgnoreCase).Success)
            {
                middleNameTextBox.BackColor = Color.Pink;
                AddActivityItem("MiddleName must match regex pattern " + middleNameRegex + ".");
                return;
            }

            if ((bool)surnameRequired & surnameTextBox.Text.Length < 1)
            {
                surnameTextBox.BackColor = Color.Pink;
                AddActivityItem("Surname is required.");
                return;
            }
            if (surnameTextBox.Text.Length > 0 & !Regex.Match(surnameTextBox.Text, surnameRegex, RegexOptions.IgnoreCase).Success)
            {
                surnameTextBox.BackColor = Color.Pink;
                AddActivityItem("Surname must match regex pattern " + surnameRegex + ".");
                return;
            }

            if ((bool)initialsRequired & initialsTextBox.Text.Length < 1)
            {
                initialsTextBox.BackColor = Color.Pink;
                AddActivityItem("Initials required.");
                return;
            }
            if (initialsTextBox.Text.Length > 0 & !Regex.Match(initialsTextBox.Text, initialsRegex, RegexOptions.IgnoreCase).Success)
            {
                initialsTextBox.BackColor = Color.Pink;
                AddActivityItem("Initials must match regex pattern " + initialsRegex + ".");
                return;
            }

            if ((bool)displayNameRequired & displayNameTextBox.Text.Length < 1)
            {
                displayNameTextBox.BackColor = Color.Pink;
                AddActivityItem("Display Name is required.");
                return;
            }
            if (displayNameTextBox.Text.Length > 0 & !Regex.Match(displayNameTextBox.Text, displayNameRegex, RegexOptions.IgnoreCase).Success)
            {
                displayNameTextBox.BackColor = Color.Pink;
                AddActivityItem("Display Name must match regex pattern " + displayNameRegex + ".");
                return;
            }

            if ((bool)emailAddressRequired & emailTextBox.Text.Length < 1)
            {
                emailTextBox.BackColor = Color.Pink;
                AddActivityItem("Email address is required.");
                return;
            }
            if (emailTextBox.Text.Length > 0 & !Regex.Match(emailTextBox.Text, emailAddressRegex, RegexOptions.IgnoreCase).Success)
            {
                emailTextBox.BackColor = Color.Pink;
                AddActivityItem("Email address must match regex pattern " + emailAddressRegex + ".");
                return;
            }

            if ((bool)employeeIDRequired & employeeIDTextBox.Text.Length < 1)
            {
                employeeIDTextBox.BackColor = Color.Pink;
                AddActivityItem("EmployeeID is required.");
                return;
            }
            if (employeeIDTextBox.Text.Length > 0 & !Regex.Match(employeeIDTextBox.Text, employeeIDRegex, RegexOptions.IgnoreCase).Success)
            {
                employeeIDTextBox.BackColor = Color.Pink;
                AddActivityItem("EmployeeID must match regex pattern " + employeeIDRegex + ".");
                return;
            }

            if ((bool)employeeNumberRequired & employeeNumberTextBox.Text.Length < 1)
            {
                employeeNumberTextBox.BackColor = Color.Pink;
                AddActivityItem("EmployeeNumber is required.");
                return;
            }
            if (employeeNumberTextBox.Text.Length > 0 & !Regex.Match(employeeNumberTextBox.Text, employeeNumberRegex, RegexOptions.IgnoreCase).Success)
            {
                employeeNumberTextBox.BackColor = Color.Pink;
                AddActivityItem("EmployeeNumber must match regex pattern " + employeeNumberRegex + ".");
                return;
            }

            if ((bool)descriptionRequired & descriptionTextBox.Text.Length < 1)
            {
                descriptionTextBox.BackColor = Color.Pink;
                AddActivityItem("Description is required.");
                return;
            }
            if (descriptionTextBox.Text.Length > 0 & !Regex.Match(descriptionTextBox.Text, descriptionRegex, RegexOptions.IgnoreCase).Success)
            {
                descriptionTextBox.BackColor = Color.Pink;
                AddActivityItem("Description must match regex pattern " + descriptionRegex + ".");
                return;
            }

            if ((bool)userPrincipalNameRequired & userPrincipalNameTextBox.Text.Length < 1)
            {
                userPrincipalNameTextBox.BackColor = Color.Pink;
                AddActivityItem("UserPrincipalName is required.");
                return;
            }
            if (userPrincipalNameTextBox.Text.Length > 0 & !Regex.Match(userPrincipalNameTextBox.Text, userPrincipalNameRegex, RegexOptions.IgnoreCase).Success)
            {
                userPrincipalNameTextBox.BackColor = Color.Pink;
                AddActivityItem("UserPrincipalName must match regex pattern " + userPrincipalNameRegex + ".");
                return;
            }

            if ((bool)telephoneNumberRequired & telephoneNumberTextBox.Text.Length < 1)
            {
                telephoneNumberTextBox.BackColor = Color.Pink;
                AddActivityItem("Telephone Number is required.");
                return;
            }
            if (telephoneNumberTextBox.Text.Length > 0 & !Regex.Match(telephoneNumberTextBox.Text, telephoneNumberRegex, RegexOptions.IgnoreCase).Success)
            {
                telephoneNumberTextBox.BackColor = Color.Pink;
                AddActivityItem("Telephone Number must match regex pattern " + telephoneNumberRegex + ".");
                return;
            }
            
            AddActivityItem("Creating user " + sAMAccountNameTextBox.Text + "...");
            LockUI();
            createNewUserBackgroundWorker.RunWorkerAsync();
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.BackColor = SystemColors.Window;            
        }
        private void ComboBox_TextChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            cb.BackColor = SystemColors.Window;
            copyFromComboBox.Items.Clear();
        }

        private void createNewUserBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {            
            try
            {                
                using (var principalContext = new PrincipalContext(ContextType.Domain, domainDnsName, cnDnDictionary[createInComboBox.Text]))
                {
                    using (var checkForExistingUser = UserPrincipal.FindByIdentity(principalContext, sAMAccountNameTextBox.Text))
                    {
                        if (checkForExistingUser != null)
                        {
                            AddActivityItem(sAMAccountNameTextBox.Text + " already exists. Use a different sAMAccountName.");
                            activityListBox.BackColor = Color.Pink;
                            return;
                        }
                    }
                    using (var newUser = new UserPrincipal(principalContext))
                    {
                        newUser.SamAccountName = sAMAccountNameTextBox.Text;
                        if (givenNameTextBox.Text.Length > 0)
                            newUser.GivenName = givenNameTextBox.Text;

                        if (middleNameTextBox.Text.Length > 0)
                            newUser.MiddleName = middleNameTextBox.Text;

                        if (surnameTextBox.Text.Length > 0)
                            newUser.Surname = surnameTextBox.Text;

                        if (displayNameTextBox.Text.Length > 0)
                            newUser.DisplayName = displayNameTextBox.Text;

                        if (emailTextBox.Text.Length > 0)
                            newUser.EmailAddress = emailTextBox.Text;

                        if (employeeIDTextBox.Text.Length > 0)
                            newUser.EmployeeId = employeeIDTextBox.Text;

                        if (descriptionTextBox.Text.Length > 0)
                            newUser.Description = descriptionTextBox.Text;

                        if (userPrincipalNameTextBox.Text.Length > 0)
                            newUser.UserPrincipalName = userPrincipalNameTextBox.Text;

                        newUser.SetPassword(passwordTextBox.Text);
                        
                        if (userEnabledCheckBox.Checked)
                            newUser.Enabled = true;

                        if (changePasswordCheckBox.Checked)
                            newUser.ExpirePasswordNow();

                        if (passwordNeverExpiresCheckBox.Checked)
                            newUser.PasswordNeverExpires = true;

                        newUser.Save();

                        if (!string.IsNullOrEmpty(copyFromComboBox.Text))
                        {
                            using (PrincipalSearchResult<Principal> newUsersExistingGroupMemberships = newUser.GetAuthorizationGroups())
                            using (var userToCopyFrom = UserPrincipal.FindByIdentity(principalContext, copyFromComboBox.Text))
                            {
                                using (PrincipalSearchResult<Principal> groups = userToCopyFrom.GetAuthorizationGroups())
                                {
                                    foreach (GroupPrincipal groupPrincipal in groups)
                                    {
                                        bool newUserIsAlreadyAMember = false;
                                        foreach (GroupPrincipal existingGroupMembership in newUsersExistingGroupMemberships)
                                        {
                                            if (existingGroupMembership.Name == groupPrincipal.Name)
                                                newUserIsAlreadyAMember = true;
                                        }
                                        if (newUserIsAlreadyAMember == false)
                                        {
                                            groupPrincipal.Members.Add(newUser);
                                            groupPrincipal.Save();
                                            AddActivityItem("User added to group: " + groupPrincipal.Name);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            AddActivityItem("No group memberships were copied.");
                        }                        

                        // To set additional attributes beyond those provided by UserPrincipal, we must drop down to the underlying object.
                        using (DirectoryEntry newUserEntry = (DirectoryEntry)newUser.GetUnderlyingObject())
                        {
                            if (initialsTextBox.Text.Length > 0)
                                newUserEntry.Properties["initials"].Value = initialsTextBox.Text;

                            if (employeeNumberTextBox.Text.Length > 0)
                                newUserEntry.Properties["employeeNumber"].Value = employeeNumberTextBox.Text;

                            if (telephoneNumberTextBox.Text.Length > 0)
                                newUserEntry.Properties["telephoneNumber"].Value = telephoneNumberTextBox.Text;

                            newUserEntry.CommitChanges();
                        }
                        AddActivityItem("User " + newUser.SamAccountName + " created successfully.");
                        foreach (Control ctrl in tabControl1.TabPages[0].Controls)                        
                            if (ctrl is TextBox)
                                ctrl.Text = string.Empty;
                        
                    }
                }
            }
            catch (Exception ex)
            {
                AddActivityItem("Error: " + ex.Message);
                activityListBox.BackColor = Color.Pink;            
            }
        }

        private void createNewUserBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UnlockUI();
        }

        private void Control_MouseHover(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            string toolStripText = string.Empty;

            if (ctrl == createInComboBox || ctrl == createInLabel)
                toolStripText = "DN: " + cnDnDictionary[createInComboBox.Text];
            else if (ctrl == givenNameTextBox || ctrl == givenNameLabel)
                toolStripText = givenNameTextBox.MaxLength + " char max. LDAP: givenName. Also known as first name.";
            else if (ctrl == middleNameTextBox || ctrl == middleNameLabel)
                toolStripText = middleNameTextBox.MaxLength + " char max. LDAP: middleName.";
            else if (ctrl == surnameTextBox || ctrl == surnameLabel)
                toolStripText = surnameTextBox.MaxLength + " char max. LDAP: sn.";
            else if (ctrl == initialsTextBox || ctrl == initialsLabel)
                toolStripText = initialsTextBox.MaxLength + " char max. LDAP: initials.";
            else if (ctrl == displayNameTextBox || ctrl == displayNameLabel)
                toolStripText = displayNameTextBox.MaxLength + " char max. LDAP: displayName.";
            else if (ctrl == emailTextBox || ctrl == emailLabel)
                toolStripText = emailTextBox.MaxLength + " char max. LDAP: mail.";
            else if (ctrl == employeeIDTextBox || ctrl == empIDLabel)
                toolStripText = employeeIDTextBox.MaxLength + " char max. LDAP: employeeID.";
            else if (ctrl == employeeNumberTextBox || ctrl == empNumberLabel)
                toolStripText = employeeNumberTextBox.MaxLength + " char max. LDAP: employeeNumber.";
            else if (ctrl == descriptionTextBox || ctrl == descriptionLabel)
                toolStripText = descriptionTextBox.MaxLength + " char max. LDAP: description.";
            else if (ctrl == sAMAccountNameTextBox || ctrl == sAMAccountNameLabel)
                toolStripText = sAMAccountNameTextBox.MaxLength + " char max. LDAP: sAMAccountName.";
            else if (ctrl == passwordTextBox || ctrl == passwordLabel)
                toolStripText = passwordTextBox.MaxLength + " char max. LDAP. unicodePWd.";
            else if (ctrl == userPrincipalNameTextBox || ctrl == userPrincipalNameLabel)
                toolStripText = userPrincipalNameTextBox.MaxLength + " char max. LDAP: userPrincipalName.";
            else if (ctrl == telephoneNumberTextBox || ctrl == telephoneNumberLabel)
                toolStripText = telephoneNumberTextBox.MaxLength + " char max. LDAP: telephoneNumber.";
            else if (ctrl == copyFromComboBox || ctrl == copyFromLabel)
                toolStripText = "Group memberships from this user will be copied to the new user.";
            else if (ctrl == findUserButton)
                toolStripText = "Find an existing user from whom to copy group memberships.";
            else if (ctrl == activityListBox)
                toolStripText = "Important status messages are displayed here.";
            else if (ctrl == newUserTabPage)
                toolStripText = string.Empty;

            toolStripStatusLabel1.Text = toolStripText;
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {            
            if (tabControl1.SelectedIndex == 0)            
                toolStripStatusLabel1.Text = "Create a new user.";            
            else if (tabControl1.SelectedIndex == 1)
                toolStripStatusLabel1.Text = "Author: Ryan Ries - myotherpcisacloud.com - github.com/ryanries";            
        }

        private void initialsTextBox_Enter(object sender, EventArgs e)
        {            
            if (initialsTextBox.Text.Length < 1)
            {
                StringBuilder sb = new StringBuilder();
                if (!string.IsNullOrEmpty(givenNameTextBox.Text))
                    sb.Append(givenNameTextBox.Text.ToUpper()[0]);

                if (!string.IsNullOrEmpty(middleNameTextBox.Text))
                    sb.Append(middleNameTextBox.Text.ToUpper()[0]);

                if (!string.IsNullOrEmpty(surnameTextBox.Text))
                    sb.Append(surnameTextBox.Text.ToUpper()[0]);

                initialsTextBox.Text = sb.ToString().Trim();
            }
        }

        private void displayNameTextBox_Enter(object sender, EventArgs e)
        {
            if (displayNameTextBox.Text.Length < 1)
            {
                StringBuilder sb = new StringBuilder();
                if (!string.IsNullOrEmpty(surnameTextBox.Text))
                    sb.Append(surnameTextBox.Text);

                sb.Append(", ");

                if (!string.IsNullOrEmpty(givenNameTextBox.Text))
                    sb.Append(givenNameTextBox.Text);

                sb.Append(" ");

                if (!string.IsNullOrEmpty(middleNameTextBox.Text))
                    sb.Append(middleNameTextBox.Text);

                displayNameTextBox.Text = sb.ToString().Trim();
            }
        }

        private void userPrincipalNameTextBox_Enter(object sender, EventArgs e)
        {
            if (userPrincipalNameTextBox.Text.Length < 1 & sAMAccountNameTextBox.Text.Length > 0 & domainDnsName.Length > 0)
                userPrincipalNameTextBox.Text = sAMAccountNameTextBox.Text + "@" + domainDnsName;
        }

        private void copyFromComboBox_Enter(object sender, EventArgs e)
        {
            copyFromComboBox.Items.Clear();
            using (PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, domainDnsName, cnDnDictionary[createInComboBox.Text]))
            using (UserPrincipal qbeUser = new UserPrincipal(principalContext))
            using (PrincipalSearcher pSearcher = new PrincipalSearcher(qbeUser))
            {
                foreach (UserPrincipal found in pSearcher.FindAll())                
                    if ((bool)found.Enabled)
                        copyFromComboBox.Items.Add(found.SamAccountName);
                
            }
        }

        private void givenNameTextBox_Leave(object sender, EventArgs e)
        {
            givenNameTextBox.Text = givenNameTextBox.Text.Trim();
            if (givenNameTextBox.Text.Length > 0)
                givenNameTextBox.Text = char.ToUpper(givenNameTextBox.Text[0]) + givenNameTextBox.Text.Substring(1);
        }

        private void middleNameTextBox_Leave(object sender, EventArgs e)
        {
            middleNameTextBox.Text = middleNameTextBox.Text.Trim();
            if (middleNameTextBox.Text.Length > 0)
                middleNameTextBox.Text = char.ToUpper(middleNameTextBox.Text[0]) + middleNameTextBox.Text.Substring(1);
        }

        private void surnameTextBox_Leave(object sender, EventArgs e)
        {
            surnameTextBox.Text = surnameTextBox.Text.Trim();
            if (surnameTextBox.Text.Length > 0)
                surnameTextBox.Text = char.ToUpper(surnameTextBox.Text[0]) + surnameTextBox.Text.Substring(1);
        }

        private void findUserButton_Click(object sender, EventArgs e)
        {            
            using (FindUserForm findUserForm = new FindUserForm())            
                findUserForm.ShowDialog(this);

            if (foundUserToCopy != null)
            {
                copyFromComboBox.Items.Clear();
                copyFromComboBox.Items.Add(foundUserToCopy);
                copyFromComboBox.SelectedIndex = copyFromComboBox.Items.Count - 1;
            }
        }
    }
}
