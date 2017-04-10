using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleUI.Drawing;
using ConsoleUI.Manager;

namespace ConsoleUI.Elements
{
    public class Label : Base
    {
        protected string _string;
        public ConsoleColor TextColor = ConsoleColor.White;

        public Label(int x, int y, string text, Base Parent=null)
        {
            if (Parent != null) { SetParent(Parent); }
            Paint += PaintPanel;
            SetPos(x,y);
            SetText(text);
        }
        public ConsoleColor GetTextColor()
        {
            return TextColor;
        }

        public void SetTextColor(ConsoleColor col)
        {
            TextColor = col;
        }

        public override void PaintPanel(object obj, PaintEventArgs e)
        {
            if (Parent == null)
            {
                Draw.Text(X, Y, _string, GetTextColor(), GetBackgroundColor());
            }
            else
            {
                Draw.Text(X, Y, _string, GetTextColor(), GetParent().GetBackgroundColor());
            }
            
            Draw.ResetColours();
            
        }

        public string GetText()
        {
            return _string;
        }

        public void SetText(string txt)
        {
            _string = txt; // build test
            Base pnl = GetParent() ?? this;
            Handler.DrawElement(pnl); // Draw the parent, in case the length of the text changes
        }

    }
}