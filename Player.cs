
using System.Linq;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpBattleShip
{
    public class Player
    {
        Ship aircraftCarrier = new Ship("Aircraft Carrier", 5, 5);
        Ship battleship = new Ship("Battleship", 4, 4);
        Ship submarine = new Ship("Submarine", 3, 3);
        Ship destroyer = new Ship("Destroyer", 2, 2);


        public Player()
        {

        }

        public void CreateMatrices()
        {
            aircraftCarrier.PlaceShips();
            battleship.PlaceShips();
            submarine.PlaceShips();
            destroyer.PlaceShips();

        }

    //    private int[,] CheckMatrices()
    //    {

    //        int total = 0;
    //        int[,] arr3 = new int[21, 21];
    //        int[,] arr6 = new int[21, 21];
    //        int[,] arr7 = new int[21, 21];

    //        int i, j, n;
    //        n = 3;


    //        while (total != 16)
    //        {

    //            for (i = 0; i < n; i++)
    //                for (j = 0; j < n; j++)
    //                    arr3[i, j] = aircraftCarrier.newBoard[i, j] + battleship.newBoard[i, j];

    //            for (i = 0; i < n; i++)
    //                for (j = 0; j < n; j++)
    //                    arr6[i, j] = submarine.newBoard[i, j] + destroyer.newBoard[i, j];

    //            for (i = 0; i < n; i++)
    //                for (j = 0; j < n; j++)
    //                    arr7[i, j] = arr3[i, j] + arr6[i, j];

    //            List<int> flatArray = FlattenArray(arr7);
    //            total = flatArray.Sum();
    //        }
    //    }


    //    List<int> FlattenArray(int[,] arr)
    //    {
    //        List<int> list = new List<int>(21 * 21);

    //        for (int e = 0; e < 21; e++)
    //        {
    //            for (int f = 0; f < 21; f++)
    //                list.Add(arr[e, f]);
    //        }
    //        return list;
    //    }

}
    }