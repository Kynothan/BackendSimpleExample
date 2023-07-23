using Application.Player.ViewModel;
using Core.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PlayersStatistics.Get
{
    public class GetPlayerStatisticsUseCase
    {
        private IPlayerStatisticsService _playerStatisticsService { get; }

        public GetPlayerStatisticsUseCase(IPlayerStatisticsService playerStatisticsService)
        {
            _playerStatisticsService = playerStatisticsService;
        }

        public PlayerStatisticsViewModel Execute()
        {
            PlayerStatisticsViewModel playerStatisticsViewModel = new PlayerStatisticsViewModel();
            playerStatisticsViewModel.playerStatistics = _playerStatisticsService.GetPlayerStatistics();
            return playerStatisticsViewModel;
        }
    }
}
