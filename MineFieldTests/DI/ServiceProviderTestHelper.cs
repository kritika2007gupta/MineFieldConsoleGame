using Microsoft.Extensions.DependencyInjection;
using MineField.Models;
using MineField.Repositories;
using MineField.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineFieldTests.DI
{
    public static class ServiceProviderTestHelper
    {
        public static int boardRow = 8;
        public static int boardCol = 8;
        public static int playerMaxLives = 3;
        public static ServiceProvider GetServiceProvider()
        {
            return new ServiceCollection()
            .AddSingleton<IBoardRepository>(new BoardRepository(new Board(boardRow, boardCol)))
            .AddSingleton<IPlayerRepository>(new PlayerRepository(new Player(playerMaxLives)))
            .BuildServiceProvider();
        }
    }
}
