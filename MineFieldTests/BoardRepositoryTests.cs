using Microsoft.Extensions.DependencyInjection;
using MineField.Models;
using MineField.Repositories;
using MineFieldTests.DI;

namespace MineFieldTests
{
    public class BoardRepositoryTests
    {
        private readonly IBoardRepository _boardRepository;
        private Board _board;

        public BoardRepositoryTests()
        {
            _boardRepository = ServiceProviderTestHelper.GetServiceProvider().GetRequiredService<IBoardRepository>();
            _board = _boardRepository.GetBoard();
        }

        [Fact]
        public void Initialize_BoardCorrectly()
        {

            //Act

            //Assert
            for (int row = 0; row < _board.rows; row++) 
            {
                for(int col=0; col < _board.cols; col++)
                {
                    Assert.Equal('*', _board.boardIndex[row, col]);
                }
            }
        }
        [Fact]
        public void SetMine_Correctly()
        {
            //Arrange
            int numberOfMines = 10;
            int actualMinesFromGrid = 0;
            //Act
            _boardRepository.SetMines(numberOfMines);
            var minesPlaced = _boardRepository.GetMines();

            //Assert
            Assert.Equal(numberOfMines, minesPlaced.Count());

            for (int r = 0; r < _board.rows; r++)
            {
                for (int c = 0; c < _board.cols; c++)
                {
                    if (_board.boardIndex[r, c] == 'M')
                    {
                        actualMinesFromGrid++;
                        Assert.True(minesPlaced.ContainsKey(r*10+c));
                    }
                }
            }
            Assert.Equal(numberOfMines, actualMinesFromGrid);
        }

        [Fact]
        public void IsMine_Exists()
        {
            //Arrange
            int numberOfMines = 10;
            
            //Act
            _boardRepository.SetMines(numberOfMines);
            var minesPlaced = _boardRepository.GetMines();
            bool[] results = new bool[numberOfMines];
            int i = 0;
            foreach (KeyValuePair<int, bool> kvp in minesPlaced) 
            {
                results[i] = _boardRepository.IsMine(new Player(3) { row = kvp.Key/10, col=kvp.Key%10});
                i++;
            }

            //Assert
            Assert.Equal(numberOfMines, results.Select(x => x).Where(x => x == true).Count());
        }
    }
}