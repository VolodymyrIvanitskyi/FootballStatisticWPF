using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace FootballStatisticWPF.Models
{
    public class League
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("matches")]
        public Match[] Matches { get; set; }
    }
}
