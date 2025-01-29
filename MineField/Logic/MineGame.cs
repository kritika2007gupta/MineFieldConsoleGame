using Microsoft.Extensions.DependencyInjection;
using MineField.DI;
using MineField.Models;
using MineField.Models.Enums;
using MineField.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MineField.Logic
{
    internal class MineGame
    {
        private IBoardRepository _boardRepository;
        private IPlayerRepository _playerRepository;
        private Board _board;
        private Player _player;

        public MineGame()
        {
            _boardRepository = ServiceProviderHelper.GetServiceProvider().GetRequiredService<IBoardRepository>();
            _playerRepository = ServiceProviderHelper.GetServiceProvider().GetRequiredService<IPlayerRepository>();
            _board = _boardRepository.GetBoard();
            _player = _playerRepository.GetPlayer();
        }
        public void Start()
        {
            _boardRepository.SetMines(10);
            _boardRepository.ShowBoard(_player);
            var mines = _boardRepository.GetMines();

            while (_player.NumberOfLivesLeft > 0 && _player.row < _board.rows - 1)
            {
                MakeMove();
            }
            if (_player.NumberOfLivesLeft > 0)
                Console.WriteLine("Congratulations!! You have won the game");
            else
                Console.WriteLine("Opps!! You have lost the game");

            Console.WriteLine("Mines were present at grids ");
            foreach (int key in mines.Keys)
            {
                Console.Write($" {(char)('A' + (key%10))}{8 - (key/10)}");
            }            
        }
        void MakeMove()
        {
            Console.WriteLine("Enter your moves: up, down, left, right");
            var move = Console.ReadLine();

            bool validMovesMade = Enum.TryParse(move.ToUpper(), out PlayerMoves.Types movesMade);
            if (validMovesMade)
            {
                _playerRepository.NextMove(movesMade, _board);

                _player.NumberOfMovesTaken++;
                _player.gridsTraversed.Add(new GridLocation(_player.row, _player.col));

                if (_boardRepository.IsMine(_player))
                {
                    _player.NumberOfLivesLeft--;
                    _boardRepository.ShowBoard(_player);
                    Console.WriteLine($"You have hit a mine and have lost a life. You have {_player.NumberOfLivesLeft} lives left");
                }
                else
                    _boardRepository.ShowBoard(_player);
                Console.WriteLine("Grids traversed are:");
                foreach (GridLocation grid in _player.gridsTraversed)
                {
                    Console.Write($" {grid.colChar}{8 - grid.row} ");
                }
            }
            else
                Console.WriteLine("Invalid move made. Try again.");

            Console.WriteLine();
        }
    }
}
