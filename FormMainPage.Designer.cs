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
            buttonPanel = new Panel();
            toggleButton = new Button();
            settingsButton = new Button();
            refreshButton = new Button();
            scorecardPanel = new Panel();
            loadingBox = new TextBox();
            labelCoverage = new Label();
            labelTeamAScore = new Label();
            labelTeamBScore = new Label();
            labelStatus = new Label();
            scoreListBox = new ListBox();
            slidingPanel = new Panel();
            mainPanel.SuspendLayout();
            buttonPanel.SuspendLayout();
            scorecardPanel.SuspendLayout();
            slidingPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.FromArgb(45, 12, 57);
            mainPanel.Controls.Add(buttonPanel);
            mainPanel.Controls.Add(scorecardPanel);
            mainPanel.Dock = DockStyle.Top;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Margin = new Padding(3, 4, 3, 4);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(728, 125);
            mainPanel.TabIndex = 0;
            // 
            // buttonPanel
            // 
            buttonPanel.Controls.Add(toggleButton);
            buttonPanel.Controls.Add(settingsButton);
            buttonPanel.Controls.Add(refreshButton);
            buttonPanel.Dock = DockStyle.Left;
            buttonPanel.Location = new Point(0, 0);
            buttonPanel.Name = "buttonPanel";
            buttonPanel.Size = new Size(111, 125);
            buttonPanel.TabIndex = 6;
            // 
            // toggleButton
            // 
            toggleButton.BackColor = Color.MistyRose;
            toggleButton.Dock = DockStyle.Fill;
            toggleButton.FlatStyle = FlatStyle.Flat;
            toggleButton.Image = Properties.Resources.arrow;
            toggleButton.Location = new Point(0, 76);
            toggleButton.Margin = new Padding(3, 4, 3, 4);
            toggleButton.Name = "toggleButton";
            toggleButton.Size = new Size(111, 49);
            toggleButton.TabIndex = 0;
            toggleButton.UseVisualStyleBackColor = false;
            toggleButton.Click += toggleButton_Click;
            // 
            // settingsButton
            // 
            settingsButton.BackColor = Color.Thistle;
            settingsButton.Dock = DockStyle.Top;
            settingsButton.FlatStyle = FlatStyle.Flat;
            settingsButton.Location = new Point(0, 38);
            settingsButton.Margin = new Padding(0);
            settingsButton.Name = "settingsButton";
            settingsButton.Size = new Size(111, 38);
            settingsButton.TabIndex = 8;
            settingsButton.Text = "Settings";
            settingsButton.UseVisualStyleBackColor = false;
            settingsButton.Click += settingsButton_Click;
            // 
            // refreshButton
            // 
            refreshButton.BackColor = Color.Thistle;
            refreshButton.BackgroundImageLayout = ImageLayout.None;
            refreshButton.Dock = DockStyle.Top;
            refreshButton.FlatStyle = FlatStyle.Flat;
            refreshButton.Location = new Point(0, 0);
            refreshButton.Margin = new Padding(0);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(111, 38);
            refreshButton.TabIndex = 7;
            refreshButton.Text = "Refresh";
            refreshButton.UseVisualStyleBackColor = false;
            refreshButton.Click += button1_Click;
            // 
            // scorecardPanel
            // 
            scorecardPanel.Controls.Add(loadingBox);
            scorecardPanel.Controls.Add(labelCoverage);
            scorecardPanel.Controls.Add(labelTeamAScore);
            scorecardPanel.Controls.Add(labelTeamBScore);
            scorecardPanel.Controls.Add(labelStatus);
            scorecardPanel.Dock = DockStyle.Right;
            scorecardPanel.Location = new Point(107, 0);
            scorecardPanel.Name = "scorecardPanel";
            scorecardPanel.Size = new Size(621, 125);
            scorecardPanel.TabIndex = 6;
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
            loadingBox.Size = new Size(621, 38);
            loadingBox.TabIndex = 1;
            loadingBox.TabStop = false;
            loadingBox.Text = "Loading";
            loadingBox.TextAlign = HorizontalAlignment.Center;
            loadingBox.GotFocus += LoadingBox_GotFocus;
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
            // labelTeamAScore
            // 
            labelTeamAScore.AutoSize = true;
            labelTeamAScore.Font = new Font("Arial", 13F, FontStyle.Regular, GraphicsUnit.Point);
            labelTeamAScore.ForeColor = Color.White;
            labelTeamAScore.Location = new Point(0, 0);
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
            labelTeamBScore.Location = new Point(0, 0);
            labelTeamBScore.Name = "labelTeamBScore";
            labelTeamBScore.Size = new Size(94, 31);
            labelTeamBScore.TabIndex = 3;
            labelTeamBScore.Text = "TeamB";
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelStatus.ForeColor = Color.White;
            labelStatus.Location = new Point(0, 0);
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
            Load += FormMainPage_Load;
            mainPanel.ResumeLayout(false);
            buttonPanel.ResumeLayout(false);
            scorecardPanel.ResumeLayout(false);
            scorecardPanel.PerformLayout();
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
        private Panel scorecardPanel;
        private Button refreshButton;
        private Panel buttonPanel;
        private Button settingsButton;
    }
}
