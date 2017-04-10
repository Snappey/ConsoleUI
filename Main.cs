using System;
using ConsoleUI.Elements;
using ConsoleUI.Manager;

namespace ConsoleTUI
{
    class MainEntry
    {
        static void Main(string[] args)
        {         
            Init();

            var p = 0;
            Panel pnl = new Panel(5,5,90,15);
    
            Label lbl = new Label(2,2,"Testing", pnl);
            lbl.SetTextColor(ConsoleColor.Black);

            TextEntry txtEntry = new TextEntry(24,2, 42, pnl);

            Button btn = new Button(2,6,20,5, pnl);
            btn.OnClick += delegate(object sender, EventArgs eventArgs) { lbl.SetText("Test#1"); };

            Button btn2 = new Button(24, 6, 20, 5, pnl);
            btn2.OnClick += delegate(object sender, EventArgs eventArgs) {  lbl.SetText("LOL"); };

            Button btn3 = new Button(46, 6, 20, 5, pnl);
            btn3.OnClick += delegate(object sender, EventArgs eventArgs) { lbl.SetText("Asd"); };

            for (int i = 0; i < Console.BufferHeight; i++)
            {
                Label dbg = new Label(0, i, i.ToString());
            }

            Footer ftr = new Footer();

            Label count = new Label(Console.WindowWidth - 19, 0, "Button Count: 0", ftr);
            Keys.ConsoleKeyPressed += delegate (object sender, Keys.KeyEventArgs eventArgs) { p++; count.SetText("Button Count:" + p); };

            Console.CursorVisible = false;
        }

        private static void Init()
        {      
            Console.BufferWidth = 120;
            Console.BufferHeight = 31;
            Console.SetWindowSize(120, 30);

            Hooks.StartEvents();
            Keys.StartKeys();

        }
    }
}
