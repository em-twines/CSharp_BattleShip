namespace CSharpBattleShip
{
    public class Ship
    {
        private string name = "";
        private int size = 0;
        private int health = 0;
        // private int[] location = new int[] { };
        public int[,] newBoard = new int[21,21];

        public Ship(string name, int size, int health)
        {

        }

        private void PlaceShipsX()
        {
            Random rnd = new Random();
            int starting_position_x = rnd.Next(1, (21 - this.size + 1));
            int starting_position_y = rnd.Next(1, 21);


            int x_span_until = starting_position_x + this.size;


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
        private void PlaceShipsY()
        {
            Random rnd = new Random();
            int starting_position_y = rnd.Next(1, (21 - this.size + 1));
            int starting_position_x = rnd.Next(1, 21);


            int y_span_until = starting_position_y + this.size;


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

        public void PlaceShips()
        {
            Random rnd = new Random();
            int decidingInt = rnd.Next(0,1);
            if (decidingInt == 0)
            {
                PlaceShipsX();
            }
            else
            {
                PlaceShipsY(); 
            }
            Console.WriteLine(newBoard);
            
        }
    
    }
}