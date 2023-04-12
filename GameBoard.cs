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
            int[,] player1Board = player1.CheckMatrices();
            AnnounceBoard(player2, player1);
            int[,] player2Board = player2.CheckMatrices();


            int gameRound = 0;
            int[,] turnHits1 = new int[21, 21];
            int[,] turnHits2 = new int[21, 21];

            int[,] oneToTwentyOne = player1.WriteBlankBoard();

            //TESTING: 
            //int[,] testToPrint = player1.WriteBlankBoard();
            //player1.PrintMatrix(testToPrint);
            //player1.PrintMatrix(oneToTwentyOne);
            //player1.PrintMatrix(turnHits1);

            turnHits1 = player1.AddTwoBoards(turnHits1, oneToTwentyOne);
            turnHits2 = player1.AddTwoBoards(turnHits2, oneToTwentyOne);


            while (player1.health > 0 && player2.health > 0)
            {
                gameRound += 1;
                Console.WriteLine(@$"Round: {gameRound}");
                turnHits1 = PlayTurn(player1, player2, turnHits1, player2Board);
                turnHits2 = PlayTurn(player2, player1, turnHits2, player1Board);
            }

            if (player1.health <= 0)
            {
                Console.WriteLine(@$"
            {player2.name} is the winner! Thanks to both our players today and congratulations to {player2.name}!");
            }
            else if (player2.health <= 0)
            {
                Console.WriteLine(@$"
            {player1.name} is the winner! Thanks to both our players today and congratulations to {player1.name}!");
            }
            else
            {
                Console.WriteLine(@$"
            It's a tie! Thanks for playing!");
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




        public int[,] PlayTurn(Player playerA, Player playerB, int[,] turnHits1, int[,] player2Board)
        {
            Console.WriteLine($@"
        Here is your opponent's board as you know it, {playerA.name}:
        ");

            player1.PrintMatrixTurns(turnHits1);


            //int[,] turnBoard;
            int[,] turnHitsToAdd1 = new int[21, 21];
            var tuple = InputAndEvalGuess(out turnHitsToAdd1, player2Board);
            if (turnHitsToAdd1[tuple.Item1, tuple.Item2] == turnHits1[tuple.Item1, tuple.Item2])
            {
                turnHitsToAdd1[tuple.Item1, tuple.Item2] = 0;
                Console.WriteLine(@$"
        {playerB.name} has {playerB.health} health left!");
            }
            else
            {
                turnHits1 = playerA.AddTwoBoards(turnHits1, turnHitsToAdd1);
                if (playerB.destroyer.newBoard[tuple.Item1, tuple.Item2] == 2)
                {
                    TakeDamage(playerA, playerB, playerB.destroyer);
                }
                else if (playerB.submarine.newBoard[tuple.Item1, tuple.Item2] == 2)
                {
                    TakeDamage(playerA, playerB, playerB.submarine);
                }
                else if (playerB.battleship.newBoard[tuple.Item1, tuple.Item2] == 2)
                {
                    TakeDamage(playerA, playerB, playerB.battleship);
                }
                else if (playerB.aircraftcarrier.newBoard[tuple.Item1, tuple.Item2] == 2)
                {
                    TakeDamage(playerA, playerB, playerB.aircraftcarrier);
                }
                //add time.sleep(1); 

            }

            return turnHits1;



        }


        public Tuple<int, int> InputAndEvalGuess(out int[,] turnBoard, int[,] player2Board)
        {
            //bool working; 

            //while (!working) 
            //{
            Console.WriteLine(@$"
        {player1.name}: choose your coordinate horizontally(1 - 20), then press 'enter':");
            // add catch for if input is given...

            string input = Console.ReadLine();
            
            int guessX;

            bool success = int.TryParse(input, out guessX);
            while (!success)
            {
                if (success)

                    Console.WriteLine(@$"
        {guessX}");

                else
                {
                    Console.WriteLine(@"
        Invalid Input.");
                }

            }

            //int guessX = Int32.Parse(Console.ReadLine());


            Console.WriteLine(@$"
        {player1.name}: choose your coordinate vertically(1 - 20), then press 'enter':");
            //int guessY = Int32.Parse(Console.ReadLine());

            string inputY = Console.ReadLine();

            int guessY;

            bool successY = int.TryParse(inputY, out guessY);
            while (!successY)
            {
                if (successY)

                    Console.WriteLine(@$"
        {guessY}");

                else
                {
                    Console.WriteLine(@"
        Invalid Input.");
                }

            }


            turnBoard = new int[21, 21];
            if (player2Board[guessY, guessX] == 2)
            {
                turnBoard[guessY, guessX] = 2;
            }
            else
            {
                turnBoard[guessY, guessX] = 1;
                Console.WriteLine(@"
        It's a miss!");
            }
            //working = true; 
            return new Tuple<int, int>(guessY, guessX);

        }




        public static void TakeDamage(Player playerA, Player playerB, Ship ship)

        {
            if (ship.health > 0)
            {


                // add time.sleep(1) to the following CWL's. 


                Console.WriteLine(@"
        It's a hit!");
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


