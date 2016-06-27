using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ConsoleUI.Elements;

namespace ConsoleUI.Manager
{
    public static class Keys
    {
        
        private static Thread _Thread;

        public static event EventHandler<KeyEventArgs> ConsoleKeyPressed;
        public static ConsoleKeyInfo LastKeyInfo;

        public static void CreateKeys()
        {
            while (true)
            {
                LastKeyInfo = Console.ReadKey(true);
                ConsoleKeyPressed?.Invoke(null, new KeyEventArgs(LastKeyInfo));
                // CPU usage spikes from 1 to highs of 10 when a user is typing relatively quickly
            }
        }


        public static Thread StartKeys()
        {
            _Thread = new Thread(CreateKeys);
            _Thread.Start();
            ConsoleKeyPressed += SelectionHandle; 
            return _Thread;
        }

        private static void SelectionHandle(object Obj, KeyEventArgs keyinfo)
        {
            if (keyinfo.Key.Key == ConsoleKey.Tab)
            {
                Base prevpnl = Handler.GetSelectedPanel();
                Base pnl = Handler.GetNextSelectablePanel(prevpnl);
                pnl.GiveFocus();
                Handler.DrawElement(pnl);
                Handler.DrawElement(prevpnl);
            }
            else if (keyinfo.Key.Key == ConsoleKey.Enter)
            {
                Button pnl = (Button)Handler.GetSelectedPanel(); // Eeeeeeh might be sketchy, but anything which is selectable currently is related to Button
                pnl.DoClick();
                Handler.DrawElement(pnl);
            }
        }

        public static ConsoleKeyInfo GetPressedKey()
        {
            return LastKeyInfo;
        }

        public class KeyEventArgs : EventArgs
        {
            public ConsoleKeyInfo Key;
            public KeyEventArgs(ConsoleKeyInfo key) { Key = key; }
        }
    }
}
