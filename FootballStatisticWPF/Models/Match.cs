﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FootballStatisticWPF.Models
{
    public class Match
    {
        public string round { get; set; }
        public DateTime date { get; set; }
        public string team1 { get; set; }
        public string team2 { get; set; }
        public Score score { get; set; }
    }
}
