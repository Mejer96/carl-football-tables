using System;
using System.Collections;

namespace FootballTables 
{
    class Program 
    {
        static void Main(string[] args) 
        {
            var readTeamFile = new ReadTeamFile();
            var readRoundFile = new ReadRoundFile();

            (Dictionary<string, Team> teamsDictionary, List<Team> teamsList) = readTeamFile.ReadFile("csv files/clubs.csv");
            var league = new League("ALKA Superliga", teamsDictionary, teamsList);

            List<Round> rounds = readRoundFile.ReadAllFileRounds(startingFileNumber: 1, numberOfRoundFilesToRead: 22, league, seasonStage: "mainseason");
            league.UpdateMultipleRounds(rounds);
            
        }
    }
}
