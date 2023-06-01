using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace FootballTables 
{
   public class League 
   {
    [MinLength(2, ErrorMessage = "Error. League name must be at least two characters")]
    public string Name { get; set; }
    public Dictionary<string, Team> Teams { get; set; }
    public List<Team> LeagueTable { get; set; }
    [Range(0, 32, ErrorMessage = "Error. Rounds Played must be in the range: 0-32")]
    public int RoundsPlayed { get; set; } = 0;
    public List<Team> ChampionshipPlayOffTable { get; set; } = new List<Team>();
    public List<Team> RelegationPlayOffTable { get; set; } = new List<Team>();

    public League(string name, Dictionary<string, Team> teams, List<Team> leagueTable) 
    {
        this.Name = name;
        this.Teams = teams;
        this.LeagueTable = leagueTable;
    }

    public Team GetTeamByName(string teamName) =>
    (Teams.ContainsKey(teamName) is true) ? Teams[teamName] : throw new Exception("error. Team not found");
    

    public void UpdateLeagueTable(Round round, List<Team> tableToUpdate) 
    {
        foreach (Match match in round.Matches) 
        {
            Team homeTeam = GetTeamByName(match.HomeTeam);
            Team awayTeam = GetTeamByName(match.AwayTeam);

            homeTeam.UpdateStatsAfterGame(match.HomeGoals, match.AwayGoals);
            awayTeam.UpdateStatsAfterGame(match.AwayGoals, match.HomeGoals);

            var orderedTable = tableToUpdate.OrderByDescending(team => team.Points).ThenByDescending(team => team.GoalDifference);
            tableToUpdate = orderedTable.ToArray().ToList();
        }
        RoundsPlayed++;
    }

    public void AllocateTeamsToPlayoffTables() 
    {
    
        const int mainSeasonNumberOfRounds = 22;
        switch (RoundsPlayed) 
        {
            case mainSeasonNumberOfRounds:
            ChampionshipPlayOffTable = LeagueTable.GetRange(0, 6);
            RelegationPlayOffTable = LeagueTable.GetRange(6, 6);
            break;

            case < mainSeasonNumberOfRounds:
            throw new Exception($"Error. Cannot allocate teams to their respective playoff table while main season is active");
                

            case > mainSeasonNumberOfRounds:
            throw new Exception($"Error. Main season is only {mainSeasonNumberOfRounds} rounds. Current Rounds played is {RoundsPlayed}");
        }
    }

        

    public void UpdateMultipleRounds(List<Round> rounds, List<Team> tableToUpdate) {
        foreach (Round round in rounds) 
        {
            UpdateLeagueTable(round, tableToUpdate);
        }
        PrintLeagueTable(tableToUpdate);
    }

    public void PrintLeagueTable(List<Team> tableToPrint) 
    {
        int currentPosition = 1;
        foreach (Team team in tableToPrint) 
        {
            string lastFiveGames = team.PrintLastFiveGames();
            Console.WriteLine($"Pos. {currentPosition} {team.Name}  Goaldifference {team.GoalsScored}-{team.GoalsAgainst} Points {team.Points} Games Played {team.GamesPlayed} Form {lastFiveGames}");
            currentPosition++;
        }   
   }
   } 
}