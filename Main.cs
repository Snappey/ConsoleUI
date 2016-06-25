using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using ConsoleUI.Drawing;
using ConsoleUI.Elements;
using ConsoleUI.Manager;

namespace ConsoleTUI
{
    class MainEntry
    {
        static void Main(string[] args)
        {
            var p = 0;
            Init();
            Hooks.StartEvents();
            Keys.StartKeys();

            Panel pnl = new Panel(5,5,90,15);
    
            Label lbl = new Label(2,2,"Testing", pnl);
            lbl.SetTextColor(ConsoleColor.Black);

            Keys.ConsoleKeyPressed += delegate(object sender, Keys.KeyEventArgs eventArgs) { p++; lbl.SetText(p.ToString()); };

            Button btn = new Button(2,6,20,5, pnl);

            for (int i = 0; i < Console.BufferHeight; i++)
            {
                Label dbg = new Label(0, i, i.ToString());
            }

          //  Console.CursorVisible = false;

            Console.ReadKey();
        }

        private static void Init()
        {      
            Console.BufferWidth = 120;
            Console.BufferHeight = 31;
            Console.SetWindowSize(120, 30);
        }
    }
}
