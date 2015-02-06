using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleTUI
{
    class MainEntry
    {
        static void Main(string[] args)
        {

            Console.WriteLine(Console.BufferWidth);

            Panel canvas = new Panel(Console.BufferWidth - 10, 21, 5, 2);
            Label text = new Label(10,10,10,10,canvas);
            

            Console.ReadKey();
        }
    }

}
