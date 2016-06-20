using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleTUI.Drawing;

namespace ConsoleTUI.Elements
{
    public class Panel : Base
    { 
        public Panel(int x, int y, int w, int h, Base Parent=null)
        {
            if (Parent != null) { SetParent(Parent); }
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