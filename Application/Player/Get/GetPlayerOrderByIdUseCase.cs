using Application.Player.ViewModel;
using Core.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Player.Get
{
    public class GetPlayerByIdUseCase // Pas vraiment de notion d'order ici 
    {
        private IPlayerService _playerService { get; }

        public GetPlayerByIdUseCase(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public PlayerViewModel Execute(int id)
        {
            return  new PlayerViewModel
            {
                Player = _playerService.GetPlayerById(id)
            };
        }
    }
}
