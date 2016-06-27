using System;
using ConsoleUI.Drawing;

namespace ConsoleUI.Elements
{
    public class Panel : Base
    {
        public Panel()
        {
        }

        public Panel(int x, int y, int w, int h, Base Parent = null)
        {
            if (Parent != null) { SetParent(Parent); }
            Paint += PaintPanel;
            SetPos(x, y);
            SetSize(w, h);
            SetBackgroundColor(ConsoleColor.Gray);
        }

        public override void PaintPanel(object obj, PaintEventArgs e)
        {
            Draw.Rect(X,Y, W,H, ConsoleColor.Gray);
            Draw.ResetColours();
        }
    }
}