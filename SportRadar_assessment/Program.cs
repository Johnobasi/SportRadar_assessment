using SportRadar_assessment.Models;
using SportRadar_assessment.Services;

public class Program
{

    public static void Main()
    {
        Scoreboard scoreboard = new Scoreboard();

        scoreboard.StartMatch("Mexico", "Canada");
        scoreboard.UpdateMatchScore(0, 0, 5);

        scoreboard.StartMatch("Spain", "Brazil");
        scoreboard.UpdateMatchScore(1, 10, 2);

        scoreboard.StartMatch("Germany", "France");
        scoreboard.UpdateMatchScore(2, 2, 2);

        scoreboard.StartMatch("Uruguay", "Italy");
        scoreboard.UpdateMatchScore(3, 6, 6);

        scoreboard.StartMatch("Argentina", "Australia");
        scoreboard.UpdateMatchScore(4, 3, 1);

        // Finish match (index 2) between Germany and France
        scoreboard.FinishMatch(2);

        List<SportRadarMatch> matchesInProgress = scoreboard.GetMatchesInProgressOrderedByTotalScore();

        Console.WriteLine("Summary of matches in progress ordered by total score:");
        int position = 1;
        foreach (var match in matchesInProgress)
        {
            Console.WriteLine($"{position}. {match.HomeTeam} {match.HomeTeamScore} - {match.AwayTeam} {match.AwayTeamScore}");
            position++;
        }
    }
}