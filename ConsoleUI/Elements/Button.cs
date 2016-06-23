using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleUI.Drawing;

namespace ConsoleUI.Elements
{
    public class Button : Panel
    {
        public Button(int x, int y, int w, int h, Base Parent=null) : base(x, y, w, h, Parent)
        {
            Paint += PaintPanel;
        }

        public override void PaintPanel(object obj, PaintEventArgs e)
        {
            Draw.SetBackground(ConsoleColor.Cyan);
            Draw.Rect(X, Y, W, H);
            Draw.ResetColours();
        }
    }
}