using System;
using ConsoleUI.Drawing;

namespace ConsoleUI.Elements
{
    public class Panel : Base
    {
        public Panel()
        {
        }

        public Panel(int x, int y, int w, int h, Base parent=null)
        {
            if (parent != null) { SetParent(parent); }
            Paint += PaintPanel;
            SetPos(x, y);
            SetSize(w, h);
            SetBackgroundColor(ConsoleColor.Gray);
            Selectable = false; // Panels cant be selected
        }

        public override void PaintPanel(object obj, PaintEventArgs e)
        {
            Draw.SetBackground(ConsoleColor.Gray);
                Draw.Rect(X,Y, W,H);
            Draw.ResetColours();
        }
    }
}