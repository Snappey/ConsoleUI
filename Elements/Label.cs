using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleTUI.Elements;

namespace ConsoleTUI
{
    class Label : Base
    {


        string text = "testing";
        ConsoleColor colour = ConsoleColor.Cyan;
 
        public Label(int width, int height, int posX, int posY,Base parent = null,int layer = 1)
        {
            w = width;
            h = height;
            x = posX;
            y = posY;
            Parent = parent;
            if (parent == null) { z = layer; } else { z = layer + parent.z; };

            Init();
        }

        public override void Paint()
        {
            //if (isDrawn) { Util.clearScreen(); }
            Console.SetCursorPosition(x,y);
            Console.ForegroundColor = colour;
            Console.Write(text);
            isDrawn = true;
        }

        public void setText(string txt)
        {
            text = txt;
            Refresh();
        }

        public override void Init()
        {
            layoutManager.registerElement(this);
            Paint();
        }

        public override void Refresh()
        {
            layoutManager.refreshScreen();
        }
    }
}
