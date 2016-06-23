using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleUI
{
    public class Hooks
    {
        public static EventHandler WindowWidthChanged;
        public static EventHandler WindowHeightChanged;

        public static void CreateEvents()
        {
            WindowWidthChanged += delegate { Manager.Handler.Draw(); };
            WindowHeightChanged += delegate { Manager.Handler.Draw(); };
            int w = Console.WindowWidth;
            int h = Console.WindowHeight;    
            while (true)
            {
                System.Threading.Thread.Sleep(500);
                if (Console.WindowWidth != w) { WindowWidthChanged.Invoke(null, EventArgs.Empty); w = Console.WindowWidth; }
                if (Console.WindowHeight != h) { WindowHeightChanged.Invoke(null, EventArgs.Empty); h = Console.WindowHeight; }
            }
        }
    }
}
