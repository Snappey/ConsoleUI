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
           
            Panel pnl = new Panel(5,5,90,15);
    
            Label lbl = new Label(2,2,"Testing", pnl);


            Console.ReadKey();
        }
    }

}
