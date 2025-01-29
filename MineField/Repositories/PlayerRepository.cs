using MineField.Models;
using MineField.Models.Enums;

namespace MineField.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private Player _player;
        public PlayerRepository(Player player) {
            _player = player;
        }
        public void NextMove(PlayerMoves.Types move, Board board)
        {
            switch (move)
            {
                case PlayerMoves.Types.UP:
                    if(_player.row > 0)
                        _player.row--;  
                    break;
                case PlayerMoves.Types.DOWN:
                    if (_player.row < board.rows - 1)
                        _player.row++;
                    break;
                case PlayerMoves.Types.LEFT:
                    if (_player.col > 0)
                        _player.col--;
                    break;
                case PlayerMoves.Types.RIGHT:
                    if (_player.col < board.cols - 1)
                        _player.col++;
                    break;
                default: Console.WriteLine("Invalid Move. Please try again");
                    break;
            }

        }
        public Player GetPlayer()
        {
            return _player;
        }
    }
}
