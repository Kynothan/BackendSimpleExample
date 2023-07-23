using Application.Player.ViewModel;
using Core.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Player.Get
{
    public class GetPlayerOrderByIdUseCase
    {
        private IPlayerService _playerService { get; }

        public GetPlayerOrderByIdUseCase(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public PlayerViewModel Execute(int id)
        {
            PlayerViewModel playerViewModel = new PlayerViewModel();
            playerViewModel.Player = _playerService.GetPlayerById(id);
            return playerViewModel;
        }
    }
}
