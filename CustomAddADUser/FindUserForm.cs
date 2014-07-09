using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.DirectoryServices.AccountManagement;

namespace CustomAddADUser
{
    public partial class FindUserForm : Form
    {
        public FindUserForm()
        {
            InitializeComponent();
        }

        private void FindUserForm_Load(object sender, EventArgs e)
        {
            findUserTextBox.Text = string.Empty;
            CustomAddADUserMainForm.foundUserToCopy = null;
        }

        private void findUserTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                findUserTextBox.Text = string.Empty;                
                this.Close();
            }
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                using (var principalContext = new PrincipalContext(ContextType.Domain, CustomAddADUserMainForm.domainDnsName))
                {
                    using (var checkForExistingUser = UserPrincipal.FindByIdentity(principalContext, findUserTextBox.Text))
                    {
                        if (checkForExistingUser == null)
                        {
                            findUserTextBox.BackColor = Color.Pink;
                            userNotFoundLabel.Visible = true;
                        }
                        else
                        {
                            CustomAddADUserMainForm.foundUserToCopy = checkForExistingUser.SamAccountName;
                            this.Close();
                        }
                    }
                }
            }
        }

        private void findUserTextBox_TextChanged(object sender, EventArgs e)
        {
            findUserTextBox.BackColor = SystemColors.Window;
            userNotFoundLabel.Visible = false;
        }
    }
}
