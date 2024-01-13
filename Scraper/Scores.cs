using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.LinkLabel;

namespace CricketScoreScraper.Scraper
{



    internal class Scores
    {
        public List<Scorecard> scorecards;
        private readonly string url;
        private readonly HttpClient client;
        private readonly HtmlAgilityPack.HtmlDocument document;
        const int batchSize = 15;

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

                Console.WriteLine("Number of Scorecards: " + scorecards.Count);

                foreach(Scorecard scorecard in scorecards)
                {
                    scorecard.Print();
                }

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

            //Load subpage
            string subPageContent = await client.GetStringAsync(url).ConfigureAwait(false);
            HtmlAgilityPack.HtmlDocument subPage = new HtmlAgilityPack.HtmlDocument();
            subPage.LoadHtml(subPageContent);

            //Making nodes
            string expr_details = "//div[@class='ds-text-tight-m ds-font-regular ds-text-typo-mid3']";
            HtmlNode? matchDetailsElement = subPage.DocumentNode.SelectSingleNode(expr_details);

            string expr_teamsDetails = "//div[@class='ds-flex ds-flex-col ds-mt-3 md:ds-mt-0 ds-mt-0 ds-mb-1']";
            HtmlNode? teamsDetailsElement = subPage.DocumentNode?.SelectSingleNode(expr_teamsDetails) ;
            HtmlNodeCollection? teamDetails = teamsDetailsElement?.SelectNodes(".//div[contains(@class, 'ci-team-score')]");

            string teamA = teamDetails[0].SelectSingleNode(".//span[contains(@class, 'ds-text-tight-l')]").InnerText.Trim();
            string teamB = teamDetails[1].SelectSingleNode(".//span[contains(@class, 'ds-text-tight-l')]").InnerText.Trim();

            string? scoreTeamA = teamDetails[0].SelectSingleNode(".//strong")?.InnerText.Trim();
            string? scoreTeamB = teamDetails[1].SelectSingleNode(".//strong")?.InnerText.Trim();
            string? status = subPage.DocumentNode.SelectSingleNode(".//p[@class = 'ds-text-tight-m ds-font-regular ds-truncate ds-text-typo']/span")?.InnerText?.Trim();
            string? coverage = subPage.DocumentNode.SelectSingleNode(".//div[@class='ds-px-4 ds-py-3 ds-border-b ds-border-line']//strong")?.InnerText.Trim();




            //Return if an element is null
            if (matchDetailsElement == null || teamsDetailsElement== null)
            {
                Console.WriteLine("An element was null");
                return;
            }

            //Fetching match details
            string details = WebUtility.HtmlDecode(matchDetailsElement.InnerText.Trim());
            

            //Console.WriteLine(details);
            //Console.WriteLine($"Team A: {teamA}");
            //Console.WriteLine($"Team B: {teamB}");
            //Console.WriteLine($"Score A: {scoreTeamA}");
            //Console.WriteLine($"Score B: {scoreTeamB}");
            //Console.WriteLine("Coverage: " + coverage);
            //Console.WriteLine("Status: " + status + "\n\n");

            // Set values using the Scorecard methods
            scorecard.SetTeamA(teamA);
            scorecard.SetTeamB(teamB);
            scorecard.SetScoreA(scoreTeamA);
            scorecard.SetScoreB(scoreTeamB);
            scorecard.SetDetails(details);
            scorecard.SetLink(url);
            scorecard.SetStatus(status);

            scorecards.Add(scorecard);  


        }



    }
}
