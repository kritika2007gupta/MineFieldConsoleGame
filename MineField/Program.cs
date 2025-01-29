// See https://aka.ms/new-console-template for more information
using MineField.Models;
using MineField.Logic;
using System.Collections.Generic;
using System.Numerics;
using Microsoft.Extensions.DependencyInjection;
using MineField.Repositories;
using MineField.Repository;

internal class Program
{
    static void Main(string[] args)
    {
        string playAgain = "Y";
        while (playAgain.ToUpper() == "Y")
        {
            MineGame game = new MineGame();
            game.Start();
            
            Console.WriteLine("\nWould you like to play agian? Y?N");
            playAgain = Console.ReadLine();
        }
        

    }

}





