using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTUI
{
    class layoutManager
    {
        public static List<ConsoleTUI.Elements.Base> panels = new List<ConsoleTUI.Elements.Base>();


        public static void registerElement(ConsoleTUI.Elements.Base element)
        {
            if (element != null)
            {
                panels.Add(element);
            }
           // orderElements();
        }

        public static void refreshScreen()
        {
            drawScreen();
        }

        private static void orderElements()
        {
            List<ConsoleTUI.Elements.Base> temp = new List<ConsoleTUI.Elements.Base>();
            temp = panels;
            foreach(ConsoleTUI.Elements.Base element in panels)
            {

            }
            panels = temp; // Copy across ordered version
        }

        private static void drawScreen()
        {
            foreach(ConsoleTUI.Elements.Base element in panels)
            {
                element.Paint();
            }
            Console.SetCursorPosition(0, 0);
        }
    }
}
