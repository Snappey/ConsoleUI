using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using ConsoleUI;
using ConsoleUI.Drawing;
using ConsoleUI.Elements;

namespace ConsoleTUI
{
    class MainEntry
    {
        static void Main(string[] args)
        {
         
            Init();
            StartThread();

            Panel pnl = new Panel(5,5,90,15);
    
            Label lbl = new Label(2,2,"Testing", pnl);

            Button btn = new Button(2,6,20,5, pnl);

            Footer ftr = new Footer(0);

            for (int i = 0; i < Console.BufferHeight; i++)
            {
                Draw.Text(0, i, i.ToString(), ConsoleColor.White);
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

        public static void StartThread()
        {
            Thread ConsoleEvents = new Thread(Hooks.CreateEvents);
            ConsoleEvents.Start();
        }
    }
}
