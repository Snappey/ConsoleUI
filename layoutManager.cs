using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleTUI
{
    class layoutManager
    {
        public static List<ConsoleTUI.Elements.Base> panels = new List<ConsoleTUI.Elements.Base>();
        public static bool input = true;
        public static ConsoleKeyInfo lastKey;
        public static int tabIndex;

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

        public static void startKeyboardInput()
        {
            threads.keyInput = new Thread(new ThreadStart(keyThread));
            threads.keyInput.Start();
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
            Util.resetCursor();
        }

        private static void keyThread()
        {
            while(input)
            {
                lastKey = keyboardInput();
                Util.resetCursor();
               if(lastKey.Key == ConsoleKey.Tab)
               {
                   nextSelectableElement();
               }
            }
        }

        private static ConsoleKeyInfo keyboardInput()
        {
            return Console.ReadKey();
        }

        private static void nextSelectableElement()
        {
            foreach(ConsoleTUI.Elements.Base element in panels)
            {
                if (element.isSelectable == false) { return; }
               if(element.tabIndex == (layoutManager.tabIndex + 1))
               {
                   Console.SetCursorPosition(element.x+1, element.y+1);
               }
               else
               {
                 return; // Dont move cursor
               }
            }
        }

        private static ConsoleTUI.Elements.Base getSelectedElement()
        {
            foreach(ConsoleTUI.Elements.TextInput element in panels )
            {
                if(element.isSelectable == true)
                {
                    if (element.isSelected == true)
                    {
                            return element;
                    }
                }
            }
            return null;
        }
    }
}
