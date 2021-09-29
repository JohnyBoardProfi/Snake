using System;

namespace Snake
{
    public class Printer
    {
        public void Print(int a, int b, string c)
        {
            Console.SetCursorPosition(a, b);
            Console.Write(c);
        }
    }
}