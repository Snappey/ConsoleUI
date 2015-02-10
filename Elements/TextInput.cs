using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTUI.Elements
{
    class TextInput : Base
    {

        ConsoleColor backColour = ConsoleColor.DarkBlue;

        public TextInput(int width, int height, int posX, int posY,Base parent = null,int layer = 1)
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
            Util.drawRectangle(x - 1, y - 1, w + 2, h + 2, ConsoleColor.White);
            Util.drawRectangle(x, y, w, h, backColour);
            
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
