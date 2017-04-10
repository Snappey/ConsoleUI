using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleUI.Drawing;
using ConsoleUI.Elements;
using ConsoleUI.Interfaces;
using ConsoleUI.Manager;

namespace ConsoleUI.Elements
{
    public class TextEntry : Base, ISelectable, ITypable
    {
        public event EventHandler OnClick;
        public event EventHandler OnSelected;
        public event EventHandler OnSelectedChanged;
        public event EventHandler KeyPressed;

        public string Contents = "";

        public TextEntry(int x, int y, int w, Base Parent = null)
        {
            Panel padding = new Panel(x, y, w, 3, Parent);
            padding.SetBackgroundColor(ConsoleColor.DarkGray);

            SetParent(padding);

            Paint += PaintPanel;
            SetPos(1,1);
            SetSize(w - 2, 1);
            SetBackgroundColor(ConsoleColor.DarkBlue);
        }

        public void DoClick()
        {
            OnClick?.Invoke(this, EventArgs.Empty);
        }

        public void DoSelected()
        {
            Console.SetCursorPosition(X,Y);
            //Console.CursorVisible = true;
            //Keys.SetShouldIntercept(false);
            OnSelected?.Invoke(this, EventArgs.Empty);
        }

        public void DoSelectedChanged()
        {
            Console.SetCursorPosition(0,0);
            //Console.CursorVisible = false;
            //Keys.SetShouldIntercept(true);
            OnSelectedChanged?.Invoke(this, EventArgs.Empty);
        }

        public override void PaintPanel(object obj, PaintEventArgs e)
        {
            Draw.Rect(X, Y, W, H, GetBackgroundColor());
            Draw.Text(X, Y, Contents, ConsoleColor.White, GetBackgroundColor()); // TODO: Change ConsoleColor.White too a configurable option
            Draw.ResetColours();
        }

        public void KeyPress(Keys.KeyEventArgs key) // TODO: Implement caret positioning
        {
            if (key.Key.Key == ConsoleKey.Backspace && Contents.Length >= 1)
            {

                SetContents(Contents.Substring(0, Contents.Length - 1));
            }
            else
            {
                SetContents(Contents + key.Key.KeyChar); // TODO: Refactor variable naming, its getting pretty interesting..
            }                                            // TODO: Implement String stencils to only show the contents inside the rectangle drawn
            KeyPressed?.Invoke(this, new Keys.KeyEventArgs(key.Key));
            PaintPanel(this, new PaintEventArgs());
        }

        public string GetContents()
        {
            return Contents;
        }

        public void SetContents(string str)
        {
            Contents = str;
        }
    }
}