namespace SportRadar_assessment.Contracts
{
    public interface IScoreboard
    {
        void StartMatch(string homeTeam, string awayTeam);
        void UpdateScore(string homeTeam, string awayTeam, int homeScore, int awayScore);
        void FinishMatch(string homeTeam, string awayTeam);
        List<string> GetSummary();
    }
}
