using SportRadar_assessment.Models;

namespace SportRadar_assessment.Contracts
{
    public interface IScoreboard
    {
        //not used later
        void StartMatch(string homeTeam, string awayTeam);
        void UpdateScore(string homeTeam, string awayTeam, int homeScore, int awayScore);
        void FinishMatch(string homeTeam, string awayTeam);
        List<string> GetSummary();
        public List<SportRadarMatch> GetMatchesInProgressOrderedByTotalScore();
    }
}
