using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleTUI.Elements;

namespace ConsoleTUI.Manager
{
    static class Handler
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

        public static void Draw()
        {
            Drawing.Draw.ResetConsole();
            foreach (Base pnl in Panels)
            {
                pnl.PrePaint(pnl.LatestPaintEventArgs);
            }
        }
       
    }
}
