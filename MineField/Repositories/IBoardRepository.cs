using MineField.Models;

namespace MineField.Repositories
{
    public interface IBoardRepository 
    {

        Dictionary<int, bool> GetMines();
        void SetMines(int numberOfMines);
        Board GetBoard();
        bool IsMine(Player player);
        void ShowBoard(Player player);
    }
}
