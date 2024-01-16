using static System.Net.Mime.MediaTypeNames;
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
            loadingBox = new TextBox();
            labelTeamAScore = new Label();
            labelTeamBScore = new Label();
            labelCoverage = new Label();
            labelStatus = new Label();
            scoreListBox = new ListBox();
            slidingPanel = new Panel();
            mainPanel.SuspendLayout();
            slidingPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.FromArgb(45, 12, 57);
            mainPanel.Controls.Add(toggleButton);
            mainPanel.Controls.Add(loadingBox);
            mainPanel.Controls.Add(labelTeamAScore);
            mainPanel.Controls.Add(labelTeamBScore);
            mainPanel.Controls.Add(labelCoverage);
            mainPanel.Controls.Add(labelStatus);
            mainPanel.Dock = DockStyle.Top;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Margin = new Padding(3, 4, 3, 4);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(728, 125);
            mainPanel.TabIndex = 0;
            // 
            // toggleButton
            // 
            toggleButton.Dock = DockStyle.Left;
            toggleButton.Image = Properties.Resources.arrow;
            toggleButton.Location = new Point(0, 0);
            toggleButton.Margin = new Padding(3, 4, 3, 4);
            toggleButton.Name = "toggleButton";
            toggleButton.Size = new Size(125, 125);
            toggleButton.TabIndex = 0;
            toggleButton.UseVisualStyleBackColor = true;
            toggleButton.Click += toggleButton_Click;
            // 
            // loadingBox
            // 
            loadingBox.BackColor = SystemColors.MenuText;
            loadingBox.BorderStyle = BorderStyle.None;
            loadingBox.Dock = DockStyle.Fill;
            loadingBox.Font = new Font("Segoe UI Symbol", 14F, FontStyle.Regular, GraphicsUnit.Point);
            loadingBox.ForeColor = Color.AliceBlue;
            loadingBox.Location = new Point(0, 0);
            loadingBox.Name = "loadingBox";
            loadingBox.ReadOnly = true;
            loadingBox.Size = new Size(728, 38);
            loadingBox.TabIndex = 1;
            loadingBox.TabStop = false;
            loadingBox.Text = "Loading";
            loadingBox.TextAlign = HorizontalAlignment.Center;
            loadingBox.TextChanged += textBox1_TextChanged;
            loadingBox.GotFocus += LoadingBox_GotFocus;
            // 
            // labelTeamAScore
            // 
            labelTeamAScore.AutoSize = true;
            labelTeamAScore.Font = new Font("Arial", 13F, FontStyle.Regular, GraphicsUnit.Point);
            labelTeamAScore.ForeColor = Color.White;
            labelTeamAScore.Location = new Point(0, 30);
            labelTeamAScore.Name = "labelTeamAScore";
            labelTeamAScore.Size = new Size(94, 31);
            labelTeamAScore.TabIndex = 2;
            labelTeamAScore.Text = "TeamA";
            // 
            // labelTeamBScore
            // 
            labelTeamBScore.AutoSize = true;
            labelTeamBScore.Font = new Font("Arial", 13F, FontStyle.Regular, GraphicsUnit.Point);
            labelTeamBScore.ForeColor = Color.White;
            labelTeamBScore.Location = new Point(0, 60);
            labelTeamBScore.Name = "labelTeamBScore";
            labelTeamBScore.Size = new Size(94, 31);
            labelTeamBScore.TabIndex = 3;
            labelTeamBScore.Text = "TeamB";
            // 
            // labelCoverage
            // 
            labelCoverage.AutoSize = true;
            labelCoverage.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelCoverage.ForeColor = Color.White;
            labelCoverage.Location = new Point(0, 5);
            labelCoverage.Name = "labelCoverage";
            labelCoverage.Size = new Size(95, 23);
            labelCoverage.TabIndex = 4;
            labelCoverage.Text = "Coverage";
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelStatus.ForeColor = Color.White;
            labelStatus.Location = new Point(0, 95);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(131, 23);
            labelStatus.TabIndex = 5;
            labelStatus.Text = "Status is here";
            // 
            // scoreListBox
            // 
            scoreListBox.BackColor = Color.FromArgb(122, 102, 138);
            scoreListBox.BorderStyle = BorderStyle.None;
            scoreListBox.Dock = DockStyle.Fill;
            scoreListBox.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            scoreListBox.FormattingEnabled = true;
            scoreListBox.ItemHeight = 27;
            scoreListBox.Location = new Point(0, 0);
            scoreListBox.Margin = new Padding(3, 4, 3, 4);
            scoreListBox.Name = "scoreListBox";
            scoreListBox.Size = new Size(728, 0);
            scoreListBox.TabIndex = 0;
            scoreListBox.SelectedIndexChanged += scoreListBox_SelectedIndexChanged;
            // 
            // slidingPanel
            // 
            slidingPanel.BackColor = Color.FromArgb(45, 12, 57);
            slidingPanel.Controls.Add(scoreListBox);
            slidingPanel.Dock = DockStyle.Fill;
            slidingPanel.Location = new Point(0, 125);
            slidingPanel.Margin = new Padding(3, 4, 3, 4);
            slidingPanel.Name = "slidingPanel";
            slidingPanel.Size = new Size(728, 0);
            slidingPanel.TabIndex = 1;
            // 
            // FormMainPage
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(728, 125);
            ControlBox = false;
            Controls.Add(slidingPanel);
            Controls.Add(mainPanel);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Location = new Point(2560, 1440);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "FormMainPage";
            StartPosition = FormStartPosition.Manual;
            Load += FormMainPage_Load;
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            slidingPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel mainPanel;
        private Button toggleButton;
        private Panel slidingPanel;
        private ListBox scoreListBox;
        private TextBox loadingBox;
        private Label labelTeamAScore;
        private Label labelTeamBScore;
        private Label labelCoverage;
        private Label labelStatus;
    }
}
