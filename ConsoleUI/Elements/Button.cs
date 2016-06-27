using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleUI.Drawing;

namespace ConsoleUI.Elements
{
    public class Button : Base
    {
        public event EventHandler OnClick;
        public Button(int x, int y, int w, int h, Base Parent=null)
        {
            if (Parent != null) { SetParent(Parent); }
            Paint += PaintPanel;
            SetPos(x, y);
            SetSize(w, h);
            SetSelectable(true);
            SetBackgroundColor(ConsoleColor.Cyan);
            OnClick += delegate(object sender, EventArgs args) {  };
        }

        public void DoClick()
        {
            OnClick.Invoke(this, EventArgs.Empty);
        }

        public override void PaintPanel(object obj, PaintEventArgs e)
        {
            ConsoleColor col;
            if(HasFocus)
            {
                col = ConsoleColor.DarkBlue;
            }
            else
            {
               col = ConsoleColor.Cyan;
            }            
            Draw.Rect(X, Y, W, H, col);
            Draw.ResetColours();
            
        }
    }
}