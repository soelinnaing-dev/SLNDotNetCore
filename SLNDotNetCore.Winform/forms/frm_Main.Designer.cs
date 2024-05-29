﻿namespace SLNDotNetCore.Winform.forms
{
    partial class frm_Main
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
            menuStrip1 = new MenuStrip();
            blogToolStripMenuItem = new ToolStripMenuItem();
            newBlogToolStripMenuItem = new ToolStripMenuItem();
            blogListToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { blogToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // blogToolStripMenuItem
            // 
            blogToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newBlogToolStripMenuItem, blogListToolStripMenuItem });
            blogToolStripMenuItem.Name = "blogToolStripMenuItem";
            blogToolStripMenuItem.Size = new Size(43, 20);
            blogToolStripMenuItem.Text = "Blog";
            // 
            // newBlogToolStripMenuItem
            // 
            newBlogToolStripMenuItem.Name = "newBlogToolStripMenuItem";
            newBlogToolStripMenuItem.Size = new Size(125, 22);
            newBlogToolStripMenuItem.Text = "New Blog";
            newBlogToolStripMenuItem.Click += newBlogToolStripMenuItem_Click;
            // 
            // blogListToolStripMenuItem
            // 
            blogListToolStripMenuItem.Name = "blogListToolStripMenuItem";
            blogListToolStripMenuItem.Size = new Size(125, 22);
            blogListToolStripMenuItem.Text = "BlogList";
            blogListToolStripMenuItem.Click += blogListToolStripMenuItem_Click;
            // 
            // frm_Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(816, 489);
            Name = "frm_Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main Menu";
            WindowState = FormWindowState.Maximized;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem blogToolStripMenuItem;
        private ToolStripMenuItem newBlogToolStripMenuItem;
        private ToolStripMenuItem blogListToolStripMenuItem;
    }
}