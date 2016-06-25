using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleUI.Elements;

namespace ConsoleUI.Manager
{
    public static class Handler
    {
        public static List<Base> Panels = new List<Base>();

        public static bool Add(Base panel)
        {
            try
            {
                Panels.Add(panel);
                
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool Remove(Base panel)
        {
            try
            {
                foreach (KeyValuePair<Base,Base> child in panel.GetChildren())
                {
                    child.Key.Remove();
                }
                Panels.Remove(panel);
                panel = null;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void Draw()
        {
            Drawing.Draw.ResetConsole();
            foreach (Base pnl in Panels)
            {
                pnl.PrePaint(pnl.LatestPaintEventArgs);
            }
        }

        public static void DrawElement(Base pnl)
        {
            pnl.PrePaint(pnl.LatestPaintEventArgs);
            foreach (Base child in pnl.GetChildren().Keys)
            {
                if (child.GetChildren().Count != 0)
                {
                    DrawElement(child); // Dont bother drawing a child if it has more children, since we call for that panels draw initially
                }
                else
                {
                    child.PrePaint(child.LatestPaintEventArgs);
                }
            }
        }
       
    }
}
