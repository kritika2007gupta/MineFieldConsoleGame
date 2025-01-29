using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineField.Models
{
    public class GridLocation
    {
        private int _col;
        public int row {  get; set; }
        public char colChar { get { return (char)('A' + _col); } }
        public GridLocation(int row, int col) 
        { 
            this.row = row;
            _col = col;
        }
    }
}
