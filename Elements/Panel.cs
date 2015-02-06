using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleTUI.Elements;

namespace ConsoleTUI
{
    public class Panel : Base
    {

        public Panel(int width, int height, int posX, int posY, Base parent = null,int layer = 1)
        {
            w = width;
            h = height;
            x = posX;
            y = posY;
            isDrawn = false;
            Parent = parent;
            if (parent == null) { z = layer; } else { z = layer + parent.z;  };


            Init();
        }

        public override void Paint()    
        {
            if (isDrawn) { Util.clearScreen(); }
            isDrawn = Util.drawRectangle(x, y, w, h, colour);
        }

        public override void Init()
        {
            layoutManager.registerElement(this);
            Paint();
        }

        public override void Refresh()
        {
            Paint();
        }

    }
}
