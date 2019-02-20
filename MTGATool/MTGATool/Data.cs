using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGATool
{
    public class Data
    {
        public string playerId { get; set; }
        public int constructedSeasonOrdinal { get; set; }
        public string constructedClass { get; set; }
        public int constructedLevel { get; set; }
        public int constructedStep { get; set; }
        public int constructedMatchesWon { get; set; }
        public int constructedMatchesLost { get; set; }
        public int constructedMatchesDrawn { get; set; }
        public int limitedSeasonOrdinal { get; set; }
        public string limitedClass { get; set; }
        public int limitedLevel { get; set; }
        public int limitedStep { get; set; }
        public int limitedMatchesWon { get; set; }
        public int limitedMatchesLost { get; set; }
        public int limitedMatchesDrawn { get; set; }
        public double constructedPercentile { get; set; }
        public int constructedLeaderboardPlace { get; set; }
        public double limitedPercentile { get; set; }
        public int limitedLeaderboardPlace { get; set; }
    }
}
