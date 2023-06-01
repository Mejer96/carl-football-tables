using System;

namespace FootballTables 
{
    public class ReadRoundFile 
    {
        public List<Match> readFile(string filePath, int currentRound) 
        {
            var streamReader = new StreamReader(filePath);
            var matches = new List<Match>();
            var currentLineToRead = 1;

            while (!streamReader.EndOfStream) 
            {
                string currentLine = streamReader.ReadLine() ?? throw new NullReferenceException($"Line {currentLineToRead} is null in round file number: {currentRound}");
                string[] cells = currentLine.Split(",");

                string homeTeam = cells[0] ?? throw new NullReferenceException($"home team is null in round file number: {currentRound}");
                string awayTeam = cells[1] ?? throw new NullReferenceException($"away team is null in round file number: {currentRound}");
                string homeGoals = cells[2] ?? throw new NullReferenceException($"home goals is null in round file number: {currentRound}");
                string awayGoals = cells[3] ?? throw new NullReferenceException($"away goals is null in round file number: {currentRound}");
                
                matches.Add(new Match(homeTeam, awayTeam, Convert.ToInt32(homeGoals), Convert.ToInt32(awayGoals)));
                currentLineToRead++;
            }
            return matches; 
        }

  
    
    // check csv files for parameter seasonPeriode
    public List<Round> ReadAllFileRounds(int startingFileNumber, int numberOfRoundFilesToRead, League league, string seasonStage) 
    {
        var roundsFromFiles = new List<Round>(); 
        for (int i = startingFileNumber; i <= numberOfRoundFilesToRead; i++)
        {
            var currentRound = i;
            roundsFromFiles.Add(new Round(readFile($"csv files/{seasonStage}/round{currentRound}.csv", currentRound), currentRound, league));
            
        }
        return roundsFromFiles;
    }
    }
}