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
            Label moreText = new Label(20, 20, 20, 20, canvas);

            Panel basePanel = new Panel(25, 16, 10, 4, canvas);

            Label extraText = new Label(15, 15, 15, 15, basePanel);

            extraText.setText("OLO");

            text.setText("LOL");

            Console.ReadKey();

                canvas.setColour(ConsoleColor.DarkBlue);

                Console.ReadKey();

                moreText.setPosition(35, 5);
                extraText.setPosition(35, 15);
                text.setPosition(35, 25);

            Console.ReadKey();
        }
    }

}
