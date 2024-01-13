using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


namespace CricketScoreScraper.Scraper
{
    internal class Scorecard
    {
        public string teamA, teamB, scoreA, scoreB, link, innings, status;
        public string score, wickets, target, coverage, details;


        public void SetStringProperty(ref string property, string text)
        {
            property = !string.IsNullOrEmpty(text) ? WebUtility.HtmlDecode(text) : "N/A";
        }

        public void SetTeamA(string text)
        {
            SetStringProperty(ref teamA, text);
        }

        public void SetTeamB(string text)
        {
            SetStringProperty(ref teamB, text);
        }

        public void SetScoreA(string text)
        {
            SetStringProperty(ref scoreA, text);
        }

        public void SetScoreB(string text)
        {
            SetStringProperty(ref scoreB, text);
        }

        public void SetLink(string text)
        {
            SetStringProperty(ref link, text);
        }

        public void SetInnings(string text)
        {
            SetStringProperty(ref innings, text);
        }

        public void SetStatus(string text)
        {
            SetStringProperty(ref status, text);
        }

        public void SetScore(string text)
        {
            SetStringProperty(ref score, text);
        }

        public void SetWickets(string text)
        {
            SetStringProperty(ref wickets, text);
        }

        public void SetTarget(string text)
        {
            SetStringProperty(ref target, text);
        }

        public void SetCoverage(string text)
        {
            SetStringProperty(ref coverage, text);
        }

        public void SetDetails(string text)
        {
            SetStringProperty(ref details, text);
        }

        public void Print()
        {

            Console.WriteLine($"Details: {details}\n" +
                $"Coverage: {coverage}\n"+
                $"Team A: {teamA} - Score A: {scoreA}\n" +
                $"Team B: {teamB} - Score B: {scoreB}\n" +
                $"Status: {status}\n" +
                $"URL: {link}\n\n");
    
        }
    }
}
