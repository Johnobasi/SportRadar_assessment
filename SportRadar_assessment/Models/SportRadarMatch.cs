namespace SportRadar_assessment.Models
{
    public class SportRadarMatch
    {
        public string? HomeTeam { get; }
        public string? AwayTeam { get; }
        public int HomeTeamScore { get; private set; }
        public int AwayTeamScore { get; private set; }
        public bool IsFinished { get; private set; }
        public SportRadarMatch(string homeTeam, string awayTeam)
        {
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            HomeTeamScore = 0;
            AwayTeamScore = 0;
            IsFinished = false;
        }

        public void UpdateScore(int homeTeamScore, int awayTeamScore)
        {
            HomeTeamScore = homeTeamScore;
            AwayTeamScore = awayTeamScore;
        }


        public void FinishMatch()
        {
            IsFinished = true;
        }

        public int GetTotalScore()
        {
            return HomeTeamScore + AwayTeamScore;
        }
    }
}
