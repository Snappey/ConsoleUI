using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Elements
{
    interface ISelectable
    {
        event EventHandler OnClick;
        event EventHandler OnSelected;
        event EventHandler OnSelectedChanged;

        void DoClick();
        void DoSelected();
        void DoSelectedChanged();
    }
}
