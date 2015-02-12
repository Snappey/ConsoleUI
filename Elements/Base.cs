using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTUI.Elements
{
    /// <summary>
    /// Base Class, all elements derive from this
    /// </summary>
   public abstract class Base
    {

        public int w;
        public int h;
        public int x;
        public int y;
        public int z;
        public Base Parent;
        public bool isDrawn;
        public ConsoleColor colour = ConsoleColor.Gray;
        public bool isSelectable;
        public int tabIndex = 0; // Not relevant if isSelectable is false

        public abstract void Paint();
        public abstract void Init();
        public abstract void Refresh();

        public virtual void setPosition(int posX, int posY)
        {
            x = posX;
            y = posY;
            Refresh();
        }
       public virtual void setSize(int width, int height)
       {
           w = width;
           h = height;
           Refresh();
       }
        public virtual void setColour(ConsoleColor col)
       {
           colour = col;
           Refresh();
       }


    }
}
