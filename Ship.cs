namespace CSharpBattleShip
{
    public class Ship
    {
        protected string name;
        protected int size;
        protected int health;
        // private int[] location = new int[] { };
        public int[,] newBoard = new int[22,22];

        public Ship(string name)
        {
            this.name = name;
            //this.size = size;
            //this.health = health;
        }

        public int[,] PlaceShipsX()
        {
            Random rnd = new();
            int starting_position_x = rnd.Next(1, 22 - (size));
            int starting_position_y = rnd.Next(1, 22);


            int x_span_until = starting_position_x + size;


            for (int y = 0; y < 22; y++)
            {
                for (int x = 0; x < 22; x++)
                {

                    if (starting_position_x < x_span_until)
                    {
                        if (y == starting_position_y & x == starting_position_x)
                        {
                            //this.newBoard[y, x] = 2;
                            newBoard[y, x] = 2;
                            starting_position_x += 1;
                        }
                    }
                }

            }
            return newBoard;

        }
        public int[,] PlaceShipsY()
        {
            Random rnd = new();
            int starting_position_y = rnd.Next(1, (22 - size));
            int starting_position_x = rnd.Next(1, 22);

            
            int y_span_until = starting_position_y + size;


            for (int y = 0; y < 22; y++)
            {
                for (int x = 0; x < 22; x++)
                {

                    if (starting_position_y < y_span_until)
                    {
                        if (y == starting_position_y & x == starting_position_x)
                        {
                            //this.newBoard[y, x] = 2;
                            newBoard[y, x] = 2;

                            starting_position_y += 1;
                        }
                    }
                }

            }
            return newBoard;


        }

        public void PlaceShips()
        {
            Random rnd = new();
            int decidingInt = rnd.Next(0,2);
            if (decidingInt == 0)
            {
                PlaceShipsX();
            }
            else
            {
                PlaceShipsY(); 
            }
            
        }
    
    }
}