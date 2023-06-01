using System;

namespace FootballTables 
{
    public class Club 
    {
        private string Name { get; set; }
        private string Abbreviation { get; set; }
        private int Points { get; set;} = 0;
        private int GoalsScored { get; set; } = 0;
        private int GoalsAgainst { get; set; } = 0;

        public Club(string name, string abbreviation) 
        {
            this.Name = name;
            this.Abbreviation = abbreviation;
        }
    }
}