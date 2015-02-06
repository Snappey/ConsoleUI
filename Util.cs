using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTUI
{
    class Util
    {
        public static bool drawRectangle(int x, int y, int w, int h, ConsoleColor colour)
        {
            Console.BackgroundColor = colour;
            Console.SetCursorPosition(x, y);
            for (int i = 1; i < h; i++)
            {
                for (int k = 1; k < w; k++)
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(x, y + i); // Reset Cursor Pos at the end of each row, Sets cursor pos one down at the same x.
            }
            return true;
        }

        public static bool clearScreen()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.Clear();
            return true;
        }

    }
}
