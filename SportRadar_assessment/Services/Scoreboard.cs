using SportRadar_assessment.Contracts;
using SportRadar_assessment.Models;

namespace SportRadar_assessment.Services
{
    public class Scoreboard : IScoreboard
    {
        private List<SportRadarMatch> matches;
        public Scoreboard()
        {
            matches = new List<SportRadarMatch>();
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
            // Order by total score (descending) and then by the most recently started match (descending)
            var summary = matches.OrderByDescending(m => m.AwayTeam + m.HomeTeam)
                                .ThenByDescending(m => matches.IndexOf(m))
                                .Select(m => $"{m.HomeTeam} {m.AwayTeamScore} - {m.AwayTeam} {m.HomeTeamScore}")
                                .ToList();
            return summary;
        }

        public void StartMatch(string homeTeam, string awayTeam)
        {
            SportRadarMatch match = new SportRadarMatch(homeTeam, awayTeam);
            matches.Add(match);
        }

        public void UpdateScore(string homeTeam, string awayTeam, int homeScore, int awayScore)
        {
            SportRadarMatch match = matches.Find(m => m.HomeTeam == homeTeam && m.AwayTeam == awayTeam);
            if (match != null)
            {
                match.UpdateScore(homeScore, awayScore);
            }
            else
            {
                // Handle match not found
                Console.WriteLine("Match not found!");
            }
        }
    }
}
