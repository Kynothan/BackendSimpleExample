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

        public PlayerStatistics GetPlayerStatistics()
        {
            var players = _playerRepository.GetPlayer();
            
            Dictionary<string, int> winsByCountry = new Dictionary<string, int>();
            
            double totalIMC = 0;

            List<int> playerHeights = new List<int>(); // Liste des tailles des joueurs

            // Parcours des joueurs pour compter les victoires par pays
            foreach (var player in players)
            {
                int totalWins = player.Data.Last.Count(win => win == 1);

                totalIMC += CalculateIMC(player.Data.Weight, player.Data.Height);
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
                Country = countryWithMostWins,
                IMC = (int)Math.Round(averageIMC),
                Mediane = medianHeight
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
    }
}
