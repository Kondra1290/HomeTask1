namespace Task_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] field = CreateField(12, 12); //метод отвечает за создание поля
            Move(field);   //метод отвечает за наше передвижение
            Console.WriteLine("The end of program");
        }

        static char[,] CreateField(int rows, int columns)
        {
            char[,] field = new char[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (i == 0 || i == rows - 1 || j == 0 || j == columns - 1) field[i, j] = '*';
                    else field[i, j] = ' ';
                }
            }
            return field;
        }

        static void Move(char[,] field)
        {
            int rows = field.GetUpperBound(0) + 1;
            int cols = field.Length / rows;

            ConsoleKeyInfo keypressed;
            char key;
            bool flag = true;
            int x = 1, y = 1; // начальная позиция
            int dx = 0, dy = 0; // начальная позиция
            Display(field, x, y); // метод отвечает за вывод поля и наших координат

            while (flag)// пока flag = true мы ходим
            {
                dx = 0;
                dy = 0;
                keypressed = Console.ReadKey(intercept: false);
                key = keypressed.KeyChar.ToString().ToLower()[0];
                switch (key)
                {
                    case 'w': // движение вверх
                        if (y != 1)
                        {
                            dy = -1;
                            dx = 0;
                        }
                        break;
                    case 'a': // движение влево
                        if (x != 1)
                        {
                            dy = 0;
                            dx = -1;
                        }
                        break;
                    case 's': // движение вниз
                        if (y != rows - 2)
                        {
                            dy = 1;
                            dx = 0;
                        }
                        break;
                    case 'd': // движение вправо
                        if (x != cols - 2)
                        {
                            dy = 0;
                            dx = 1;
                        }
                        break;
                    case 'e': // конец 
                        flag = false;
                        break;
                    default:
                        break;
                }
                field[y, x] = ' ';
                x += dx;
                y += dy;

                Display(field, x, y);
            }
        }

        static void Display(char[,] field, int x, int y)
        {
            field[y, x] = 'H';
            int rows = field.GetUpperBound(0) + 1, cols = field.Length / rows;
            Console.Clear();
            Console.WriteLine($"Your position is: x = {x + 1} y= {10 - y}");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                    Console.Write(field[i, j] + " ");
                Console.WriteLine();
            }

        }
    }
}