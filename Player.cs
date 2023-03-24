
using System.Linq;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;

namespace CSharpBattleShip
{
    public class Player
    {
        public Ship aircraftCarrier;
        public Ship battleship;
        public Ship submarine;
        public Ship destroyer; 


        public Player()
        {
            aircraftCarrier = new Ship("Aircraft Carrier", 5, 5);
            battleship = new Ship("Battleship", 4, 4);
            submarine = new Ship("Submarine", 3, 3);
            destroyer = new Ship("Destroyer", 2, 2);
        }

        public void CreateMatrices()
        {
            aircraftCarrier.PlaceShips();
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


            //while (total != 16)
            //{

            for (i = 0; i < n; i++)
                //for (j = 0; j < n; j++)
                for (j = 0; j < n; j++)
                    arr3[i, j] = this.aircraftCarrier.newBoard[i, j] + this.battleship.newBoard[i, j];

            for (i = 0; i < n; i++)
                for (j = 0; j < n; j++)
                    arr6[i, j] = this.submarine.newBoard[i, j] + this.destroyer.newBoard[i, j];

            for (i = 0; i < n; i++)
                for (j = 0; j < n; j++)
                    arr7[i, j] = arr3[i, j] + arr6[i, j];

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