using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
                LastKeyInfo = Console.ReadKey();
                ConsoleKeyPressed?.Invoke(null, new KeyEventArgs(LastKeyInfo));                 
                // CPU usage spikes from 1 to highs of 10 when a user is typing relativly quickly
            }
        }


        public static Thread StartKeys()
        {
            _Thread = new Thread(CreateKeys);
            _Thread.Start();
            return _Thread;
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
