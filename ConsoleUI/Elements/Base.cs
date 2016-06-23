using System;
using ConsoleUI.Manager;

namespace ConsoleUI.Elements
{
    public abstract class Base
    {
        public event EventHandler<PaintEventArgs> Paint;
        public event EventHandler<PaintEventArgs> PaintOverride;
        public event EventHandler Init;

        public int X;
        public int Y;
        public bool Selectable;
        public bool Selected;
        public int W;
        public int H;
        public bool PaintManual;
        public PaintEventArgs LatestPaintEventArgs;
        public Base Parent;
        public ConsoleColor TextColor;
        public ConsoleColor BkgColor;

        protected Base()
        {
            Handler.Add(this);
            Init?.Invoke(this, EventArgs.Empty);
        }

        public Base GetParent()
        {
            return Parent;
        }

        public void SetParent(Base pnl)
        {
            Parent = pnl;
        }

        public int[,] GetPos()
        {
            return new int[X,Y];
        }

        public int GetX()
        {
            return X;
        }

        public int GetY()
        {
            return Y;
        }

        public bool IsSelected()
        {
            if (Selected)
            {
                return true;
            }
            return false;
        }

        public bool IsSelectable()
        {
            if (Selectable)
            {
                return true;
            }
            return false;
        }

        public int GetWidth()
        {
            return W;
        }

        public int GetHeight()
        {
            return H;
        }

        public int[,] GetSize()
        {
            return new int[W,H];
        }

        public void SetPos(int x, int y)
        {
            if (GetParent() != null) { x = GetParent().X + x; y = GetParent().Y + y; }
            PaintEventArgs eventArgs = new PaintEventArgs();
            if (x >= 0)
            {
                X = x;
                eventArgs.XPositionModified = true;
            }
            if (y >= 0)
            {
                Y = y;
                eventArgs.YPositionModified = true;
            }
            LatestPaintEventArgs = eventArgs;
            Handler.Draw();
        }

        public void SetSize(int w, int h)
        {
            PaintEventArgs eventArgs = new PaintEventArgs();
            if (w >= 0)
            {
                W = w;
                eventArgs.WidthModified = true;
            }
            if (h >= 0)
            {
                H = h;
                eventArgs.HeightModified = true;
            }
            LatestPaintEventArgs = eventArgs;
            Handler.Draw();
        }

        public ConsoleColor GetTextColor()
        {
            return TextColor;
        }

        public void SetTextColor(ConsoleColor col)
        {
            TextColor = col;
        }

        public ConsoleColor GetBackgroundColor()
        {
            return BkgColor;
        }

        public void SetBackgroundColor(ConsoleColor col)
        {
            BkgColor = col;
        }

        public void SetPaintManual(bool paint)
        {
            if (paint)
            {
                PaintManual = true;
                Handler.Draw();
                return;
            }
            PaintManual = false;
            Handler.Draw();
        }
        public virtual void OverridePaintPanel() { }
        public abstract void PaintPanel(object obj, PaintEventArgs e);

        public void PrePaint(PaintEventArgs e)
        {
            if (PaintManual)
            {
                PaintOverride?.Invoke(this, e);
            }
            else
            {
                Paint?.Invoke(this, e);
            }  
        }
    }

    public class PaintEventArgs : EventArgs
    {

        public bool HeightModified;
        public bool WidthModified;
        public bool XPositionModified;
        public bool YPositionModified;

        public PaintEventArgs()
        {
            HeightModified = false;
            WidthModified = false;
            XPositionModified = false;
            YPositionModified = false;
        }
    }
}