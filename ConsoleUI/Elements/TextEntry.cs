using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleUI.Elements;

namespace ConsoleUI.Elements
{
    public class TextEntry : Label
    {
        public TextEntry(int x, int y, string text, Base Parent = null) : base(x, y, text, Parent)
        {
        }
    }
}