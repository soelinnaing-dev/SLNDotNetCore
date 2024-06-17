namespace SLNDotNetCore.WinformSql_Injuection
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txt_Email = new TextBox();
            txt_Password = new TextBox();
            btn_Login = new Button();
            SuspendLayout();
            // 
            // txt_Email
            // 
            txt_Email.Location = new Point(63, 12);
            txt_Email.Name = "txt_Email";
            txt_Email.Size = new Size(253, 23);
            txt_Email.TabIndex = 0;
            // 
            // txt_Password
            // 
            txt_Password.Location = new Point(63, 41);
            txt_Password.Name = "txt_Password";
            txt_Password.Size = new Size(253, 23);
            txt_Password.TabIndex = 1;
            // 
            // btn_Login
            // 
            btn_Login.BackColor = Color.ForestGreen;
            btn_Login.BackgroundImageLayout = ImageLayout.None;
            btn_Login.FlatAppearance.BorderSize = 0;
            btn_Login.FlatStyle = FlatStyle.Flat;
            btn_Login.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_Login.ForeColor = Color.White;
            btn_Login.Location = new Point(63, 70);
            btn_Login.Name = "btn_Login";
            btn_Login.Size = new Size(75, 28);
            btn_Login.TabIndex = 2;
            btn_Login.Text = "Login";
            btn_Login.UseVisualStyleBackColor = false;
            btn_Login.Click += btn_Login_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(381, 143);
            Controls.Add(btn_Login);
            Controls.Add(txt_Password);
            Controls.Add(txt_Email);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_Email;
        private TextBox txt_Password;
        private Button btn_Login;
    }
}
