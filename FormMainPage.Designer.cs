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
            scoreListBox = new ListBox();
            slidingPanel = new Panel();
            loadingBox = new TextBox();
            labelTeamAScore = new Label();
            labelTeamBScore = new Label();
            labelCoverage = new Label();
            labelStatus = new Label();
            mainPanel.SuspendLayout();
            slidingPanel.SuspendLayout();
            SuspendLayout();
            loadingBox.SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(toggleButton);
            mainPanel.Controls.Add(loadingBox);
            mainPanel.Dock = DockStyle.Top;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Margin = new Padding(3, 4, 3, 4);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(728, 125);
            mainPanel.TabIndex = 0;
            mainPanel.BackColor = Color.FromArgb(45, 12, 57);
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
            toggleButton.Image = Properties.Resources.arrow;
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
            scoreListBox.Font = new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Point, 0);
            scoreListBox.TabIndex = 0;
            scoreListBox.BackColor = Color.FromArgb(122, 102, 138);
            scoreListBox.BorderStyle = BorderStyle.None;
            scoreListBox.SelectedIndexChanged += scoreListBox_SelectedIndexChanged;
            // 
            // loadingBox
            // 
            loadingBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            loadingBox.BackColor = SystemColors.MenuText;
            loadingBox.Font = new Font("Segoe UI Symbol", 14F, FontStyle.Regular, GraphicsUnit.Point);
            loadingBox.ForeColor = Color.AliceBlue;
            loadingBox.Location = new Point(372, 39);
            loadingBox.Name = "loadingBox";
            loadingBox.ReadOnly = true;
            loadingBox.BorderStyle = BorderStyle.None;
            loadingBox.TextAlign = HorizontalAlignment.Center;
            loadingBox.Size = new Size(Height, Width);
            loadingBox.TabIndex = 1;
            loadingBox.Text = "Loading";
            loadingBox.TextChanged += textBox1_TextChanged;
            loadingBox.TabStop = false;
            loadingBox.Dock = DockStyle.Fill;
            loadingBox.GotFocus += LoadingBox_GotFocus;
            // 
            // slidingPanel
            // 
            slidingPanel.Controls.Add(scoreListBox);
            slidingPanel.Dock = DockStyle.Fill;
            slidingPanel.Location = new Point(0, 125);
            slidingPanel.Margin = new Padding(3, 4, 3, 4);
            slidingPanel.Name = "slidingPanel";
            slidingPanel.Size = new Size(728, 0);
            slidingPanel.BackColor = Color.FromArgb(45, 12, 57);
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
            Location = new Point((Screen.PrimaryScreen.Bounds.Width - Width) / 2, (Screen.PrimaryScreen.Bounds.Height - Height) / 2 - 400);
            Load += FormMainPage_Load;
            mainPanel.ResumeLayout(false);
            slidingPanel.ResumeLayout(false);
            ResumeLayout(false);
            // 
            // labelTeamAScore
            // 
            labelTeamAScore.ForeColor = Color.White;
            labelTeamAScore.Text = "TeamA";
            labelTeamAScore.Font = new Font("Arial", 13, FontStyle.Regular, GraphicsUnit.Point);
            labelTeamAScore.AutoSize = true;
            labelTeamAScore.Location = new Point((mainPanel.Left + mainPanel.Right - labelTeamAScore.Width) / 4, 30);
            mainPanel.Controls.Add(labelTeamAScore);
            // 
            // labelTeamBScore
            // 
            labelTeamBScore.ForeColor = Color.White;
            labelTeamBScore.Text = "TeamB";
            labelTeamBScore.Font = new Font("Arial", 13, FontStyle.Regular, GraphicsUnit.Point);
            labelTeamBScore.AutoSize = true;
            labelTeamBScore.Location = new Point((mainPanel.Left + mainPanel.Right - labelTeamBScore.Width) / 4, 60);
            mainPanel.Controls.Add(labelTeamBScore);
            // 
            // labelCoverage
            // 
            labelCoverage.ForeColor = Color.White;
            labelCoverage.Text = "Coverage";
            labelCoverage.Font = new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Point);
            labelCoverage.AutoSize = true;
            labelCoverage.Location = new Point((mainPanel.Left + mainPanel.Right - labelCoverage.Width) / 4, 5);
            mainPanel.Controls.Add(labelCoverage);
            // 
            // labelStatus
            // 
            labelStatus.ForeColor = Color.White;
            labelStatus.Text = "Status is here";
            labelStatus.Font = new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Point);
            labelStatus.AutoSize = true;
            labelStatus.Location = new Point((mainPanel.Left + mainPanel.Right - labelStatus.Width) / 4, 95);
            mainPanel.Controls.Add(labelStatus);
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
