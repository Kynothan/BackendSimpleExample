using Application.Player.Get;
using Application.Player.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Training.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class PlayerController : ControllerBase
    {

        [HttpGet]
        public PlayerListViewModel Get([FromServices] GetPlayerOrderByRankUseCase useCase)
        {
            return useCase.Execute();
        }

        [HttpGet("{id}")] // Route avec un paramètre id
        public PlayerViewModel Get([FromServices] GetPlayerOrderByIdUseCase useCase, int id)
        {
            return useCase.Execute(id);
        }
    }
}
