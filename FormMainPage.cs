using CricketScoreScraper.Scraper;
using System.Security.Cryptography.X509Certificates;

namespace CricketScoreScraper
{
    public partial class FormMainPage : Form
    {
        private readonly int originalHeight;
        public Scores scores;
        public FormMainPage(Scores scores)
        {
            this.scores = scores;
            InitializeComponent();
            originalHeight = this.Height;
            slidingPanel.Top = mainPanel.Bottom;
            SetTheme();
            SetEnvironment();
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


        private void SetTheme()
        {

            // Set the background color for the main panel (darker purplish-grey)
            slidingPanel.BackColor = mainPanel.BackColor = System.Drawing.Color.FromArgb(45, 12, 57);


            // Set the background color for the list box (darker greyish tone)
            scoreListBox.BackColor = System.Drawing.Color.FromArgb(122, 102, 138);


            // Set the font color for the main panel
            mainPanel.ForeColor = System.Drawing.Color.White;

            // Set the font color for the sliding panel and list box
            slidingPanel.ForeColor = scoreListBox.ForeColor = System.Drawing.Color.Black;


            // Improve the font style for the scoreListBox
            scoreListBox.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); // Change the font style as needed

            
        }

        private void SetEnvironment()
        {
           
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.DarkSlateGray, ButtonBorderStyle.Solid);
        }


        private void FormMainPage_Load(object sender, EventArgs e)
        {
            // Assuming Scores class has a method to get match details
            List<Scorecard> scorecards = scores.scorecards;

            // Clear existing items in the ListBox
            scoreListBox.Items.Clear();

            // Add match details to the ListBox
            foreach (var match in scorecards)
            {
                string matchInfo = match.details;
                scoreListBox.Items.Add(matchInfo);
            }
        }




    }
}