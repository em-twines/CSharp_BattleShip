namespace CSharpBattleShip;
class Program
{
    static void Main(string[] args)
    {
        Player player1 = new Player();
        player1.CreateMatrices();
        player1.CheckMatrices(); 
        Player player2 = new Player(); 
        player2.CreateMatrices();
        player2.CheckMatrices(); 

    }
}
