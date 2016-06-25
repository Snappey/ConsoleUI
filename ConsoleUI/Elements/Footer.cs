using System;
using ConsoleUI.Drawing;

namespace ConsoleUI.Elements
{
    public class Footer : Panel
    {
        public Footer(int x)
        {
            Paint += PaintPanel;
            SetPos(X, Console.WindowHeight - 1);
            SetSize(Console.WindowWidth - X, 1);
        }

        public override void PaintPanel(object obj, PaintEventArgs e)
        {
            Draw.SetBackground(ConsoleColor.DarkGray);
                Draw.Rect(X, Console.WindowHeight - 1, W, H);
                //Draw.Text(X, Y, GetText(), TextColor);
            Draw.ResetColours();
        }
    }
}
