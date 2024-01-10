using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using static System.Net.WebRequestMethods;

namespace CricketScoreScraper.Scraper
{

    struct Scorecard
    {
        public string teamA, teamB;
        public int score, wickets, inningsNumber, target;
    }
    internal class Scores
    {
        public List<Scorecard> scorecards;
        private string url;
        private HttpClient client;
        private HtmlAgilityPack.HtmlDocument document;

        public Scores()
        {
            url = "https://www.espncricinfo.com/live-cricket-score";
            client = new HttpClient();
            document = new HtmlAgilityPack.HtmlDocument();

            fetchScores();
        }

        public void fetchScores()
        {
            //Load html document
            string html = client.GetStringAsync(url).Result;
            document.LoadHtml(html);

            //Get scores
            string  class_scorecard = "ds-border-b ds-border-line ds-w-1/2";
            string expr_matchDetails = ".//div[@class='ds-text-tight-xs ds-truncate ds-text-typo-mid3']";
    

            List<HtmlNode> scoreNodes = document.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "").Contains(class_scorecard)).ToList();

            foreach (var scoreNode in scoreNodes)
            {
                string line = scoreNode.SelectSingleNode(expr_matchDetails).InnerText;
                Console.WriteLine(line);
 
            }


          



        }



    }
}
