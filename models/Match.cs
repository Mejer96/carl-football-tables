using System;
using System.ComponentModel.DataAnnotations;

namespace FootballTables
{
    public struct Match 
    {
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        [Range(0, 25)]
        public int HomeGoals { get; set; }
        [Range(0,25)]
        public int AwayGoals { get; set; }

        public Match(string homeTeam, string awayTeam, int homeGoals, int awayGoals) 
        {
            this.HomeTeam = homeTeam;
            this.AwayTeam = awayTeam;
            this.HomeGoals = homeGoals;
            this.AwayGoals = awayGoals; 
        }
    }
}