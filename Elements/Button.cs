using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleTUI.Drawing;

namespace ConsoleTUI.Elements
{
    public class Button : Panel
    {
        public Button(int x, int y, int w, int h, Base parent=null) : base(x, y, w, h, parent)
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