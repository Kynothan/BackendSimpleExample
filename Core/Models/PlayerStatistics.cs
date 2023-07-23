using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class PlayerStatistics // on précise plus les variable, médiane oui mais médiane de quoi ?
    {
        public Country CountryWitchHasTheBestRatio { get; set; }
        public int MeanBmiOfThePlayers { get; set; }
        public int MedianHeightOfThePlayers { get; set; }  
    }
}
