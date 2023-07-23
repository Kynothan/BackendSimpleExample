using Application.Player.Get;
using Application.Player.ViewModel;
using Application.PlayersStatistics.Get;
using Microsoft.AspNetCore.Mvc;

namespace Training.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class PlayerStatisticsController : ControllerBase
    {

        [HttpGet]
        public PlayerStatisticsViewModel Get([FromServices] GetPlayerStatisticsUseCase useCase)
        {
            return useCase.Execute();
        }
    }
}
