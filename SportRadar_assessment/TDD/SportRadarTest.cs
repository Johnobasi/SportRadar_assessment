using SportRadar_assessment.Models;
using SportRadar_assessment.Services;
using Xunit;

namespace SportRadar_assessment.TDD
{

    public class SportRadarTest
    {
        [Fact]
        public void Summary_ShouldReturnMatchesITotalScore()
        {
            var scoreboard = new Scoreboard();

            var match1 = new SportRadarMatch("Mexico", "Canada");
            var match2 = new SportRadarMatch("Spain", "Brazil");
            var match3 = new SportRadarMatch("Germany", "France");
            var match4 = new SportRadarMatch("Uruguay", "Italy");
            var match5 = new SportRadarMatch("Argentina", "Australia");

            match1.UpdateScore(0, 5);
            match2.UpdateScore(10, 2);
            match3.UpdateScore(2, 2);
            match4.UpdateScore(6, 6);
            match5.UpdateScore(3, 1);

            scoreboard.StartMatch(match1.HomeTeam, match1.AwayTeam);
            scoreboard.StartMatch(match2.HomeTeam, match2.AwayTeam);
            scoreboard.StartMatch(match3.HomeTeam, match3.AwayTeam);
            scoreboard.StartMatch(match4.HomeTeam, match4.AwayTeam);
            scoreboard.StartMatch(match5.HomeTeam, match5.AwayTeam);

            var summary = scoreboard.GetSummary();

            Assert.Equal("Uruguay 6 - Italy 6", summary[0]);
            Assert.Equal("Spain 10 - Brazil 2", summary[1]);
            Assert.Equal("Mexico 0 - Canada 5", summary[2]);
            Assert.Equal("Argentina 3 - Australia 1", summary[3]);
            Assert.Equal("Germany 2 - France 2", summary[4]);
        }
    }


}
