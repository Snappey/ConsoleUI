using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleUI.Drawing;

namespace ConsoleUI.Elements
{
    public class Button : Base, ISelectable
    {
        public event EventHandler OnClick;
        public event EventHandler OnSelected;
        public event EventHandler OnSelectedChanged;

        public Button(int x, int y, int w, int h, Base Parent=null)
        {
            if (Parent != null) { SetParent(Parent); }
            Paint += PaintPanel;
            SetPos(x, y);
            SetSize(w, h);
            SetBackgroundColor(ConsoleColor.Cyan);
        }

        public void DoClick()
        {
            Console.Beep();
            OnClick?.Invoke(this, EventArgs.Empty);
        }

        public void DoSelected()
        {
            OnSelected?.Invoke(this, EventArgs.Empty);
        }

        public void DoSelectedChanged()
        {
            OnSelectedChanged?.Invoke(this, EventArgs.Empty);
        }

        public override void PaintPanel(object obj, PaintEventArgs e)
        {
            if(GetFocus())
            {
                SetBackgroundColor(ConsoleColor.DarkBlue);
            }
            else
            {
                SetBackgroundColor(ConsoleColor.Cyan);
            }            
            Draw.Rect(X, Y, W, H, GetBackgroundColor());
            Draw.ResetColours();
            
        }
    }
}