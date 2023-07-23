using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Ports
{
    public interface IPlayerService
    {
        public IEnumerable<Player> GetPlayerByRank();

        public Player? GetPlayerById(int id);
    }
}
