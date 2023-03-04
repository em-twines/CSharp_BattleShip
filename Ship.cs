namespace CSharpBattleShip
{
    public class Ship
    {
        private string name = "";
        private int size = 0;
        private int health = 0;
        private int[] location = new int[] { };
        private int[,] newBoard = new int[,] { };

        public Ship(string name, int size, int health, int[] location)
        {
            this.size = 4;
            this.health = 4;
            this.location = new int[] { };

        }

        private void PlaceShipsX(Ship ship)
        {
            Random rnd = new Random();
            int starting_position_x = rnd.Next(1, (21 - ship.size + 1));
            int starting_position_y = rnd.Next(1, 21);


            int x_span_until = starting_position_x + ship.size;


            for (int y = 0; y < 21; y++)
            {
                for (int x = 0; x < 21; x++)
                {

                    if (starting_position_x < x_span_until)
                    {
                        if (y == starting_position_y & x == starting_position_x)
                        {
                            this.newBoard[y, x] = 2;
                            starting_position_x += 1;
                        }
                    }
                }

            }

            Console.WriteLine(this.newBoard);

        }
        private void PlaceShipsY(Ship ship)
        {
            Random rnd = new Random();
            int starting_position_y = rnd.Next(1, (21 - ship.size + 1));
            int starting_position_x = rnd.Next(1, 21);


            int y_span_until = starting_position_y + ship.size;


            for (int y = 0; y < 21; y++)
            {
                for (int x = 0; x < 21; x++)
                {

                    if (starting_position_y < y_span_until)
                    {
                        if (y == starting_position_y & x == starting_position_x)
                        {
                            this.newBoard[y, x] = 2;
                            starting_position_x += 1;
                        }
                    }
                }

            }

            Console.WriteLine(this.newBoard);

        }

        private void PlaceShips(Ship ship)
        {
            Random rnd = new Random();
            int decidingInt = rnd.Next(0,1);
            if (decidingInt == 0)
            {
                PlaceShipsX(ship);
            }
            else
            {
                PlaceShipsY(ship); 
            }
            Console.WriteLine(newBoard);
            
        }
    
    }
}