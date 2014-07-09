namespace CustomAddADUser
{
    partial class FindUserForm
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
            this.findUserTextBox = new System.Windows.Forms.TextBox();
            this.findUserHelpLabel = new System.Windows.Forms.Label();
            this.userNotFoundLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // findUserTextBox
            // 
            this.findUserTextBox.Location = new System.Drawing.Point(9, 12);
            this.findUserTextBox.MaxLength = 512;
            this.findUserTextBox.Name = "findUserTextBox";
            this.findUserTextBox.Size = new System.Drawing.Size(413, 20);
            this.findUserTextBox.TabIndex = 0;
            this.findUserTextBox.TextChanged += new System.EventHandler(this.findUserTextBox_TextChanged);
            this.findUserTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.findUserTextBox_KeyDown);
            // 
            // findUserHelpLabel
            // 
            this.findUserHelpLabel.Location = new System.Drawing.Point(12, 61);
            this.findUserHelpLabel.Name = "findUserHelpLabel";
            this.findUserHelpLabel.Size = new System.Drawing.Size(413, 31);
            this.findUserHelpLabel.TabIndex = 1;
            this.findUserHelpLabel.Text = "Find a user by sAMAccountName, Distinguished Name, GUID, CN, UPN, or SID. Then hi" +
    "t Enter to search, or hit Escape to cancel.";
            // 
            // userNotFoundLabel
            // 
            this.userNotFoundLabel.AutoSize = true;
            this.userNotFoundLabel.ForeColor = System.Drawing.Color.Crimson;
            this.userNotFoundLabel.Location = new System.Drawing.Point(12, 35);
            this.userNotFoundLabel.Name = "userNotFoundLabel";
            this.userNotFoundLabel.Size = new System.Drawing.Size(80, 13);
            this.userNotFoundLabel.TabIndex = 2;
            this.userNotFoundLabel.Text = "User not found!";
            this.userNotFoundLabel.Visible = false;
            // 
            // FindUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 101);
            this.Controls.Add(this.userNotFoundLabel);
            this.Controls.Add(this.findUserHelpLabel);
            this.Controls.Add(this.findUserTextBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FindUserForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Find User...";
            this.Load += new System.EventHandler(this.FindUserForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox findUserTextBox;
        private System.Windows.Forms.Label findUserHelpLabel;
        private System.Windows.Forms.Label userNotFoundLabel;
    }
}