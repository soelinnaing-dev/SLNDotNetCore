namespace SLNDotNetCore.Winform
{
    partial class frm_Blog
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtTitle = new TextBox();
            txtAuthor = new TextBox();
            txtContent = new TextBox();
            btnCancel = new Button();
            btnSave = new Button();
            pnlControl = new Panel();
            pnlControl.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(82, 41);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "Title :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(67, 84);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 0;
            label2.Text = "Author :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(61, 127);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 0;
            label3.Text = "Content :";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(129, 38);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(195, 23);
            txtTitle.TabIndex = 1;
            txtTitle.KeyDown += txtTitle_KeyDown;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(129, 80);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(195, 23);
            txtAuthor.TabIndex = 2;
            txtAuthor.KeyDown += txtTitle_KeyDown;
            // 
            // txtContent
            // 
            txtContent.Location = new Point(129, 127);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(195, 84);
            txtContent.TabIndex = 3;
            txtContent.KeyDown += txtTitle_KeyDown;
            // 
            // btnCancel
            // 
            btnCancel.Enabled = false;
            btnCancel.Location = new Point(129, 235);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "&Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.ForestGreen;
            btnSave.Enabled = false;
            btnSave.FlatAppearance.BorderColor = Color.White;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(249, 235);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 4;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // pnlControl
            // 
            pnlControl.BackColor = SystemColors.ActiveBorder;
            pnlControl.BorderStyle = BorderStyle.Fixed3D;
            pnlControl.Controls.Add(txtTitle);
            pnlControl.Controls.Add(btnSave);
            pnlControl.Controls.Add(label1);
            pnlControl.Controls.Add(btnCancel);
            pnlControl.Controls.Add(label2);
            pnlControl.Controls.Add(txtContent);
            pnlControl.Controls.Add(label3);
            pnlControl.Controls.Add(txtAuthor);
            pnlControl.Location = new Point(188, 25);
            pnlControl.Name = "pnlControl";
            pnlControl.Size = new Size(429, 312);
            pnlControl.TabIndex = 6;
            // 
            // frm_Blog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlControl);
            MinimumSize = new Size(816, 489);
            Name = "frm_Blog";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Home";
            pnlControl.ResumeLayout(false);
            pnlControl.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtTitle;
        private TextBox txtAuthor;
        private TextBox txtContent;
        private Button btnCancel;
        private Button btnSave;
        private Panel pnlControl;
    }
}
