using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
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


            int gameRound = 0;
            int turnHits1 = 0;
            int turnHits2 = 0;

            while (player1.health > 0 && player2.health > 0)
            {
                gameRound += 1;
                Console.WriteLine(@$"Round: {gameRound}");

            }





        }








        public void PrintWelcome()
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

            player1.CheckSpaceBarPress();



        }


        public static void AnnounceBoard(Player playerA, Player playerB)
        {

            Console.WriteLine($@"
        {playerA.name} your board is ready. {playerB.name} please look away.
        {playerA.name} press 'space' when you are ready to see your board in secret.
");

            playerA.CheckSpaceBarPress();

        }




        public int PlayTurn(int[,] turnHits1, int[,] turnHits2, int[,] player2Board)
        {
            Console.WriteLine($@"
            Here is your opponent's board as you know it, {player1.name}: 
            {turnHits1}");

            int[,] turnBoard;
            int[,] turnHitsToAdd1 = new int[21, 21];
            var tuple = InputAndEvalGuess(out turnBoard, player2Board);
            if (turnHitsToAdd1[tuple.Item1, tuple.Item2] == turnHits1[tuple.Item1, tuple.Item2])
            {
                turnHitsToAdd1[tuple.Item1, tuple.Item2] = 0;
                Console.WriteLine(@$"
            {player2.name} has {player2.health} left!");
            }
            else
            {
                turnHits1 = player1.AddTwoBoards(turnHits1, turnHitsToAdd1);
                if (player2.destroyer.newBoard[tuple.Item1, tuple.item2] == 2)
                {
                    //take damage;
                }
            }



            //not complete

        }


        public Tuple<int, int> InputAndEvalGuess(out int[,] turnBoard, int[,] player2Board)
        {
            //bool working; 

            //while (!working) 
            //{
            Console.WriteLine(@$"
            {player1.name}: choose your coordinate horizontally(1 - 20), then press 'enter':");
            // add catch for if input is given...
            int guessX = Int32.Parse(Console.ReadLine());
            // add try/catch here for numbers greater than 21
            Console.WriteLine(@$"
            {player1.name}: choose your coordinate vertically(1 - 20), then press 'enter':");
            int guessY = Int32.Parse(Console.ReadLine());
            // add try/catch here




            turnBoard = new int[21, 21];
            if (player2Board[guessY, guessX] == 2)
            {
                turnBoard[guessY, guessX] = 2;
            }
            else
            {
                turnBoard[guessY, guessX] = 1;
                Console.WriteLine("It's a miss!");
            }
            //working = true; 
            return new Tuple<int, int>(guessY, guessX);

        }




        public static void TakeDamage(Player playerA, Player playerB, Ship ship)

        {
            if (ship.health > 0)
            {


                // add time.sleep(1) to the following CWL's. 


                Console.WriteLine("It's a hit!");
                ship.health -= 1;
                playerB.health -= 1;
                //is that line above necessary??

                Console.WriteLine(@$"
            {playerB.name}'s {ship.name} now has {ship.health} health left!");

                if (ship.health == 0)
                {
                    Console.WriteLine(@$"
            {playerA.name} sank your {ship.name}!");
                }

                Console.WriteLine($@"
            {playerB.name} has {playerB.health} health left!");
            }
        }

    }

}


