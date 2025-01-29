using Microsoft.Extensions.DependencyInjection;
using MineField.Models;
using MineField.Models.Enums;
using MineField.Repositories;
using MineFieldTests.DI;

namespace MineFieldTests
{
    public class PlayerRepositoryTests
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly Player _player;
        private readonly Board _board;

        public PlayerRepositoryTests()
        {
            _board = new Board(8, 8);
            _playerRepository = ServiceProviderTestHelper.GetServiceProvider().GetRequiredService<IPlayerRepository>();
            _player = _playerRepository.GetPlayer();
        }

        [Theory]
        [InlineData(PlayerMoves.Types.UP, 0, 0)]
        [InlineData(PlayerMoves.Types.DOWN, 1, 0)]
        [InlineData(PlayerMoves.Types.LEFT, 0, 0)]
        [InlineData(PlayerMoves.Types.RIGHT, 0, 1)]
        public void NextMove_ShouldUpdatePlayerPosition(PlayerMoves.Types move, int expectedRow, int expectedCol)
        {
            //Arrange

            // Act
            _playerRepository.NextMove(move, _board);

            // Assert
            Assert.Equal(expectedRow, _player.row);
            Assert.Equal(expectedCol, _player.col);
        }
    }
}
