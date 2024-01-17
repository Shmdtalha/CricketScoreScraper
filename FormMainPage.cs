using CricketScoreScraper.Scraper;
using Microsoft.Win32;
using System.Security.Cryptography.X509Certificates;

namespace CricketScoreScraper
{
    public partial class FormMainPage : Form
    {
        private readonly int originalHeight;
        public Scores scores;
        public FormMainPage()
        {
            SetAutoStart(true);
            InitializeComponent();
            originalHeight = this.Height;
            slidingPanel.Top = mainPanel.Bottom;
            SetTheme();

            _ = InitializeAsync();


        }

        public async Task InitializeAsync()
        {
            try
            {
                //Restrict access before scorecards load
                loadingBox.Visible = true;
                toggleButton.Enabled = false;
                slidingPanel.Visible = false;
                labelTeamAScore.Visible = labelTeamBScore.Visible = labelCoverage.Visible = labelStatus.Visible = false;

                //Initialize ASync
                HttpClient client = new HttpClient();
                scores = new Scores(client);
                await scores.InitializeAsync();

                // Fill ListBox
                List<Scorecard> scorecards = scores.scorecards;
                scoreListBox.Items.Clear();
                foreach (var match in scorecards)
                {
                    string matchInfo = match.details;
                    scoreListBox.Items.Add(matchInfo);
                }


                //Allow access when scorecards load
                labelStatus.Location = new Point(15, 95);
                labelCoverage.Location = new Point(15, 5);
                labelTeamBScore.Location = new Point(15, 60);
                labelTeamAScore.Location = new Point(15, 30);
                loadingBox.Visible = false;
                toggleButton.Enabled = true;
                labelTeamAScore.Visible = labelTeamBScore.Visible = labelCoverage.Visible = labelStatus.Visible = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private void toggleButton_Click(object sender, EventArgs e)
        {
            ToggleDetailsPanel();
        }

        private void ToggleDetailsPanel()
        {


            if (slidingPanel.Visible)
            {

                Height = originalHeight;

                Console.WriteLine($"Height {Height}\n" +
                    $"MainPanel {mainPanel.Height}\nScoreListBox.Height {scoreListBox.Height}\n" +
                    $"ItemHeight {scoreListBox.ItemHeight}\n" +
                    $"MainPanel.Height {mainPanel.Height}\n");

            }
            else
            {
                Height = originalHeight + scoreListBox.ItemHeight * 5;

                Console.WriteLine($"Height {Height}\n" +
                   $"MainPanel {mainPanel.Height}\nScoreListBox.Height {scoreListBox.Height}\n" +
                   $"ItemHeight {scoreListBox.ItemHeight}\n" +
                   $"MainPanel.Height {mainPanel.Height}\n");
            }

            // Toggle visibility of the sliding panel
            slidingPanel.Visible = !slidingPanel.Visible;

        }

        private void SetAutoStart(bool enable)
        {
            const string appName = "CricketScoreScraper"; // Change this to your application name
            const string runKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";

            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(runKey, true))
            {
                if (enable)
                {
                    key.SetValue(appName, Application.ExecutablePath);
                }
                else
                {
                    key.DeleteValue(appName, false);
                }
            }
        }
        private void SetTheme()
        {

            StartPosition = FormStartPosition.Manual;
            Location = new Point((Screen.PrimaryScreen.Bounds.Width - Width) / 2, (Screen.PrimaryScreen.Bounds.Height - Height) / 2 - 400);

            // Set the background color for the main panel (darker purplish-grey)
            slidingPanel.BackColor = mainPanel.BackColor = System.Drawing.Color.FromArgb(45, 12, 57);


            // Set the background color for the list box (darker greyish tone)
            scoreListBox.BackColor = System.Drawing.Color.FromArgb(122, 102, 138);


            // Set the font color for the sliding panel and list box
            slidingPanel.ForeColor = scoreListBox.ForeColor = System.Drawing.Color.Black;


            // Improve the font style for the scoreListBox
            scoreListBox.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); // Change the font style as needed


        }

        private void LoadingBox_GotFocus(object sender, EventArgs e)
        {
            // Prevent focus on the TextBox
            this.ActiveControl = null;
        }

        private void scoreListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (scoreListBox.SelectedIndex >= 0)
            {
                Scorecard selectedScorecard = scores.scorecards[scoreListBox.SelectedIndex];
                // Update labels with the relevant information
                labelTeamAScore.Text = $"{selectedScorecard.teamA}: {selectedScorecard.scoreA}";
                labelTeamBScore.Text = $"{selectedScorecard.teamB}: {selectedScorecard.scoreB}";
                labelCoverage.Text = selectedScorecard.coverage;
                labelStatus.Text = selectedScorecard.status;
            }
        }

        private void FormMainPage_Load(object sender, EventArgs e)
        {
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void settingsButton_Click(object sender, EventArgs e)
        {

        }
    }
}