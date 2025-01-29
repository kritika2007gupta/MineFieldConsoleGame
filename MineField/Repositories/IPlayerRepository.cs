using MineField.Models;
using MineField.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineField.Repositories
{
    public interface IPlayerRepository
    {
        void NextMove(PlayerMoves.Types move, Board board);
        Player GetPlayer();
    }
}
