using System;
using System.ComponentModel.DataAnnotations;

namespace FootballTables 
{
    public class Team 
    {
        [MinLength(2, ErrorMessage = "Error. Team name must be at least two characters")]
        public string Name { get; set; }
        [StringLength(3, ErrorMessage = "Error. Team abbreviation must consist of three characters")]
        public string Abbreviation { get; set; }
        [Range(0, 96, ErrorMessage = "Error. Points must be in the range: 0-96")]
        public int Points { get; set;} = 0;
        public int GoalsScored { get; set; } = 0;
        public int GoalsAgainst { get; set; } = 0;
        [Range(0, 32, ErrorMessage = "Error. Games Played must be in the range: 0-32")]
        public int GamesPlayed { get; set; } = 0; 
        public QueueWithMaxSize<char> LastFiveGames { get; set; } = new QueueWithMaxSize<char>(5);
        public int GoalDifference 
        {
            get => GoalsScored - GoalsAgainst;
        }

        public Team(string name, string abbreviation) 
        {
            this.Name = name;
            this.Abbreviation = abbreviation;
            
        }

        private void UpdateLastFiveGames(int points) {
            var resultAsChar = points switch
            {
                3 => 'W',
                0 => 'L',
                1 => 'D',
                _ => throw new Exception("Error. Invalid result")
            };
            LastFiveGames.Enqueue(resultAsChar);
        }

        public void UpdateStatsAfterGame(int goalsScored, int goalsAgainst) 
        {
            GamesPlayed++;
            GoalsScored += goalsScored;
            GoalsAgainst += goalsAgainst;
            int points = UpdatePointsBasedOnMatch(goalsScored, goalsAgainst);
            UpdateLastFiveGames(points);
        }

        private int UpdatePointsBasedOnMatch(int goalsScored, int GoalsAgainst) 
        {
            var goalDifference = goalsScored - GoalsAgainst;
            var points = goalDifference switch
            {
                0 => 1,
                > 0 => 3,
                < 0 => 0
            };
            Points += points;
            return points;
        }

        public string PrintLastFiveGames() 
        {
            var currentStreak = "";
            
            foreach (char result in LastFiveGames) 
            {
                currentStreak += result;
            }
            return currentStreak;
        }

        public string PrintGames() => string.Join("-", LastFiveGames);
    }
}