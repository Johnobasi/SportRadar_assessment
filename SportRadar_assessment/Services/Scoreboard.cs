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
            SportRadarMatch newMatch = new SportRadarMatch(homeTeam, awayTeam);
            matches.Add(newMatch);
        }

        public void UpdateScore(string homeTeam, string awayTeam, int homeTeamScore, int awayTeamScore)
        {
            SportRadarMatch updateMatch = matches.Find(m => m.HomeTeam == homeTeam && m.AwayTeam == awayTeam);
            if (updateMatch != null)
            {
                updateMatch.UpdateScore(homeTeamScore, awayTeamScore);
            }
            else
            {
                // Handle match not found
                Console.WriteLine("Match not found!");
            }
        }


        public void UpdateMatchScore(int matchIndex, int homeTeamScore, int awayTeamScore)
        {
            if (matchIndex >= 0 && matchIndex < matches.Count)
            {
                SportRadarMatch match = matches[matchIndex];
                match.UpdateScore(homeTeamScore, awayTeamScore);
            }
            else
            {
                throw new IndexOutOfRangeException("Invalid match index.");
            }
        }

        public void FinishMatch(int matchIndex)
        {
            if (matchIndex >= 0 && matchIndex < matches.Count)
            {
                SportRadarMatch match = matches[matchIndex];
                match.FinishMatch();
                matches.RemoveAt(matchIndex);
            }
            else
            {
                throw new IndexOutOfRangeException("Invalid match index.");
            }
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
