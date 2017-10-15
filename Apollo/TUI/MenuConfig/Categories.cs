using System;
using System.Collections.Generic;
using System.Text;
using AIC_Framework;
using Console = AIC_Framework.AConsole;
using menu = AIC_Framework.AConsole.Menu;

namespace Apollo.TUI
{
    class Categories
    {
        public static void CategoryConfig()
        {
            menu.AddCategory(Main);
            menu.AddCategory(Power);
        }
        public static menu.Category Power = new menu.Category("Power utilities");
        public static menu.Category Main = new menu.Category("Main utilities");
    }
}
