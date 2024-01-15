﻿using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CricketScoreScraper
{
    partial class FormMainPage
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
            mainPanel = new Panel();
            toggleButton = new Button();
            scoreListBox = new ListBox();
            slidingPanel = new Panel();
            mainPanel.SuspendLayout();
            slidingPanel.SuspendLayout();
            SuspendLayout();


            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(toggleButton);
            mainPanel.Dock = DockStyle.Top;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Margin = new Padding(3, 4, 3, 4);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(728, 125);
            mainPanel.TabIndex = 0;
            mainPanel.BackColor = System.Drawing.Color.FromArgb(45, 12, 57);
            // 
            // toggleButton
            // 
            toggleButton.Dock = DockStyle.Left;
            toggleButton.Location = new Point(0, 0);
            toggleButton.Margin = new Padding(3, 4, 3, 4);
            toggleButton.Name = "toggleButton";
            toggleButton.Size = new Size(125, 125);
            toggleButton.TabIndex = 0;
            toggleButton.UseVisualStyleBackColor = true;
            toggleButton.Click += toggleButton_Click;
            // 
            // scoreListBox
            // 
            scoreListBox.Dock = DockStyle.Fill;
            scoreListBox.FormattingEnabled = true;
            scoreListBox.ItemHeight = 25;
            scoreListBox.Location = new Point(0, 0);
            scoreListBox.Margin = new Padding(3, 4, 3, 4);
            scoreListBox.Name = "scoreListBox";
            scoreListBox.Size = new Size(728, 0);
            scoreListBox.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            scoreListBox.TabIndex = 0;
            scoreListBox.BackColor = System.Drawing.Color.FromArgb(122, 102, 138);
            scoreListBox.BorderStyle = BorderStyle.None;
            // 
            // slidingPanel
            // 
            slidingPanel.Controls.Add(scoreListBox);
            slidingPanel.Dock = DockStyle.Fill;
            slidingPanel.Location = new Point(0, 125);
            slidingPanel.Margin = new Padding(3, 4, 3, 4);
            slidingPanel.Name = "slidingPanel";
            slidingPanel.Size = new Size(728, 0);
            slidingPanel.BackColor = System.Drawing.Color.FromArgb(45, 12, 57);
            slidingPanel.TabIndex = 1;
            // 
            // FormMainPage
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(728, 125);
            Controls.Add(slidingPanel);
            Controls.Add(mainPanel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormMainPage";
            ControlBox = false;
            Text = "";
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            StartPosition = FormStartPosition.Manual;
            Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2 - 400);
            Load += FormMainPage_Load;
            mainPanel.ResumeLayout(false);
            slidingPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel mainPanel;
        private Button toggleButton;
        private Panel slidingPanel;
        private ListBox scoreListBox;
    }
}
