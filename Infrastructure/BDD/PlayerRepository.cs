using Core.Models;
using Core.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.BDD
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly IEnumerable<Player> _players;

        public PlayerRepository(string pathToJson)
        {
            JsonParser jsonParser = new JsonParser(pathToJson);
            _players = jsonParser.ParseJson();
        }

        public IEnumerable<Player> GetPlayer()
        {
            return _players;
        }

        public Player GetPlayerById(int id)
        {
            return _players.FirstOrDefault(player => player.Id == id);
        }
    }
}
