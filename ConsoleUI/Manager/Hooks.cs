using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleUI.Manager
{
    public class Hooks
    {
        public static EventHandler WindowWidthChanged;
        public static EventHandler WindowHeightChanged;
        public static EventHandler WindowHasScrolled;

        private static Thread _EventsThread;
        private static bool _Events = true;

        private static void CreateEvents()
        {
            WindowWidthChanged += delegate { Handler.Draw(); };
            WindowHeightChanged += delegate { Handler.Draw(); };
            WindowHasScrolled += delegate {  };
            int w = Console.WindowWidth;
            int h = Console.WindowHeight;
            int y = Console.WindowTop;
            while (_Events)
            {
                Thread.Sleep(50);
                if (Console.WindowWidth != w) { WindowWidthChanged.Invoke(null, EventArgs.Empty); w = Console.WindowWidth; }
                if (Console.WindowHeight != h) { WindowHeightChanged.Invoke(null, EventArgs.Empty); h = Console.WindowHeight; }
                if (Console.WindowTop != y) { WindowHasScrolled.Invoke(null, EventArgs.Empty); y = Console.WindowTop; }
            }
        }

        public static Thread StartEvents()
        {
            _EventsThread = new Thread(CreateEvents);
            _EventsThread.Start();
            return _EventsThread;
        }

        public static bool StopEvents()
        {
            if (_EventsThread.IsAlive)
            {            
                try
                {
                    _Events = false;
                    _EventsThread.Join();
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
