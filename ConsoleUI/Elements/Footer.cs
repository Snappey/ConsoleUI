using System;
using ConsoleUI.Drawing;

namespace ConsoleUI.Elements
{
    public class Footer : Panel
    {
        public Footer()
        {
            Paint += PaintPanel;
            SetPos(0, Console.WindowHeight - 1);
            SetSize(Console.WindowWidth - 1, 1);
            SetBackgroundColor(ConsoleColor.DarkGray);
        }

        public override void PaintPanel(object obj, PaintEventArgs e)
        {
            Draw.Rect(X, Y, W, H, ConsoleColor.DarkGray);
            //Draw.Text(X, Y, GetText(), TextColor);
            Draw.ResetColours();
        }
    }
}
