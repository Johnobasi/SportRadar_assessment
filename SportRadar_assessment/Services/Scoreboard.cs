using SportRadar_assessment.Contracts;

namespace SportRadar_assessment.Services
{
    public class Scoreboard : IScoreboard
    {
        public void FinishMatch(string homeTeam, string awayTeam)
        {
            throw new NotImplementedException();
        }

        public List<string> GetSummary()
        {
            throw new NotImplementedException();
        }

        public void StartMatch(string homeTeam, string awayTeam)
        {
            throw new NotImplementedException();
        }

        public void UpdateScore(string homeTeam, string awayTeam, int homeScore, int awayScore)
        {
            throw new NotImplementedException();
        }
    }
}
