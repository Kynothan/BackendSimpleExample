using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Player.ViewModel
{
    public class PlayerListViewModel
    {
        public IEnumerable<Core.Models.Player> Players { get; set; }
    }
}
