using Core.Models;
using Core.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class PlayerStatisticsService : IPlayerStatisticsService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerStatisticsService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public PlayerStatistics GetPlayerStatistics() // je te refait ta methode en plus sexy/ opti mais à part la notion de poids pour l'imc tout est good ! gg je suis fière de toi !
        {
            IEnumerable<Player> players = _playerRepository.GetPlayer(); // on préfère les variable explicite on évite le 'var'
            
            Dictionary<string, int> winsByCountry = new Dictionary<string, int>();
            
            double totalIMC = 0;

            List<int> playerHeights = new List<int>(); // Liste des tailles des joueurs

            // Parcours des joueurs pour compter les victoires par pays
            foreach (var player in players)
            {
                int totalWins = player.Data.Last.Count(win => win == 1);

                totalIMC += CalculateIMC(player.Data.Weight, player.Data.Height); //Attention le poids n'est pas en kg par défault
                playerHeights.Add(player.Data.Height); // Ajout de la taille du joueur à la liste

                if (winsByCountry.ContainsKey(player.Country.Code))
                {
                    winsByCountry[player.Country.Code] += totalWins;
                }
                else
                {
                    winsByCountry[player.Country.Code] = totalWins;
                }
            }

            double averageIMC = players.Count() > 0 ? (double)totalIMC / players.Count() : 0;

            // Calculer la médiane des tailles des joueurs
            int medianHeight = CalculateMedian(playerHeights);

            string countryCodeWithMostWins = winsByCountry.OrderByDescending(x => x.Value).First().Key;

            Country countryWithMostWins = players.FirstOrDefault(player => player.Country.Code == countryCodeWithMostWins)?.Country;

            return new PlayerStatistics
            {
                CountryWitchHasTheBestRatio = countryWithMostWins,
                MeanBmiOfThePlayers = (int)Math.Round(averageIMC),
                MedianHeightOfThePlayers = medianHeight
            };
        }

        private double CalculateIMC(int weightInKg, int heightInCm)
        {
            // Conversion de la taille en mètres
            double heightInMeters = heightInCm / 100.0;

            // Calcul de l'IMC
            return weightInKg / (heightInMeters * heightInMeters);
        }   

        private int CalculateMedian(List<int> values)
        {
            int[] sortedArray = values.OrderBy(v => v).ToArray();
            int n = sortedArray.Length;
            int mid = n / 2;

            if (n % 2 == 0)
            {
                // Si le nombre d'éléments est pair, calculer la moyenne des deux éléments du milieu
                return (sortedArray[mid - 1] + sortedArray[mid]) / 2;
            }
            else
            {
                // Si le nombre d'éléments est impair, retourner l'élément du milieu
                return sortedArray[mid];
            }
        }

        public PlayerStatistics GetPlayerStatisticsVHippo()
        {
            IEnumerable<Player> players = _playerRepository.GetPlayer().ToArray();

            return new PlayerStatistics()
            {
                MeanBmiOfThePlayers = (int)Math.Round(players.Average(p => p.Imc), MidpointRounding.AwayFromZero),
                MedianHeightOfThePlayers = (int)Math.Round(players.Count() % 2 == 0
                    ? players.Select(x => x.Data.Height).OrderBy(x => x).Skip(players.Count() / 2 - 1).Take(2).Average()
                    : players.Select(x => x.Data.Height).OrderBy(x => x).ElementAt(players.Count() / 2), MidpointRounding.AwayFromZero),
                CountryWitchHasTheBestRatio = players.GroupBy(p => p.Country.Code).Select(grouping =>
                {
                    return new
                    {
                        countryRatio = grouping.Sum(p => p.RatioOfPlayer) / grouping.Count(),
                        country = grouping.Select(g => g.Country).First()
                    };
                }).OrderByDescending(o => o.countryRatio).Select(c => c.country).First()
            };

        }
        
    }
}
