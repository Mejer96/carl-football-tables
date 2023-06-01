using System;
using System.ComponentModel.DataAnnotations;

namespace FootballTables 
{
    public class Round 
    {
        
        [Range(1, 32)]
        public int RoundNumber { get; set; }
        public List<Match> Matches { get; set; }
        public League League { get; set; }

        public Round(List<Match> matches, int roundNumber, League league) 
        {
            this.Matches = matches;
            this.RoundNumber = roundNumber;
            this.League = league;
        }
    }
}