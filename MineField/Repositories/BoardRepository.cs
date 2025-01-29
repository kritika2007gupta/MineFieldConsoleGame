using MineField.Models;
using MineField.Repositories;

namespace MineField.Repository
{
    public class BoardRepository : IBoardRepository
    {
        private readonly Board _board;
        private Dictionary<int, bool> _minesPlaced = new();
        public BoardRepository(Board board)
        {
            _board = board;
            InitializeBoard();
        }
        private void InitializeBoard()
        {
            for(int row=0; row < _board.rows; row++)
            {
                for(int col=0; col < _board.cols; col++)
                {
                    _board.boardIndex[row, col] = '*';
                }
            }
        }
        public bool IsMine(Player player)
        {
            return _minesPlaced.ContainsKey(player.row * 10 + player.col);
        }
        public Board GetBoard()
        {
            return _board;
        }
        public Dictionary<int,bool> GetMines() 
        {
            return _minesPlaced;
        }

        public void SetMines(int numberOfMines)
        {
            for(int i = 1; i <= numberOfMines; i++)
            {
                int minedRow = 0;
                int minedCol = 0;
                do
                {
                    minedRow = new Random().Next(0, _board.rows);
                    minedCol = new Random().Next(0, _board.cols);
                } while ((minedRow == 0 && minedCol == 0) || _minesPlaced.ContainsKey(minedRow*10+minedCol));
                _board.boardIndex[minedRow, minedCol] = 'M';
                _minesPlaced.Add(minedRow * 10 + minedCol, true);
            }

        }
        public void ShowBoard(Player player)
        {
            Console.Clear();
            for (int row = 0; row < _board.rows; row++)
            {
                for (int col = 0; col < _board.cols; col++)
                {
                    if (player.row == row && player.col == col)
                        Console.Write(" P ");
                    else
                    Console.Write($" * ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Lives Left: " + player.NumberOfLivesLeft + " Moves Taken : " + player.NumberOfMovesTaken);
            

        }
    }
}
