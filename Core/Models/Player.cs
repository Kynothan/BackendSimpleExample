using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ShortName { get; set; }
        public char Sex { get; set; }
        public Country Country { get; set; }
        public string Picture { get; set; }
        public PlayerData Data { get; set; }
        public double Imc => ((float)Data.Weight / 1000) / Math.Pow((float)Data.Height / 100, 2); // vue au c'est des propriété du player qui font se calcule autant l'encapsuler dans la classe
        public double RatioOfPlayer => (double) Data.Last.Sum() / Data.Last.Length;
    }
}