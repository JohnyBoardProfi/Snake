namespace Snake
{
    public class Board
    {
        static public void Print(int Width, int Height)
        {
            Printer p = new Printer();
            for (int i = 1; i <= Width; i++)
            {
                p.Print(i, 0, "─");
                p.Print(i, Height + 1, "─");
            }
            for (int i = 1; i <= Height; i++)
            {
                p.Print(0, i, "│");
                p.Print(Width + 1, i, "│");
            }
            p.Print(0, 0, "┌");
            p.Print(Width + 1, 0, "┐");
            p.Print(0, Height + 1, "└");
            p.Print(Width + 1, Height + 1, "┘");
        }
    }
}