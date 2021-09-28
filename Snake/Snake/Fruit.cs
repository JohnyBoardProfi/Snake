using System;

namespace Snake
{
    class Fruit
    {
        int X { set; get; }

        int Y { set; get; }

        int Score { set; get; }

        Random rnd = new Random();
        Printer p = new Printer();

        public void Restart()
        {
            X = Game.Width / 2;
            Y = Game.Height / 2 - 5;
            Score = 0;
        }

        void Rand(int width, int height, Snake snake)
        {
            X = rnd.Next(1, width);
            Y = rnd.Next(1, height);
            for (int i = snake.Length; i >= 1; i--)
            {
                if (snake.X[i - 1] == X && snake.Y[i - 1] == Y)
                {
                    Rand(width, height, snake);
                }
            }
        }

        void Print()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            p.Print(X, Y, "■");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Rules(ref Snake snake)
        {
            Print();
            snake.Length += Convert.ToInt32(snake.X[0] == X && snake.Y[0] == Y);
            Score += Convert.ToInt32(snake.X[0] == X && snake.Y[0] == Y) * 100;
            if (snake.X[0] == X && snake.Y[0] == Y)
            {
                p.Print(Game.Width / 2 - 4, Game.Height + 2, $"Счёт: {Score}$");
                Rand(Game.Width, Game.Height, snake);
            }
        }
    }
}