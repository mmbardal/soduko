using System;
using System.Drawing;





namespace _5
{
     public class table
    {







        private int[,] main_1 = new int[9, 9];
        private int[,] main_2 = new int[9, 9];
        private int[,] main_3 = new int[9, 9];



        public table(int[,] main_x, int[,] main_y, int[,] main_z)
        {
            main_1 = main_x;
            main_2 = main_y;
            main_3 = main_z;

        }


        // solve by system
        public  bool solve()
        {
            // row count
            for (int row = 0; row < main_1.GetLength(0); row++)
            {
                //column count
                for (int cloumn = 0; cloumn < main_1.GetLength(1); cloumn++)
                {
                    // checking that is this cell is empty or fill 
                    if (main_1[row, cloumn] == 0)
                    {
                        // counting from min nunmber to max number
                        for (int k = 1; k <= 9; k++)
                        {
                            main_1[row, cloumn] = k;
                            // checking
                            if ((check(main_1, row, cloumn)) && (solve()))
                            {
                                return true;
                            }
                            main_1[row, cloumn] = 0;
                        }
                        // if the above condition isn't true return false
                        return false;
                    }
                }
            }

            return true;
        }
        // check row and column
        public bool check(int[,] board, int row, int column)
        {
            return (check_row(board, row) && check_column(board, column) && check_square(board, row, column));
        }
        public  bool check_row(int[,] board, int row)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = i + 1; j < 9; j++)
                {
                    if (main_1[row, i] != 0)
                    {
                        if (main_1[row, i] == main_1[row, j])
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
        public bool check_column(int[,] board, int column)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = i + 1; j < 9; j++)
                {
                    if (main_1[i, column] != 0)
                    {
                        if (main_1[i, column] == main_1[j, column])
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        public bool check_square(int[,] board, int row, int column)
        {
            int rowStart = (row / 3) * 3;
            int rowEnd = ((row / 3) * 3) + 3;
            int colStart = (column / 3) * 3;
            int colEnd = ((column / 3) * 3) + 3;

            for (int i = rowStart; i < rowEnd; i++)
            {
                for (int j = colStart; j < colEnd; j++)
                {
                    if ((i != row) && (j != column))
                    {
                        if (main_1[row, column] == main_1[i, j])
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }









        // solve by user 
        public void Add_number(int row1, int column1, int num1, ref int counter)
        {
            if (main_2[row1, column1] == 0)
            {
                if (num1 == main_1[row1, column1])
                {
                    main_2[row1, column1] = num1;
                    Console.WriteLine("\nThat is true go to next step");
                    counter++;
                }
                else
                {
                    Console.WriteLine("\nwrong answer try again");
                }
            }
            else
            {
                Console.WriteLine("\nthis cell is fill try another cell");
            }

        }
        public void Delete(int row1, int column1, ref int counter)
        {
            if (main_3[row1, column1] == 0)
            {
                main_2[row1, column1] = 0;
                Console.WriteLine("\ndeleting is successful! go to next step ");
                counter--;
            }
            else
            {
                Console.WriteLine("\nyou can't do this \n try another cell. ");
            }
        }
        public void Hint(ref int counter)
        {
            Random rand = new Random();
            int a = 0;
            while (true)
            {


                int row = rand.Next(0, 8);
                int column = rand.Next(0, 8);
                if (main_2[row, column] == 0)
                {
                    main_2[row, column] = main_1[row, column];


                    a++;
                    counter++;


                }
                if (a == 3)
                {
                    break;
                }



            }

        }
        private void color(int a)
        {
            if (a == 1)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Clear();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
            }

        }
        public void show_table()
        {

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("|");
                    if (main_3[i, j] != 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(main_2[i, j]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(main_2[i, j]);
                    }

                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("|\n");
            }

            bool a = true;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (main_2[i, j] == 0)
                    { a = false; }
                }
            }
            if (a == true)
            {
                Console.WriteLine("you win please exit");
            }
            else
            {
                Console.WriteLine("the game is still going on");
            }


        }


    }


    class Program
    {
        static void solve(ref int[,] tab)
        {

        }

        static void Main(string[] args)
        {
            int[,] main_1 = { {0,8,4,0,0,0,0,1,3},
                {2,0,0,0,3,0,6,0,0},{6,0,0,5,0,9,0,0,2},
                {0,0,2,0,0,0,4,6,9},{7,0,0,0,0,0,0,0,0},
                {0,0,0,2,8,0,0,0,0},{0,2,0,7,0,0,0,0,0},
                {0,0,8,0,0,5,9,0,6},{5,0,0,0,2,0,3,0,7}};
            int count_2 = 0;
            for (int i = 0; i < main_1.GetLength(0); i++)
            {
                for (int j = 0; j < main_1.GetLength(1); j++)
                {
                    if (main_1[i, j] == 0)
                    {
                        count_2++;
                    }
                }
            }

            int[,] main_2 = new int[main_1.GetLength(0), main_1.GetLength(1)];
            int[,] main_3 = new int[main_1.GetLength(0), main_1.GetLength(1)];
            // deep copy
            for (int i = 0; i < main_1.GetLength(0); i++)
            {
                for (int j = 0; j < main_1.GetLength(1); j++)
                {
                    main_2[i, j] = main_1[i, j];
                }
            }
            for (int i = 0; i < main_1.GetLength(0); i++)
            {
                for (int j = 0; j < main_1.GetLength(1); j++)
                {
                    main_3[i, j] = main_1[i, j];
                }
            }




            table Tab = new table(main_1, main_2, main_3);
            Tab.solve();
            Tab.show_table();
            int a = 0;// hint counter
            int b = 3;// hint remainer
            int counter = 0;
            while (true)
            {

                string read = Console.ReadLine();
                if (read == "Add number")
                {
                    var line = Console.ReadLine();
                    var data = line.Split(' ');
                    int row = int.Parse(data[0]) - 1; //first integer
                    int coulmn = int.Parse(data[1]) - 1; //second integer
                    int number = int.Parse(data[2]); //third integer
                    Tab.Add_number(row, coulmn, number, ref counter);

                }
                if (read == "Delete")
                {
                    var line = Console.ReadLine();
                    var data = line.Split(' ');
                    int row = int.Parse(data[0]) - 1; //first integer
                    int coulmn = int.Parse(data[1]) - 1; //second integer
                    Tab.Delete(row, coulmn, ref counter);
                }
                if (read == "Hint")
                {
                    a++;
                    b--;
                    if (a <= 3)
                    {
                        Tab.Hint(ref counter);
                        Tab.show_table();
                        Console.WriteLine("you have been  hinted your ramaing hinting is :" + b);
                    }
                    else
                    {
                        Console.WriteLine("you used all your hinting");
                    }

                }
                if (read == "Show Table")
                {
                    Tab.show_table();
                }
                if (read == "Exit")
                {
                    //show table and exit
                    Console.WriteLine("the number of solved cells is :" + counter);
                    int v = count_2 - counter;
                    Console.WriteLine("{0} cells is still remaining", v);

                    break;
                }


            }


            while(true)
            {

            }
        }
    }

}