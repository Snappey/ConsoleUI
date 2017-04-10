using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleUI.Manager;

namespace ConsoleUI.Interfaces
{
    interface ITypable
    {
        event EventHandler KeyPressed;

        void KeyPress(Keys.KeyEventArgs key);

        string GetContents();
        void SetContents(string str);
    }
}
