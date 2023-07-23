using Application.Player.Get;
using Application.PlayersStatistics.Get;
using Core.Ports;
using Core.Services;
using Infrastructure.BDD;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class DependencyInjection
    {
        public static void AddTennisServices(this IServiceCollection services, ConfigurationManager configFile)
        {
            services.AddSingleton<IPlayerRepository, PlayerRepository>(_ => new PlayerRepository(configFile["PathToJson"]));
            services.AddSingleton<IPlayerService, PlayerService>();
            services.AddSingleton<GetPlayerOrderByRankUseCase>();
            services.AddSingleton<GetPlayerOrderByIdUseCase>();
            services.AddSingleton<IPlayerStatisticsService, PlayerStatisticsService>();
            services.AddSingleton<GetPlayerStatisticsUseCase>();
        }
    }
}
