using System;
using System.Threading;

namespace Snake
{
    class Game
    {
        Printer p = new Printer();

        public static int Width { get; } = 26;

        public static int Height { get; } = 26;

        ConsoleKeyInfo keyInfo;
        ConsoleKey consoleKey;
        Snake snake;
        Fruit fruit;
        bool IsLost;


        public Game()
        {
            Console.CursorVisible = false;
            Console.Title = "Snake";
            snake = new Snake();
            fruit = new Fruit();
        }

        void Restart()
        {
            Board.Print(Width, Height);
            Menu();
            Console.Clear();
            keyInfo = new ConsoleKeyInfo();
            consoleKey = new ConsoleKey();
            IsLost = false;
            snake.Restart();
            fruit.Restart();
            Board.Print(Width, Height);
        }

        void Control()
        {
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                consoleKey = keyInfo.Key;
            }
            switch (consoleKey)
            {
                case ConsoleKey.W:
                    if ((snake.Y[0] - snake.Y[1]) == 1)
                    {
                        goto case ConsoleKey.S;
                    }
                    else
                    {
                        snake.Shift(Snake.Direction.Top);
                    }
                    break;
                case ConsoleKey.S:
                    if ((snake.Y[0] - snake.Y[1]) == -1)
                    {
                        goto case ConsoleKey.W;
                    }
                    else
                    {
                        snake.Shift(Snake.Direction.Bottom);
                    }
                    break;
                case ConsoleKey.A:
                    if ((snake.X[0] - snake.X[1]) == 1)
                    {
                        goto case ConsoleKey.D;
                    }
                    else
                    {
                        snake.Shift(Snake.Direction.Left);
                    }
                    break;
                case ConsoleKey.D:
                    if ((snake.X[0] - snake.X[1]) == -1)
                    {
                        goto case ConsoleKey.A;
                    }
                    else
                    {
                        snake.Shift(Snake.Direction.Right);
                    }
                    break;
                default:
                    if ((snake.Y[0] - snake.Y[1]) == 1)
                    {
                        goto case ConsoleKey.S;
                    }
                    if ((snake.Y[0] - snake.Y[1]) == -1)
                    {
                        goto case ConsoleKey.W;
                    }
                    if ((snake.X[0] - snake.X[1]) == 1)
                    {
                        goto case ConsoleKey.D;
                    }
                    if ((snake.X[0] - snake.X[1]) == -1)
                    {
                        goto case ConsoleKey.A;
                    }
                    break;
            }
        }

        void Rules()
        {
            Control();
            fruit.Rules(ref snake);
            snake.Rules(ref IsLost); 
        }

        void Menu()
        {
            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
            ConsoleKey consoleKey = new ConsoleKey();
            p.Print(Width / 2 - 5, 1, "Змейка");
            p.Print(Width / 2 - 11, 2, "Нажмите Enter для старта");
            p.Print(Width / 2 - 11, 3, "Нажмите Esc чтобы выйти");
            chooseButton:
            keyInfo = Console.ReadKey(true);
            consoleKey = keyInfo.Key;
            switch (consoleKey)
            {
                case ConsoleKey.Enter:
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
                default:
                    goto chooseButton;
            }
        }

        public void Play()
        {
            while (true)
            {
                Restart();
                while (!IsLost)
                {
                    Rules();
                    Thread.Sleep(100);
                }
                p.Print(Height / 2 - 4, Width / 2, "You lost!");
            }
        }
    }
}
