using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTUI
{
    class Util
    {

        public static bool consoleOutput;

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

        public static void resetCursor()
        {
            Console.SetCursorPosition(0,0);
            //Console.CursorVisible = false;
        }

        public static System.IO.StringWriter str; // Used for toggling console output.
        public static System.IO.TextWriter output;
        private static int k = 0;
        public static void setConsoleOutput(bool i)
        {
            if (k == 0) { output = Console.Out; } // Save the original Console output to a var the first time the function is ran
            if (i == false)
            {
                str = new System.IO.StringWriter();
                Console.SetOut(str);
                consoleOutput = false;
            }
            else
            {
                Console.SetOut(output);
                consoleOutput = true;
            }
            k += 1;
        }

    }
}
