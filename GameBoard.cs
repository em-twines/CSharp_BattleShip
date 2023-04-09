using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Numerics;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CSharpBattleShip
{
    internal class GameBoard
    {   
        Player player1 = new("Player 1");
        Player player2 = new("Player 2");
        public void RunGame()
        {
            
            PrintWelcome();
            AnnounceBoard(player1, player2);
            player1.CheckMatrices();
            AnnounceBoard(player2, player1);
            player2.CheckMatrices();

        }

        public static void PrintWelcome()
        {
            Console.WriteLine(@"

        Welcome to Battleship!!! 

        Before we get started, let's review the rules. Each player will receive a randomized game board with their ships placed in secret locations. 

        Players will guess coordinates(x, y), trying to identify the position(horizontal or vertical) of their opponent's ships.

        The Destroyer is 2 spaces long.
        The Submarine is 3.
        The Battleship is 4.
        And the Aircraft Carrier is 5.

        The first player will make their guess, and if they hit any of the spaces containing an enemy ship, 
        that position will change from '0' to '2' If they miss, that position will change to a '1' 

        Be the first to sink all 4 ships to win!

        Press 'space' when you are ready to continue.

        ");

            ConsoleKeyInfo keyinfo;
            do
            {
                keyinfo = Console.ReadKey();

            }
            while (keyinfo.Key != ConsoleKey.Spacebar);
        

        }


        public static void AnnounceBoard(Player playerA, Player playerB)
        {

            Console.WriteLine($@"
        {playerA.name} your board is ready. {playerB.name} please look away.
        {playerA.name} press 'space' when you are ready to see your board in secret.
");

            ConsoleKeyInfo keyinfo;
            do
            {
                keyinfo = Console.ReadKey();

            }
            while (keyinfo.Key != ConsoleKey.Spacebar);
        }


    }


}
