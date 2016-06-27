using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleUI.Elements;

namespace ConsoleUI.Elements
{
    public class TextEntry : Button
    {
        public TextEntry(int x, int y, int w, Base Parent = null) : base(x, y, w,3, Parent)
        {
        }
    }
}