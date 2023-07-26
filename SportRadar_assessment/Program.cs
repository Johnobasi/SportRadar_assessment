using SportRadar_assessment.Models;
using SportRadar_assessment.Services;

public class Program
{

    public static void Main()
    {
        Scoreboard scoreboard = new Scoreboard();

        scoreboard.StartMatch("Mexico", "Canada");
        scoreboard.UpdateScore("Mexico", "Canada", 0, 5);

        scoreboard.StartMatch("Spain", "Brazil");
        scoreboard.UpdateScore("Spain", "Brazil", 10, 2);

        scoreboard.StartMatch("Germany", "France");
        scoreboard.UpdateScore("Germany", "France", 2, 2);

        scoreboard.StartMatch("Uruguay", "Italy");
        scoreboard.UpdateScore("Uruguay", "Italy", 6, 6);

        scoreboard.StartMatch("Argentina", "Australia");
        scoreboard.UpdateScore("Argentina", "Australia", 3, 1);

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