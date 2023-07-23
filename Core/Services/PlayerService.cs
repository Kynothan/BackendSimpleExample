using Core.Models;
using Core.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public IEnumerable<Player> GetPlayerByRank()
        {
            return _playerRepository.GetPlayer().OrderBy(x => x.Data.Rank);
        }

        public Player? GetPlayerById(int id)
        {
            return _playerRepository.GetPlayerById(id);
        }
    }
}
