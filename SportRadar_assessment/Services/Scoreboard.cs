using SportRadar_assessment.Contracts;

namespace SportRadar_assessment.Services
{
    public class Scoreboard : IScoreboard
    {
        private List<(string, string, int, int)> matches;
        public Scoreboard()
        {
                matches = new List<(string, string, int, int)> ();
        }
        public void FinishMatch(string homeTeam, string awayTeam)
        {
            matches.RemoveAll(m => m.Item1 == homeTeam && m.Item2 == awayTeam);
        }

        public List<string> GetSummary()
        {
            // Order by total score (descending) and then by the most recently started match (descending)
            var summary = matches.OrderByDescending(m => m.Item3 + m.Item4)
                                .ThenByDescending(m => matches.IndexOf(m))
                                .Select(m => $"{m.Item1} {m.Item3} - {m.Item2} {m.Item4}")
                                .ToList();
            return summary;
        }

        public void StartMatch(string homeTeam, string awayTeam)
        {
            matches.Add((homeTeam, awayTeam, 0, 0));
        }

        public void UpdateScore(string homeTeam, string awayTeam, int homeScore, int awayScore)
        {
            var match = matches.FirstOrDefault(m => m.Item1 == homeTeam && m.Item2 == awayTeam);
            if (match != default)
            {
                matches.Remove(match);
                matches.Add((homeTeam, awayTeam, homeScore, awayScore));
            }
        }
    }
}
