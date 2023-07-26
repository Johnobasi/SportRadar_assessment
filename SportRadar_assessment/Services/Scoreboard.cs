using SportRadar_assessment.Models;

namespace SportRadar_assessment.Services
{
    public class Scoreboard 
    {
        private List<SportRadarMatch> matches;

        public Scoreboard()
        {
            matches = new List<SportRadarMatch>();
        }

        public void StartMatch(string homeTeam, string awayTeam)
        {
            SportRadarMatch match = new SportRadarMatch(homeTeam, awayTeam);
            matches.Add(match);
        }

        public void UpdateScore(string homeTeam, string awayTeam, int homeTeamScore, int awayTeamScore)
        {
            SportRadarMatch match = matches.Find(m => m.HomeTeam == homeTeam && m.AwayTeam == awayTeam);
            if (match != null)
            {
                match.UpdateScore(homeTeamScore, awayTeamScore);
            }
            else
            {
                // Handle match not found
                Console.WriteLine("Match not found!");
            }
        }

        public void FinishMatch(string homeTeam, string awayTeam)
        {
            matches.RemoveAll(m => m.HomeTeam == homeTeam && m.AwayTeam == awayTeam);
        }

        public List<SportRadarMatch> GetMatchesInProgressOrderedByTotalScore()
        {
            return matches.OrderByDescending(m => m.GetTotalScore())
                          .ThenByDescending(m => matches.IndexOf(m))
                          .ToList();
        }

        public List<string> GetSummary()
        {
            return matches
                .OrderByDescending(m => m.HomeTeamScore + m.AwayTeamScore)
                .ThenByDescending(m => matches.IndexOf(m))
                .Select(m => $"{m.HomeTeam} {m.HomeTeamScore} - {m.AwayTeam} {m.AwayTeamScore}")
                .ToList();
        }
    }
}
