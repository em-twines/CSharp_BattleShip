namespace CSharpBattleShip
{
    public class Gameboard
    {
        Ship aircraftCarrier = new Ship("Aircraft Carrier", 5, 5, new int[]{});
        Ship battleship = new Ship("Battleship", 4, 4, new int[]{});
        Ship submarine = new Ship("Submarine", 3, 3, new int[]{});
        Ship destroyer = new Ship("Destroyer", 2, 2, new int[]{});

    }
}