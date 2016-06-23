﻿using System;
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

        public Label(int x, int y, string text, Base Parent=null)
        {
            if (Parent != null) { SetParent(Parent);}
            Paint += PaintPanel;
            SetPos(x,y);
            SetText(text);
            Selectable = false;
        }

        public override void PaintPanel(object obj, PaintEventArgs e)
        {
            Draw.Text(X, Y, _string, ConsoleColor.Black, GetParent().GetBackgroundColor());
            Draw.ResetColours();
            
        }

        public string GetText()
        {
            return _string;
        }

        public void SetText(string txt)
        {
            _string = txt;
            Handler.Draw();
        }

    }
}