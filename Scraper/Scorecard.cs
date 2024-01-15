using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Linq;
using System.Net;
using static System.Formats.Asn1.AsnWriter;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


namespace CricketScoreScraper.Scraper
{

    class TopLeague
    {
        public static readonly string SouthAfrica = "SA20";
        public static readonly string Australia = "Big Bash League";
        public static readonly string International = "International League T20";
        public static readonly string Bangladesh = "Bangladesh Premier League";
        public static readonly string Pakistan = "Pakistan Super League";
        public static readonly string India;

        public static List<string> list = new List<string> {
            SouthAfrica, Australia, Bangladesh, Pakistan
        };
    }

    class BottomLeague
    {
        public static readonly string SuperSmash = "Super Smash";

        public static List<string> list = new List<string> {
            SuperSmash
        };
    }

    class PracticeMatch
    {
        public static readonly string WarmUp = "Warm-up";
        public static readonly string TourMatch = "Tour Match";
        public static List<string> list = new List<string> {
            WarmUp, TourMatch
        };
    }

    class Domestic
    {
        public static readonly string RanjiTrophy = "Ranji Trophy Plate League";
        public static readonly string LoganCup = "Logan Cup";

        public static List<string> list = new List<string> {
            RanjiTrophy, LoganCup
        };
    }

    class International
    {
        public static readonly string WorldCup = "World Cup";
        public static readonly string SouthAfrica = "South Africa";
        public static readonly string Australia = "Australia";
        public static readonly string Bangladesh = "Bangladesh";
        public static readonly string Pakistan = "Pakistan";
        public static readonly string India = "India";
        public static readonly string WestIndies = "West Indies";
        public static readonly string England = "England";
        public static readonly string NewZealand = "New Zealand";

        public static List<string> list = new List<string> {
            WorldCup, SouthAfrica, Australia, Bangladesh, Pakistan, India, WestIndies, England, NewZealand
        };
    }

    class MatchStatus
    {
        public static List<string> list = new List<string>
        {
            "live", "stump", "result"
        };
    }


   

    public  class Scorecard
    {
        public string teamA, teamB, scoreA, scoreB, link, innings, status;
        public string score, wickets, target, coverage, details;
        public float relevancy;


        public void Print()
        {
            Console.WriteLine($"Relevancy: {CalculateRelevancy()}");
            Console.WriteLine($"Details: {details}\n" +
                $"Coverage: {coverage}\n" +
                $"Team A: {teamA} \nScore A: {scoreA}\n" +
                $"Team B: {teamB} \nScore B: {scoreB}\n" +
                $"Status: {status}\n" +
                $"URL: {link}\n\n");
        }

        public float CalculateRelevancy()
        {
            float total = 0;

            //Check League
            if (TopLeague.list.Any(league => details.Contains(league)))
            {
                total += 70;
            }
            else if (BottomLeague.list.Any(domesticTeam => details.Contains(domesticTeam)))
            {
                total += 50;
            }
            else if (Domestic.list.Any(domesticTeam => details.Contains(domesticTeam)))
            {
                total += 30;
            }
            else if (International.list.Any(internationalTeam => details.Contains(internationalTeam)))
            {
                total += 100;
            }
            else
            {
                total += 20;
            }

            //Check for practice
            if(PracticeMatch.list.Any(match => details.Contains(match)))
            {
                total /= 2;
            }

            //Check status
            string matchCoverage = coverage.ToLower();
            
            if(matchCoverage.Equals("not covered live"))
            {
                total /= 2;
            }
            if (matchCoverage.Equals("result"))
            {
                total -=10;
            } else if (matchCoverage.Equals("n/a"))
            {
                total -= 20;
            }

            relevancy = total;

            return total;
        }


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

       



    }
}
