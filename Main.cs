using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ConsoleTUI.Elements;

namespace ConsoleTUI
{
    class MainEntry
    {
        static void Main(string[] args)
        {

            Console.WriteLine(Console.BufferWidth);
            layoutManager.startKeyboardInput();

            Panel canvas = new Panel(Console.BufferWidth - 10, 21, 5, 2);

            Label moreText = new Label(20, 20, 20, 20, canvas);

            TextInput input = new TextInput(20,2,10,10, canvas,1,1);

            TextInput moreInput = new TextInput(20, 2, 10, 15, canvas, 1, 2);

            Util.resetCursor();
            Util.setConsoleOutput(false);
        }
    }

}
