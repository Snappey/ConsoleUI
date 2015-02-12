using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleTUI;

namespace ConsoleTUI.Elements
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
            isSelectable = false;
            if (parent == null) { z = layer; } else { z = layer + parent.z;  };


            Init();
        }

        public override void Paint()    
        {
            isDrawn = Util.drawRectangle(x, y, w, h, colour);
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
