using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleTUI.Drawing;

namespace ConsoleTUI.Elements
{
    public class Panel : Base
    {
        public Panel(int x, int y, int w, int h)
        {
            Paint += PaintPanel;
            SetPos(x, y);
            SetSize(w, h);
        }

        public override void PaintPanel(object obj, PaintEventArgs e)
        {
            Draw.SetBackground(ConsoleColor.Gray);
                Draw.Rect(X,Y, W,H);
            Draw.ResetColours();
        }
    }
}