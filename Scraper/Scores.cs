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
        const int batchSize = 13;

        public Scores(HttpClient httpClient)
        {
            url = "https://www.espncricinfo.com/live-cricket-score";
            client = httpClient;
            document = new HtmlAgilityPack.HtmlDocument();
            scorecards = new List<Scorecard>();
          
        }

        public async Task InitializeAsync()
        {
            Console.WriteLine("Async started.");
            await FetchMatchesAsync();
            Console.WriteLine("Async completed.");
            
        }

        public async Task FetchMatchesAsync()
        {

            try
            {
                //Load html document
                string html = await client.GetStringAsync(url).ConfigureAwait(false);
                document.LoadHtml(html);

                //Get URLs of score subpages
                string class_scorecard = "ds-no-tap-higlight";
                List<HtmlNode> scoreNodes = document.DocumentNode.Descendants("a")
                    .Where(node => node.GetAttributeValue("class", "").Contains(class_scorecard)).ToList();


                //Scrape subpages in batchess
                for(int i = 0; i <  scoreNodes.Count; i+= batchSize) {

                    List<string> batchUrls = scoreNodes
                    .Skip(i)
                    .Take(batchSize)
                    .Select(scoreNode => "https://www.espncricinfo.com" + scoreNode.GetAttributeValue("href", string.Empty))
                    .ToList();

                    var tasks = batchUrls.Select(url => FetchMatchDetailsAsync(url));
                    await Task.WhenAll(tasks);
                    Console.WriteLine($"{scorecards.Count} Scorecards fetched...");
                }

                //Sort by relevancy
                scorecards = scorecards.OrderByDescending(scorecard => scorecard.CalculateRelevancy()).ToList();


                //Print results
                foreach (Scorecard scorecard in scorecards)
                {
                    scorecard.Print();
                }
                Console.WriteLine("Number of Scorecards: " + scorecards.Count);


                Console.WriteLine("Scraping Done");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }



        }

        public async Task FetchMatchDetailsAsync(string url)
        {

            //Load subpage
            string subPageContent = await client.GetStringAsync(url).ConfigureAwait(false);
            HtmlAgilityPack.HtmlDocument subPage = new HtmlAgilityPack.HtmlDocument();
            subPage.LoadHtml(subPageContent);


            //Making nodes to Fetch match details
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
            string details = WebUtility.HtmlDecode(matchDetailsElement.InnerText.Trim());
            

            // Set and Add Scorecard values
            Scorecard scorecard = new Scorecard();
            scorecard.SetTeamA(teamA);
            scorecard.SetTeamB(teamB);
            scorecard.SetScoreA(scoreTeamA);
            scorecard.SetScoreB(scoreTeamB);
            scorecard.SetDetails(details);
            scorecard.SetLink(url);
            scorecard.SetStatus(status);
            scorecard.SetCoverage(coverage);

            scorecards.Add(scorecard);  


        }



    }
}
