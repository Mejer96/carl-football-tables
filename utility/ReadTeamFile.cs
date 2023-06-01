using System;
using System.Collections;

namespace FootballTables 
{
    public class ReadTeamFile 
    {
        public (Dictionary<string, Team> dictionary, List<Team> list) ReadFile(string filePath) 
        {
            var streamReader = new StreamReader(filePath);
            var teamsDictionary = new Dictionary<string, Team>();
            var teamsList = new List<Team>();
            var currentLineToRead = 1;

            while (!streamReader.EndOfStream) 
            {
                string currentLine = streamReader.ReadLine() ?? throw new NullReferenceException($"Line {currentLineToRead} is null");
                string[] cells = currentLine.Split(",");

                
                string teamName = cells[0] ?? throw new NullReferenceException($"Team name is null on line: {currentLineToRead}");
                string teamAbbreviation = cells[1] ?? throw new NullReferenceException($"Team name is null on line: {currentLineToRead}");
                var team = new Team(teamName, teamAbbreviation);
                teamsList.Add(team);
                teamsDictionary.Add(teamName, team);
                currentLineToRead++;
            }

            return (teamsDictionary, teamsList);
        }
    }


}