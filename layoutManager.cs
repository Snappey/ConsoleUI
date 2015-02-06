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
            orderElements();
        }

        private static void orderElements()
        {
            List<ConsoleTUI.Elements.Base> temp = new List<ConsoleTUI.Elements.Base>();
            foreach(ConsoleTUI.Elements.Base element in panels)
            {
                if (element.Equals(panels[0]))
                { 
                    temp.Add(element); 
                }; // Add the first element to the list so we can compare the rest.

                for ( int i=0; i < temp.Count; i++)
                {
                    if (temp[i].z > element.z)
                    {
                        temp.Insert(i,element);
                    }
                }
            }
            panels = temp; // Copy across ordered version
        }
    }
}
