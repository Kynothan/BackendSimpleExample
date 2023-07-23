using Application.Player.ViewModel;
using Core.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Player.Get
{
    public class GetPlayerOrderByRankUseCase
    {
        private IPlayerService _playerService { get; }

        public GetPlayerOrderByRankUseCase(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public PlayerListViewModel Execute()
        {
            return new PlayerListViewModel
            {
                Players = _playerService.GetPlayerByRank()
            };;
        }
    }
}
