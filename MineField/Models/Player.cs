using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineField.Models
{
    public class Player
    {
        public int NumberOfLivesLeft { get; set; }
        public int NumberOfMovesTaken { get; set; } = 0;
        public int row { get; set; } = 0;
        public int col { get; set; } = 0;
        public List<GridLocation> gridsTraversed { get; set; } = new();
        public Player(int MaxLives)
        {
            NumberOfLivesLeft = MaxLives;
        }

    }
}