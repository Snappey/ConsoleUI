using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ConsoleTUI;
using ConsoleTUI.Drawing;
using ConsoleTUI.Elements;

namespace ConsoleTUI
{
    class MainEntry
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Cyan;
           
            Panel pnl = new Panel(5,5,25,10);
            pnl.PaintOverride += delegate (object sender, PaintEventArgs eventArgs) { Console.WriteLine("Testing"); };
            pnl.SetPaintManual(true);


            Console.ReadKey();
        }
    }

}
