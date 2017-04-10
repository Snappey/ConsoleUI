using System;
using ConsoleUI.Drawing;

namespace ConsoleUI.Elements
{
    public class Footer : Panel
    {
        public Footer() : base(0, Console.WindowHeight - 1, Console.WindowWidth - 1, 1)
        {
           SetBackgroundColor(ConsoleColor.DarkGray);
        }
    }
}
