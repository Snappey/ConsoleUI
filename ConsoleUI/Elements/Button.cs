using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleUI.Drawing;

namespace ConsoleUI.Elements
{
    public class Button : Base
    {
        private static int i = 0;
        public Button(int x, int y, int w, int h, Base Parent=null)
        {
            if (Parent != null) { SetParent(Parent); }
            Paint += PaintPanel;
            SetPos(x, y);
            SetSize(w, h);
            SetSelectable(true);
        }

        public override void PaintPanel(object obj, PaintEventArgs e)
        {
            i++;
            ConsoleColor col;
            if (HasFocus)
            {
                col = ConsoleColor.DarkBlue;
            }
            else
            {
               col = ConsoleColor.Cyan;
            }            
            Draw.Rect(X, Y, W, H, col);
            Draw.ResetColours();
            
        }
    }
}