using System;
using System.Collections.Generic;
using System.Text;
using AIC_Framework;
using AIC_Framework.Extensions;
using Console = AIC_Framework.AConsole;
using menu = AIC_Framework.AConsole.Menu;

namespace Apollo.TUI
{
    class TUI
    {
        public static void Run()
        {
            Console.Clear();
            menu.Reset();
            Categories.CategoryConfig();
            Entries.EntryConfig();
            menu.Show();
        }
    }
}
