
using System.Linq;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Schema;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
using System;
using System.Runtime.InteropServices;

using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;

namespace CSharpBattleShip
{
    public class Player
    {
        public AircraftCarrier aircraftcarrier;
        public Battleship battleship;
        public Submarine submarine;
        public Destroyer destroyer;
        public string name;


        public Player(string name)
        {
            this.name = name;
            aircraftcarrier = new AircraftCarrier("Aircraft Carrier");
            battleship = new Battleship("Battleship");
            submarine = new Submarine("Submarine");
            destroyer = new Destroyer("Destroyer");
        }

        public void CreateMatrices()
        {
            aircraftcarrier.PlaceShips();
            battleship.PlaceShips();
            submarine.PlaceShips();
            destroyer.PlaceShips();

        }

        public void ResetMatrices()
        {
            Array.Clear(aircraftcarrier.newBoard, 0, aircraftcarrier.newBoard.Length);
            Array.Clear(battleship.newBoard, 0, battleship.newBoard.Length);
            Array.Clear(submarine.newBoard, 0, submarine.newBoard.Length);
            Array.Clear(destroyer.newBoard, 0, destroyer.newBoard.Length);
        }

        public int[,] CombineMatrices()
        {

            //int total = 0;
            int[,] arr3 = new int[22, 22];
            int[,] arr6 = new int[22, 22];
            int[,] arr7 = new int[22, 22];

            int i, j, n;
            n = 22;

            //List<string> printedLine = new List<string>();



            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    //Console.WriteLine(arr3[i, j]);
                    //Console.WriteLine(aircraftcarrier.newBoard[i, j]);
                    //Console.WriteLine(battleship.newBoard[i, j]);
                    arr3[i, j] = aircraftcarrier.newBoard[i, j] + battleship.newBoard[i, j];
                }
            }


            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    arr6[i, j] = submarine.newBoard[i, j] + destroyer.newBoard[i, j];
                }
            }
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    arr7[i, j] = arr3[i, j] + arr6[i, j];

                }

            }
            return arr7;
        }




        //add matrices returns the combined array. 
        //next i need to add the combined array up 
        // then if they add up, print the combined array. 

        public static int AddMatrices(int[,] matrixToAdd)
        {
            int total = 0;
            int i, j, n;
            n = 21;
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    total += matrixToAdd[i, j];
                }
            }

            return total;
        }




        public void CheckMatrices()
        {
            int newTotal;

            do
            {
                //newTotal = 0;
                ResetMatrices();
                CreateMatrices();
                //returns arr7;
                int[,] combinedArray = CombineMatrices();
                //returns aggregate of combinedArray;
                newTotal = AddMatrices(combinedArray);
                if (newTotal == 28)
                {

                    //add numbers to x and y [0]; 
                    int[,] board1 = DefineColumnNumbers();
                    int[,] board2 = DefineRowNumbers();
                    int[,] board3 = AddTwoBoards(board1, board2);
                    int[,] finalBoard = AddTwoBoards(board3, combinedArray);

                    //print matrix in a pretty table


                    PrintMatrix(finalBoard);

                }

            }
            while (newTotal != 28);



        }

        public static void PrintMatrix(int[,] matrixToPrint)
        {
            List<string> printedLine = new();
            int n = 22;

            for (int y = 0; y < 22; y++)
            {
                if (y == 0)
                {
                    for (int x = 0; x < n; x++)
                    {
                        if (x == 0)
                        {
                            printedLine.Add($" {matrixToPrint[y, x]}");

                        }
                        else if (x > 0 && x < 10)
                        {
                            printedLine.Add($" {matrixToPrint[y, x]}");

                        }
                        else if (x > 9 && x < 21)
                        {
                            printedLine.Add($"{matrixToPrint[y, x]}");

                        }
                        else
                        {
                            Console.WriteLine(string.Join(" ", printedLine));
                            printedLine.Clear();

                        }
                    }
                }
                else if (y > 0 && y < 10)
                {
                    for (int x = 0; x < n; x++)
                    {
                        if (x == 0)
                        {

                            printedLine.Add($"  {matrixToPrint[y, x]}");

                        }
                        else if (x > 0 && x < 21)
                        {
                            printedLine.Add($" {matrixToPrint[y, x]}");

                        }
                        else
                        {
                            Console.WriteLine(string.Join(" ", printedLine));
                            printedLine.Clear();
                        }
                    }
                }
                else
                {
                    for (int x = 0; x < n; x++)
                    {
                        if (x < 21)
                        {

                            printedLine.Add($" {matrixToPrint[y, x]}");

                        }
                        else
                        {
                            Console.WriteLine(string.Join(" ", printedLine));
                            printedLine.Clear();
                        }
                    }
                }
            }
        }

        //}
        //{

        //    if(y < 10 && x == 0)
        //    {
        //        printedLine.Add($" {matrixToPrint[y, x]}");

        //    }
        //    else if (y > 9 && x > 0 && x < 10)
        //    {
        //        printedLine.Add($" {matrixToPrint[y, x]}");

        //    }
        //    else if (x > 9 && x < 21)
        //    {
        //        printedLine.Add($"{matrixToPrint[y, x]}");

        //    }
        //    else
        //{
        //    Console.WriteLine(string.Join(" ", printedLine));
        //    printedLine.Clear();
        //}


        //for (int y = 9; y < 21; y++)
        //{
        //    for (int x = 0; x < n; x++)
        //    {

        //        if (x < 10)
        //        {
        //            printedLine.Add($" {matrixToPrint[y, x]}");

        //        }
        //        else if (x > 9 && x < 21)
        //        {
        //            printedLine.Add($"{matrixToPrint[y, x]}");

        //        }
        //        else
        //        {
        //            Console.WriteLine(string.Join(" ", printedLine));
        //            printedLine.Clear();
        //        }

        //    }
        //}



        public CustomArray<int> CustomArray = new();



        public int[,] DefineColumnNumbers()
        {

            int[,] blankBoard = new int[22, 22];

            for (int j = 0; j < 22; j++)
            {
                blankBoard[0, j] = j;
            }

            return blankBoard;
        }


        public int[,] DefineRowNumbers()
        {

            int[,] blankBoard = new int[22, 22];

            for (int j = 0; j < 22; j++)
            {
                blankBoard[j, 0] = j;
            }

            return blankBoard;
        }


        public int[,] AddTwoBoards(int[,] board1, int[,] board2)
        {
            int i, j, n;
            n = 22;
            int[,] board3 = new int[22, 22];


            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    board3[i, j] = board1[i, j] + board2[i, j];
                }
            }

            return board3;
        }


    }

}