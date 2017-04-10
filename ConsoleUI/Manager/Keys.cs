using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ConsoleUI.Elements;
using ConsoleUI.Interfaces;

namespace ConsoleUI.Manager
{
    public static class Keys
    {
        
        private static Thread _thread;
        private static bool _shouldIntercept = true;

        public static event EventHandler<KeyEventArgs> ConsoleKeyPressed;
        public static ConsoleKeyInfo LastKeyInfo;

        public static Thread StartKeys()
        {
            _thread = new Thread(CreateKeys);
            _thread.Start();
            ConsoleKeyPressed += SelectionHandle;
            return _thread;
        }

        public static void CreateKeys()
        {
            while (true)
            {
                LastKeyInfo = Console.ReadKey(_shouldIntercept);
                ConsoleKeyPressed?.Invoke(null, new KeyEventArgs(LastKeyInfo));
                Thread.Sleep(1); // CPU usage spikes from 1 to highs of 10 when a user is typing relatively quickly
            }
        }

        private static void SelectionHandle(object obj, KeyEventArgs keyInfo)
        {
            if (keyInfo.Key.Key == ConsoleKey.Tab)
            {
                Base prevpnl = Handler.GetSelectedPanel();
                Base pnl = Handler.GetNextSelectablePanel(prevpnl);
                pnl.GiveFocus();

                var selected = (ISelectable) pnl;
                selected.DoSelected();

                Handler.DrawElement(pnl);
                Handler.DrawElement(prevpnl);
            }
            else if (keyInfo.Key.Key == ConsoleKey.Enter)
            {
                ISelectable pnl =
                    (ISelectable) Handler
                        .GetSelectedPanel(); // Eeeeeeh might be sketchy, but anything which is selectable currently is related to Button
                pnl.DoClick();
                Handler.DrawElement((Base) pnl);
            }
            else
            {
                Base pnl = Handler.GetSelectedPanel();
                if (pnl is ITypable) // TODO: change to only require one cast
                {
                    (pnl as ITypable).KeyPress(keyInfo);
                }
            }
        }

        public static bool GetShouldIntercept()
        {
            return _shouldIntercept;
        }

        public static void SetShouldIntercept(bool intercept)
        {
            _shouldIntercept = intercept;
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
