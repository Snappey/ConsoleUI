using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleUI.Interfaces;
using ConsoleUI.Manager;

namespace ConsoleUI.Elements
{
    public abstract class Base
    {
        public event EventHandler<PaintEventArgs> Paint;
        public event EventHandler<PaintEventArgs> PaintOverride;
        public event EventHandler Init;

        public bool Selectable = false; // Used to handle casts for key inputs
        public bool Typable = false;

        public int X;
        public int Y;
        public int W;
        public int H;

        public bool PaintManual;
        public PaintEventArgs LatestPaintEventArgs;
        public Base Parent;
        public ConsoleColor BkgColor = ConsoleColor.Black;
        public Dictionary<Base, Base> Children = new Dictionary<Base, Base>(); // Bit of a lazy way to solve this problem, Ill come back to it

        public bool HasFocus;

        protected Base()
        {
            Handler.Add(this);
            Init?.Invoke(this, EventArgs.Empty);

            if (this is ISelectable)
            {
                SetSelectable(true);
            }
            if (this is ITypable)
            {
                SetTypable(true);
            }
        }

        public Base GetParent()
        {
            return Parent;
        }

        public void SetParent(Base pnl)
        {
            Parent = pnl;
            pnl.AddChild(this);
        }

        public void RemoveParent()
        {
            Parent = null;
        }

        public Dictionary<Base, Base> GetChildren()
        {
            return Children;
        }

        public void AddChild(Base pnl)
        {
            Children.Add(pnl, pnl);
        }

        public void RemoveChild(Base pnl)
        {
            Children.Remove(pnl); // So I dont have to work out the index of the given panel
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
            return HasFocus;
        }

        public bool GetFocus()
        {
            if (HasFocus)
            {
                return true;
            }
            return false;
        }

        public void SetFocus(bool focus)
        {
            HasFocus = focus;
        }

        public void GiveFocus()
        {
            if (HasFocus) { return; }
            Base focusedBase = Handler.GetSelectedPanel();

            var selected = focusedBase as ISelectable;
            selected.DoSelectedChanged();

            focusedBase.SetFocus(false);
            SetFocus(true);
        }

        public bool IsSelectable()
        {
            if (Selectable)
            {
                return true;
            }
            return false;
        }

        public void SetSelectable(bool select)
        {
            Selectable = select;

            if (Selectable)
            {             
                Handler.SelectablePanels.Add(this);
            }
            else
            {
                Handler.SelectablePanels.Remove(this);
            }
        }

        private void SetTypable(bool typable)
        {
            Typable = typable;
        }

        public bool IsTypable()
        {
            return Typable;
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

        public ConsoleColor GetBackgroundColor()
        {
            return BkgColor;
        }

        public void SetBackgroundColor(ConsoleColor col)
        {
            BkgColor = col;
        }

        public void Remove()
        {
            Handler.Remove(this);
        }

        public void SetPaintManual(bool paint)
        {
            if (paint)
            {
                PaintManual = true;
                Handler.DrawElement(this);
                return;
            }
            PaintManual = false;
            Handler.DrawElement(this);
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