using Core.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Ports
{
    public interface IPlayerRepository
    {
        IEnumerable<Player> GetPlayer();
        Player GetPlayerById(int id);
    }
}
