using System;
// ReSharper disable InconsistentNaming

namespace ConsoleTUI.Drawing
{
    static class Draw
    {
        private const ConsoleColor BACKGROUND_COLOUR = ConsoleColor.Black;
        private const ConsoleColor FOREGROUND_COLOUR = ConsoleColor.White;

        private static int[] CursorPos = new int[2];

        public static void Rect(int x, int y, int w, int h)
        {
            SaveCursorPos();
            Console.SetCursorPosition(x,y);
            for (int i = 0; i < h; i++)
            {
                for (int k = 0; k < w; k++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine();
                Console.SetCursorPosition(x, y + i);
            }
            ReturnCursorPos();
        }

        public static void Text(int x, int y, string msg, ConsoleColor TextColor, ConsoleColor BackgroundColor=ConsoleColor.Black)
        {
            SaveCursorPos();
            Console.SetCursorPosition(x,y);
            SetForeground(TextColor);
            SetBackground(BackgroundColor);
            Console.Write(msg);
            ReturnCursorPos();
        }

        public static void SetBackground(ConsoleColor col)
        {
            Console.BackgroundColor = col;
        }

        public static void SetForeground(ConsoleColor col)
        {
            Console.ForegroundColor = col;
        }

        public static void ResetColours()
        {
            Console.ForegroundColor = FOREGROUND_COLOUR;
            Console.BackgroundColor = BACKGROUND_COLOUR;
        }

        public static void ResetConsole()
        {
            Console.Clear();
        }

        public static int GetConsoleWidth()
        {
            return Console.BufferWidth;
        }

        public static int GetConsoleHeight()
        {
            return Console.BufferHeight;
        }

        public static int[] GetConsoleSize()
        {
            return new[] {Console.BufferWidth, Console.BufferHeight};
        }

        private static void SaveCursorPos()
        {
            CursorPos[0] = Console.CursorLeft;
            CursorPos[1] = Console.CursorTop;
        }

        private static void ReturnCursorPos()
        {
            Console.SetCursorPosition(CursorPos[0], CursorPos[1]);
        }
    }
}
