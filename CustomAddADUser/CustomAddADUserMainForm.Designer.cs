namespace CustomAddADUser
{
    partial class CustomAddADUserMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.activityListBox = new System.Windows.Forms.ListBox();
            this.populateCreateInComboBoxBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.createNewUserBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.aboutTabPage = new System.Windows.Forms.TabPage();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.mainFormPictureBox1 = new System.Windows.Forms.PictureBox();
            this.newUserTabPage = new System.Windows.Forms.TabPage();
            this.findUserButton = new System.Windows.Forms.Button();
            this.copyFromLabel = new System.Windows.Forms.Label();
            this.copyFromComboBox = new System.Windows.Forms.ComboBox();
            this.passwordNeverExpiresCheckBox = new System.Windows.Forms.CheckBox();
            this.userEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.changePasswordCheckBox = new System.Windows.Forms.CheckBox();
            this.displayNameTextBox = new System.Windows.Forms.TextBox();
            this.userPrincipalNameTextBox = new System.Windows.Forms.TextBox();
            this.middleNameTextBox = new System.Windows.Forms.TextBox();
            this.telephoneNumberTextBox = new System.Windows.Forms.TextBox();
            this.sAMAccountNameTextBox = new System.Windows.Forms.TextBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.employeeNumberTextBox = new System.Windows.Forms.TextBox();
            this.employeeIDTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.initialsTextBox = new System.Windows.Forms.TextBox();
            this.surnameTextBox = new System.Windows.Forms.TextBox();
            this.givenNameTextBox = new System.Windows.Forms.TextBox();
            this.displayNameLabel = new System.Windows.Forms.Label();
            this.userPrincipalNameLabel = new System.Windows.Forms.Label();
            this.middleNameLabel = new System.Windows.Forms.Label();
            this.createUserButton = new System.Windows.Forms.Button();
            this.telephoneNumberLabel = new System.Windows.Forms.Label();
            this.sAMAccountNameLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.empNumberLabel = new System.Windows.Forms.Label();
            this.empIDLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.initialsLabel = new System.Windows.Forms.Label();
            this.surnameLabel = new System.Windows.Forms.Label();
            this.givenNameLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.createInComboBox = new System.Windows.Forms.ComboBox();
            this.createInLabel = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.statusStrip1.SuspendLayout();
            this.aboutTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainFormPictureBox1)).BeginInit();
            this.newUserTabPage.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // activityListBox
            // 
            this.activityListBox.FormattingEnabled = true;
            this.activityListBox.HorizontalScrollbar = true;
            this.activityListBox.Location = new System.Drawing.Point(0, 379);
            this.activityListBox.Name = "activityListBox";
            this.activityListBox.Size = new System.Drawing.Size(533, 108);
            this.activityListBox.TabIndex = 99;
            this.activityListBox.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // populateCreateInComboBoxBackgroundWorker
            // 
            this.populateCreateInComboBoxBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.populateCreateInComboBoxBackgroundWorker_DoWork);
            this.populateCreateInComboBoxBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.populateCreateInComboBoxBackgroundWorker_RunWorkerCompleted);
            // 
            // createNewUserBackgroundWorker
            // 
            this.createNewUserBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.createNewUserBackgroundWorker_DoWork);
            this.createNewUserBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.createNewUserBackgroundWorker_RunWorkerCompleted);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 489);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(534, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 100;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(145, 17);
            this.toolStripStatusLabel1.Text = "CustomAddADUser ready.";
            // 
            // aboutTabPage
            // 
            this.aboutTabPage.Controls.Add(this.webBrowser1);
            this.aboutTabPage.Controls.Add(this.mainFormPictureBox1);
            this.aboutTabPage.Location = new System.Drawing.Point(4, 22);
            this.aboutTabPage.Name = "aboutTabPage";
            this.aboutTabPage.Size = new System.Drawing.Size(524, 343);
            this.aboutTabPage.TabIndex = 2;
            this.aboutTabPage.Text = "About";
            this.aboutTabPage.UseVisualStyleBackColor = true;
            // 
            // webBrowser1
            // 
            this.webBrowser1.AllowWebBrowserDrop = false;
            this.webBrowser1.Location = new System.Drawing.Point(7, 81);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(510, 259);
            this.webBrowser1.TabIndex = 3;
            this.webBrowser1.WebBrowserShortcutsEnabled = false;
            // 
            // mainFormPictureBox1
            // 
            this.mainFormPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.mainFormPictureBox1.Location = new System.Drawing.Point(312, 3);
            this.mainFormPictureBox1.Name = "mainFormPictureBox1";
            this.mainFormPictureBox1.Size = new System.Drawing.Size(209, 72);
            this.mainFormPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mainFormPictureBox1.TabIndex = 1;
            this.mainFormPictureBox1.TabStop = false;
            // 
            // newUserTabPage
            // 
            this.newUserTabPage.Controls.Add(this.findUserButton);
            this.newUserTabPage.Controls.Add(this.copyFromLabel);
            this.newUserTabPage.Controls.Add(this.copyFromComboBox);
            this.newUserTabPage.Controls.Add(this.passwordNeverExpiresCheckBox);
            this.newUserTabPage.Controls.Add(this.userEnabledCheckBox);
            this.newUserTabPage.Controls.Add(this.changePasswordCheckBox);
            this.newUserTabPage.Controls.Add(this.displayNameTextBox);
            this.newUserTabPage.Controls.Add(this.userPrincipalNameTextBox);
            this.newUserTabPage.Controls.Add(this.middleNameTextBox);
            this.newUserTabPage.Controls.Add(this.telephoneNumberTextBox);
            this.newUserTabPage.Controls.Add(this.sAMAccountNameTextBox);
            this.newUserTabPage.Controls.Add(this.descriptionTextBox);
            this.newUserTabPage.Controls.Add(this.employeeNumberTextBox);
            this.newUserTabPage.Controls.Add(this.employeeIDTextBox);
            this.newUserTabPage.Controls.Add(this.emailTextBox);
            this.newUserTabPage.Controls.Add(this.initialsTextBox);
            this.newUserTabPage.Controls.Add(this.surnameTextBox);
            this.newUserTabPage.Controls.Add(this.givenNameTextBox);
            this.newUserTabPage.Controls.Add(this.displayNameLabel);
            this.newUserTabPage.Controls.Add(this.userPrincipalNameLabel);
            this.newUserTabPage.Controls.Add(this.middleNameLabel);
            this.newUserTabPage.Controls.Add(this.createUserButton);
            this.newUserTabPage.Controls.Add(this.telephoneNumberLabel);
            this.newUserTabPage.Controls.Add(this.sAMAccountNameLabel);
            this.newUserTabPage.Controls.Add(this.descriptionLabel);
            this.newUserTabPage.Controls.Add(this.empNumberLabel);
            this.newUserTabPage.Controls.Add(this.empIDLabel);
            this.newUserTabPage.Controls.Add(this.emailLabel);
            this.newUserTabPage.Controls.Add(this.passwordLabel);
            this.newUserTabPage.Controls.Add(this.initialsLabel);
            this.newUserTabPage.Controls.Add(this.surnameLabel);
            this.newUserTabPage.Controls.Add(this.givenNameLabel);
            this.newUserTabPage.Controls.Add(this.passwordTextBox);
            this.newUserTabPage.Controls.Add(this.createInComboBox);
            this.newUserTabPage.Controls.Add(this.createInLabel);
            this.newUserTabPage.Location = new System.Drawing.Point(4, 22);
            this.newUserTabPage.Name = "newUserTabPage";
            this.newUserTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.newUserTabPage.Size = new System.Drawing.Size(524, 343);
            this.newUserTabPage.TabIndex = 0;
            this.newUserTabPage.Text = "New User";
            this.newUserTabPage.UseVisualStyleBackColor = true;
            this.newUserTabPage.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // findUserButton
            // 
            this.findUserButton.FlatAppearance.BorderSize = 0;
            this.findUserButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.findUserButton.Location = new System.Drawing.Point(355, 162);
            this.findUserButton.Name = "findUserButton";
            this.findUserButton.Size = new System.Drawing.Size(22, 22);
            this.findUserButton.TabIndex = 102;
            this.findUserButton.UseVisualStyleBackColor = true;
            this.findUserButton.Click += new System.EventHandler(this.findUserButton_Click);
            this.findUserButton.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // copyFromLabel
            // 
            this.copyFromLabel.AutoSize = true;
            this.copyFromLabel.Location = new System.Drawing.Point(293, 139);
            this.copyFromLabel.Name = "copyFromLabel";
            this.copyFromLabel.Size = new System.Drawing.Size(60, 13);
            this.copyFromLabel.TabIndex = 101;
            this.copyFromLabel.Text = "Copy From:";
            this.copyFromLabel.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // copyFromComboBox
            // 
            this.copyFromComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.copyFromComboBox.FormattingEnabled = true;
            this.copyFromComboBox.Location = new System.Drawing.Point(355, 136);
            this.copyFromComboBox.Name = "copyFromComboBox";
            this.copyFromComboBox.Size = new System.Drawing.Size(161, 21);
            this.copyFromComboBox.TabIndex = 14;
            this.copyFromComboBox.Enter += new System.EventHandler(this.copyFromComboBox_Enter);
            this.copyFromComboBox.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // passwordNeverExpiresCheckBox
            // 
            this.passwordNeverExpiresCheckBox.AutoSize = true;
            this.passwordNeverExpiresCheckBox.Location = new System.Drawing.Point(86, 294);
            this.passwordNeverExpiresCheckBox.Name = "passwordNeverExpiresCheckBox";
            this.passwordNeverExpiresCheckBox.Size = new System.Drawing.Size(138, 17);
            this.passwordNeverExpiresCheckBox.TabIndex = 16;
            this.passwordNeverExpiresCheckBox.Text = "Password never expires";
            this.passwordNeverExpiresCheckBox.UseVisualStyleBackColor = true;
            // 
            // userEnabledCheckBox
            // 
            this.userEnabledCheckBox.AutoSize = true;
            this.userEnabledCheckBox.Checked = true;
            this.userEnabledCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.userEnabledCheckBox.Location = new System.Drawing.Point(86, 271);
            this.userEnabledCheckBox.Name = "userEnabledCheckBox";
            this.userEnabledCheckBox.Size = new System.Drawing.Size(99, 17);
            this.userEnabledCheckBox.TabIndex = 15;
            this.userEnabledCheckBox.Text = "User is enabled";
            this.userEnabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // changePasswordCheckBox
            // 
            this.changePasswordCheckBox.AutoSize = true;
            this.changePasswordCheckBox.Checked = true;
            this.changePasswordCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.changePasswordCheckBox.Location = new System.Drawing.Point(86, 317);
            this.changePasswordCheckBox.Name = "changePasswordCheckBox";
            this.changePasswordCheckBox.Size = new System.Drawing.Size(160, 17);
            this.changePasswordCheckBox.TabIndex = 17;
            this.changePasswordCheckBox.Text = "User must change password";
            this.changePasswordCheckBox.UseVisualStyleBackColor = true;
            // 
            // displayNameTextBox
            // 
            this.displayNameTextBox.Location = new System.Drawing.Point(86, 138);
            this.displayNameTextBox.MaxLength = 256;
            this.displayNameTextBox.Name = "displayNameTextBox";
            this.displayNameTextBox.Size = new System.Drawing.Size(163, 20);
            this.displayNameTextBox.TabIndex = 5;
            this.displayNameTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.displayNameTextBox.Enter += new System.EventHandler(this.displayNameTextBox_Enter);
            this.displayNameTextBox.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // userPrincipalNameTextBox
            // 
            this.userPrincipalNameTextBox.Location = new System.Drawing.Point(355, 87);
            this.userPrincipalNameTextBox.MaxLength = 1024;
            this.userPrincipalNameTextBox.Name = "userPrincipalNameTextBox";
            this.userPrincipalNameTextBox.Size = new System.Drawing.Size(162, 20);
            this.userPrincipalNameTextBox.TabIndex = 12;
            this.userPrincipalNameTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.userPrincipalNameTextBox.Enter += new System.EventHandler(this.userPrincipalNameTextBox_Enter);
            this.userPrincipalNameTextBox.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // middleNameTextBox
            // 
            this.middleNameTextBox.Location = new System.Drawing.Point(86, 60);
            this.middleNameTextBox.MaxLength = 64;
            this.middleNameTextBox.Name = "middleNameTextBox";
            this.middleNameTextBox.Size = new System.Drawing.Size(163, 20);
            this.middleNameTextBox.TabIndex = 2;
            this.middleNameTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.middleNameTextBox.Leave += new System.EventHandler(this.middleNameTextBox_Leave);
            this.middleNameTextBox.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // telephoneNumberTextBox
            // 
            this.telephoneNumberTextBox.Location = new System.Drawing.Point(355, 112);
            this.telephoneNumberTextBox.MaxLength = 64;
            this.telephoneNumberTextBox.Name = "telephoneNumberTextBox";
            this.telephoneNumberTextBox.Size = new System.Drawing.Size(162, 20);
            this.telephoneNumberTextBox.TabIndex = 13;
            this.telephoneNumberTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.telephoneNumberTextBox.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // sAMAccountNameTextBox
            // 
            this.sAMAccountNameTextBox.Location = new System.Drawing.Point(355, 34);
            this.sAMAccountNameTextBox.MaxLength = 20;
            this.sAMAccountNameTextBox.Name = "sAMAccountNameTextBox";
            this.sAMAccountNameTextBox.Size = new System.Drawing.Size(163, 20);
            this.sAMAccountNameTextBox.TabIndex = 10;
            this.sAMAccountNameTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.sAMAccountNameTextBox.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(86, 244);
            this.descriptionTextBox.MaxLength = 1024;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(163, 20);
            this.descriptionTextBox.TabIndex = 9;
            this.descriptionTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.descriptionTextBox.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // employeeNumberTextBox
            // 
            this.employeeNumberTextBox.Location = new System.Drawing.Point(86, 218);
            this.employeeNumberTextBox.MaxLength = 512;
            this.employeeNumberTextBox.Name = "employeeNumberTextBox";
            this.employeeNumberTextBox.Size = new System.Drawing.Size(163, 20);
            this.employeeNumberTextBox.TabIndex = 8;
            this.employeeNumberTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.employeeNumberTextBox.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // employeeIDTextBox
            // 
            this.employeeIDTextBox.Location = new System.Drawing.Point(86, 192);
            this.employeeIDTextBox.MaxLength = 16;
            this.employeeIDTextBox.Name = "employeeIDTextBox";
            this.employeeIDTextBox.Size = new System.Drawing.Size(163, 20);
            this.employeeIDTextBox.TabIndex = 7;
            this.employeeIDTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.employeeIDTextBox.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(86, 165);
            this.emailTextBox.MaxLength = 256;
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(163, 20);
            this.emailTextBox.TabIndex = 6;
            this.emailTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.emailTextBox.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // initialsTextBox
            // 
            this.initialsTextBox.Location = new System.Drawing.Point(86, 112);
            this.initialsTextBox.MaxLength = 6;
            this.initialsTextBox.Name = "initialsTextBox";
            this.initialsTextBox.Size = new System.Drawing.Size(61, 20);
            this.initialsTextBox.TabIndex = 4;
            this.initialsTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.initialsTextBox.Enter += new System.EventHandler(this.initialsTextBox_Enter);
            this.initialsTextBox.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // surnameTextBox
            // 
            this.surnameTextBox.Location = new System.Drawing.Point(86, 86);
            this.surnameTextBox.MaxLength = 64;
            this.surnameTextBox.Name = "surnameTextBox";
            this.surnameTextBox.Size = new System.Drawing.Size(163, 20);
            this.surnameTextBox.TabIndex = 3;
            this.surnameTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.surnameTextBox.Leave += new System.EventHandler(this.surnameTextBox_Leave);
            this.surnameTextBox.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // givenNameTextBox
            // 
            this.givenNameTextBox.Location = new System.Drawing.Point(86, 34);
            this.givenNameTextBox.MaxLength = 64;
            this.givenNameTextBox.Name = "givenNameTextBox";
            this.givenNameTextBox.Size = new System.Drawing.Size(163, 20);
            this.givenNameTextBox.TabIndex = 1;
            this.givenNameTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.givenNameTextBox.Leave += new System.EventHandler(this.givenNameTextBox_Leave);
            this.givenNameTextBox.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // displayNameLabel
            // 
            this.displayNameLabel.AutoSize = true;
            this.displayNameLabel.Location = new System.Drawing.Point(9, 141);
            this.displayNameLabel.Name = "displayNameLabel";
            this.displayNameLabel.Size = new System.Drawing.Size(75, 13);
            this.displayNameLabel.TabIndex = 99;
            this.displayNameLabel.Text = "Display Name:";
            this.displayNameLabel.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // userPrincipalNameLabel
            // 
            this.userPrincipalNameLabel.AutoSize = true;
            this.userPrincipalNameLabel.Location = new System.Drawing.Point(253, 90);
            this.userPrincipalNameLabel.Name = "userPrincipalNameLabel";
            this.userPrincipalNameLabel.Size = new System.Drawing.Size(100, 13);
            this.userPrincipalNameLabel.TabIndex = 99;
            this.userPrincipalNameLabel.Text = "UserPrincipalName:";
            this.userPrincipalNameLabel.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // middleNameLabel
            // 
            this.middleNameLabel.AutoSize = true;
            this.middleNameLabel.Location = new System.Drawing.Point(12, 63);
            this.middleNameLabel.Name = "middleNameLabel";
            this.middleNameLabel.Size = new System.Drawing.Size(72, 13);
            this.middleNameLabel.TabIndex = 99;
            this.middleNameLabel.Text = "Middle Name:";
            this.middleNameLabel.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // createUserButton
            // 
            this.createUserButton.Location = new System.Drawing.Point(442, 314);
            this.createUserButton.Name = "createUserButton";
            this.createUserButton.Size = new System.Drawing.Size(75, 23);
            this.createUserButton.TabIndex = 18;
            this.createUserButton.Text = "Create User";
            this.createUserButton.UseVisualStyleBackColor = true;
            this.createUserButton.Click += new System.EventHandler(this.createUserButton_Click);
            // 
            // telephoneNumberLabel
            // 
            this.telephoneNumberLabel.AutoSize = true;
            this.telephoneNumberLabel.Location = new System.Drawing.Point(292, 115);
            this.telephoneNumberLabel.Name = "telephoneNumberLabel";
            this.telephoneNumberLabel.Size = new System.Drawing.Size(61, 13);
            this.telephoneNumberLabel.TabIndex = 99;
            this.telephoneNumberLabel.Text = "Telephone:";
            this.telephoneNumberLabel.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // sAMAccountNameLabel
            // 
            this.sAMAccountNameLabel.AutoSize = true;
            this.sAMAccountNameLabel.Location = new System.Drawing.Point(254, 37);
            this.sAMAccountNameLabel.Name = "sAMAccountNameLabel";
            this.sAMAccountNameLabel.Size = new System.Drawing.Size(99, 13);
            this.sAMAccountNameLabel.TabIndex = 99;
            this.sAMAccountNameLabel.Text = "SamAccountName:";
            this.sAMAccountNameLabel.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(21, 247);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(63, 13);
            this.descriptionLabel.TabIndex = 99;
            this.descriptionLabel.Text = "Description:";
            this.descriptionLabel.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // empNumberLabel
            // 
            this.empNumberLabel.AutoSize = true;
            this.empNumberLabel.Location = new System.Drawing.Point(10, 221);
            this.empNumberLabel.Name = "empNumberLabel";
            this.empNumberLabel.Size = new System.Drawing.Size(74, 13);
            this.empNumberLabel.TabIndex = 99;
            this.empNumberLabel.Text = "Emp. Number:";
            this.empNumberLabel.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // empIDLabel
            // 
            this.empIDLabel.AutoSize = true;
            this.empIDLabel.Location = new System.Drawing.Point(14, 195);
            this.empIDLabel.Name = "empIDLabel";
            this.empIDLabel.Size = new System.Drawing.Size(70, 13);
            this.empIDLabel.TabIndex = 99;
            this.empIDLabel.Text = "Employee ID:";
            this.empIDLabel.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(8, 168);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(76, 13);
            this.emailLabel.TabIndex = 99;
            this.emailLabel.Text = "Email Address:";
            this.emailLabel.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(297, 63);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(56, 13);
            this.passwordLabel.TabIndex = 99;
            this.passwordLabel.Text = "Password:";
            this.passwordLabel.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // initialsLabel
            // 
            this.initialsLabel.AutoSize = true;
            this.initialsLabel.Location = new System.Drawing.Point(45, 115);
            this.initialsLabel.Name = "initialsLabel";
            this.initialsLabel.Size = new System.Drawing.Size(39, 13);
            this.initialsLabel.TabIndex = 99;
            this.initialsLabel.Text = "Initials:";
            this.initialsLabel.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // surnameLabel
            // 
            this.surnameLabel.AutoSize = true;
            this.surnameLabel.Location = new System.Drawing.Point(32, 89);
            this.surnameLabel.Name = "surnameLabel";
            this.surnameLabel.Size = new System.Drawing.Size(52, 13);
            this.surnameLabel.TabIndex = 99;
            this.surnameLabel.Text = "Surname:";
            this.surnameLabel.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // givenNameLabel
            // 
            this.givenNameLabel.AutoSize = true;
            this.givenNameLabel.Location = new System.Drawing.Point(15, 37);
            this.givenNameLabel.Name = "givenNameLabel";
            this.givenNameLabel.Size = new System.Drawing.Size(69, 13);
            this.givenNameLabel.TabIndex = 99;
            this.givenNameLabel.Text = "Given Name:";
            this.givenNameLabel.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(355, 60);
            this.passwordTextBox.MaxLength = 120;
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(163, 20);
            this.passwordTextBox.TabIndex = 11;
            this.passwordTextBox.UseSystemPasswordChar = true;
            this.passwordTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.passwordTextBox.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // createInComboBox
            // 
            this.createInComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.createInComboBox.DropDownWidth = 500;
            this.createInComboBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createInComboBox.FormattingEnabled = true;
            this.createInComboBox.Location = new System.Drawing.Point(86, 6);
            this.createInComboBox.MaxLength = 512;
            this.createInComboBox.Name = "createInComboBox";
            this.createInComboBox.Size = new System.Drawing.Size(431, 22);
            this.createInComboBox.TabIndex = 0;
            this.createInComboBox.SelectedIndexChanged += new System.EventHandler(this.ComboBox_TextChanged);
            this.createInComboBox.TextChanged += new System.EventHandler(this.ComboBox_TextChanged);
            this.createInComboBox.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // createInLabel
            // 
            this.createInLabel.AutoSize = true;
            this.createInLabel.Location = new System.Drawing.Point(32, 9);
            this.createInLabel.Name = "createInLabel";
            this.createInLabel.Size = new System.Drawing.Size(52, 13);
            this.createInLabel.TabIndex = 99;
            this.createInLabel.Text = "Create in:";
            this.createInLabel.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.newUserTabPage);
            this.tabControl1.Controls.Add(this.aboutTabPage);
            this.tabControl1.Location = new System.Drawing.Point(1, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(532, 369);
            this.tabControl1.TabIndex = 4;
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            // 
            // CustomAddADUserMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 511);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.activityListBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(550, 550);
            this.MinimumSize = new System.Drawing.Size(550, 550);
            this.Name = "CustomAddADUserMainForm";
            this.Text = "(Populated from App.config)";
            this.Load += new System.EventHandler(this.CustomAddADUserMainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.aboutTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainFormPictureBox1)).EndInit();
            this.newUserTabPage.ResumeLayout(false);
            this.newUserTabPage.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox activityListBox;
        private System.ComponentModel.BackgroundWorker populateCreateInComboBoxBackgroundWorker;
        private System.ComponentModel.BackgroundWorker createNewUserBackgroundWorker;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TabPage aboutTabPage;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.PictureBox mainFormPictureBox1;
        private System.Windows.Forms.TabPage newUserTabPage;
        private System.Windows.Forms.CheckBox passwordNeverExpiresCheckBox;
        private System.Windows.Forms.CheckBox userEnabledCheckBox;
        private System.Windows.Forms.CheckBox changePasswordCheckBox;
        private System.Windows.Forms.TextBox displayNameTextBox;
        private System.Windows.Forms.TextBox userPrincipalNameTextBox;
        private System.Windows.Forms.TextBox middleNameTextBox;
        private System.Windows.Forms.TextBox telephoneNumberTextBox;
        private System.Windows.Forms.TextBox sAMAccountNameTextBox;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.TextBox employeeNumberTextBox;
        private System.Windows.Forms.TextBox employeeIDTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox initialsTextBox;
        private System.Windows.Forms.TextBox surnameTextBox;
        private System.Windows.Forms.TextBox givenNameTextBox;
        private System.Windows.Forms.Label displayNameLabel;
        private System.Windows.Forms.Label userPrincipalNameLabel;
        private System.Windows.Forms.Label middleNameLabel;
        private System.Windows.Forms.Button createUserButton;
        private System.Windows.Forms.Label telephoneNumberLabel;
        private System.Windows.Forms.Label sAMAccountNameLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label empNumberLabel;
        private System.Windows.Forms.Label empIDLabel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label initialsLabel;
        private System.Windows.Forms.Label surnameLabel;
        private System.Windows.Forms.Label givenNameLabel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.ComboBox createInComboBox;
        private System.Windows.Forms.Label createInLabel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label copyFromLabel;
        private System.Windows.Forms.ComboBox copyFromComboBox;
        private System.Windows.Forms.Button findUserButton;
    }
}

