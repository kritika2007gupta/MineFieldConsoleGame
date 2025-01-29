using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineField.Models
{
    public class Board
    {
        public char[,] boardIndex;
        public int rows { get; set; }
        public int cols { get; set; }
        public Board(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            boardIndex = new char[rows, cols];
        }

    }
}
