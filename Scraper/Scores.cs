using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.LinkLabel;

namespace CricketScoreScraper.Scraper
{

    struct Scorecard
    {
        public string teamA, teamB, link, innings, status;
        public int score, wickets, target;
    }

    internal class Scores
    {
        public List<Scorecard> scorecards;
        private readonly string url;
        private readonly HttpClient client;
        private readonly HtmlAgilityPack.HtmlDocument document;

        public Scores(HttpClient httpClient)
        {
            url = "https://www.espncricinfo.com/live-cricket-score";
            client = httpClient;
            document = new HtmlAgilityPack.HtmlDocument();
            scorecards = new List<Scorecard>();
          
        }

        public async Task InitializeAsync()
        {
            Console.WriteLine("Initialization started.");
            await FetchMatchesAsync();
            Console.WriteLine("Initialization complete.");
            
        }

        public async Task FetchMatchesAsync()
        {

            try
            {
                //Load html document
                string html = await client.GetStringAsync(url).ConfigureAwait(false);
                document.LoadHtml(html);

                //Get scores
                string class_scorecard = "ds-no-tap-higlight";
                string expr_matchDetails = ".//div[@class='ds-text-tight-xs ds-truncate ds-text-typo-mid3']";
                string expr_matchLink = ".//a[@class='ds-inline-flex ds-items-start ds-leading-none !ds-inline']";



                List<HtmlNode> scoreNodes = document.DocumentNode.Descendants("a")
                    .Where(node => node.GetAttributeValue("class", "").Contains(class_scorecard)).ToList();

                var tasks = scoreNodes.Select(scoreNode =>
                {
                    string? url = "https://www.espncricinfo.com" + scoreNode.GetAttributeValue("href", string.Empty);
                    return FetchMatchDetailsAsync(url);
                });

                await Task.WhenAll(tasks);

                Console.WriteLine("Done");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }



        }

        public async Task FetchMatchDetailsAsync(string url)
        {
            Console.WriteLine(url);
            Scorecard scorecard = new Scorecard();
            await Task.Delay(1000);

            string subPageContent = await client.GetStringAsync(url).ConfigureAwait(false);
            //Load subpage
            HtmlAgilityPack.HtmlDocument subPage = new HtmlAgilityPack.HtmlDocument();
            subPage.LoadHtml(subPageContent);

            //Fetching details
            string expr_details = "//div[@class='ds-text-tight-m ds-font-regular ds-text-typo-mid3']";
            HtmlNode? detailsElement = subPage.DocumentNode.SelectSingleNode(expr_details);
            string? details = detailsElement?.InnerText.Trim();
            Console.WriteLine(details);
            
        }



    }
}
