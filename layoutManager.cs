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
        public static int maxTabIndex;

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

        private static void keyThread()
        {
            while (input)
            {
                lastKey = keyboardInput();
                //Util.resetCursor();
                ConsoleTUI.Elements.Base element = getSelectedElement();
                refreshCursorPos(element);
                if (Util.consoleOutput == true) { continue; }
                if (lastKey.Key == ConsoleKey.Enter)
                {
                    lockToElemenet(element);
                }
                if (lastKey.Key == ConsoleKey.Tab)
                {
                    unlockFromElement(element);
                    nextSelectableElement();
                }
            }
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

        private static ConsoleKeyInfo keyboardInput()
        {
            return Console.ReadKey();
        }

        private static void nextSelectableElement()
        {
            maxTabIndex = getLargestTabIndex();
            foreach(ConsoleTUI.Elements.Base element in panels)
            {
               if (element.isSelectable == false) { continue; }
               if (element.isSelected == true) { element.isSelected = false; }
               if (layoutManager.tabIndex == maxTabIndex) { layoutManager.tabIndex = 0; } // Reset tabIndex if we have reached the end
               if(element.tabIndex == (layoutManager.tabIndex + 1))
               {
                   Console.SetCursorPosition(element.x, element.y);
                   layoutManager.tabIndex += 1;
                   element.isSelected = true;
                   break;
               }
               else
               {
                 continue; // Dont move cursor
               }
            }
        }

        private static ConsoleTUI.Elements.Base getSelectedElement()
        {
            foreach(ConsoleTUI.Elements.Base element in panels )
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

        /// <summary>
        /// Works out what element is selected based on where the cursor is on the screen
        /// </summary>
        /// <returns>ConsoleTUI.Elements.Base Element</returns>
        private static ConsoleTUI.Elements.Base workoutSelectedElement()
        {
            int cX = Console.CursorLeft;
            int cY = Console.CursorTop;
            foreach (ConsoleTUI.Elements.Base element in panels)
            {
                if (cX == element.x && cY == element.y)
                {
                    return element;
                }
            }
            return null;
        }

        private static int getLargestTabIndex()
        {
            int tabIndex = 0;
            foreach (ConsoleTUI.Elements.Base element in panels)
            {
                if (element.tabIndex > tabIndex)
                {
                    tabIndex = element.tabIndex;
                }
            }
            return tabIndex;
        }

        private static bool lockToElemenet(ConsoleTUI.Elements.Base element)
        {
            Util.setConsoleOutput(true);
            return true;
        }

        private static bool unlockFromElement(ConsoleTUI.Elements.Base element)
        {
            Util.setConsoleOutput(false);
            return true;
        }

        private static void refreshCursorPos(ConsoleTUI.Elements.Base element)
        {
            if (element != null) { element.cursorRefresh(); }
        }
    }
}
