
using System.Linq;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;

namespace CSharpBattleShip
{
    public class Player
    {
        public AircraftCarrier aircraftcarrier;
        public Battleship battleship;
        public Submarine submarine;
        public Destroyer destroyer;


        public Player()
        {
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

        public int CheckMatrices()
        {

            int total = 0;
            int[,] arr3 = new int[21, 21];
            int[,] arr6 = new int[21, 21];
            int[,] arr7 = new int[21, 21];

            int i, j, n;
            n = 21;


            //while (total != 28)
            //{

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    arr3[i, j] = aircraftcarrier.newBoard[i, j] + battleship.newBoard[i, j];
                }
            }

            //for (j = 0; j < n; j++)

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
            Console.WriteLine(arr7);

            for (i = 0; i < n; i++) 
            {
                for (j = 0; j < n; j++) 
                {
                    total += arr7[i,j];
                }
            }
            //List<int> flatArray = FlattenArray(arr7);
            //total = flatArray.Sum();
            //}
            return total;
        }


        //List<int> FlattenArray(int[,] arr)
        //{
        //    List<int> list = new List<int>(21 * 21);

        //    for (int e = 0; e < 21; e++)
        //    {
        //        for (int f = 0; f < 21; f++)
        //            list.Add(arr[e, f]);
        //    }
        //    return list;
        //}


    }
}