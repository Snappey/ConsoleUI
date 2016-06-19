using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleTUI.Elements;

namespace ConsoleTUI
{
    public class TextEntry : Label
    {
        public TextEntry(int x, int y, string text, Base Parent = null) : base(x, y, text, Parent)
        {
        }
    }
}