using System;
using System.Collections.Generic;
using System.Text;
using AIC_Framework;
using menu = AIC_Framework.AConsole.Menu;
using Console = AIC_Framework.AConsole;

namespace Apollo.TUI
{
    class Entries
    {
        public static void EntryConfig()
        {
            Categories.Power.AddEntry(new PowerEntries.ShutdownEntry());
            Categories.Power.AddEntry(new PowerEntries.RebootEntry());
            Categories.Power.AddEntry(new PowerEntries.RAMEntry());
            Categories.Main.AddEntry(new MainEntries.Exit());
            
        }
    }
    class PowerEntries
    {
        public class RAMEntry : menu.Entry
        {
            public RAMEntry() { this.text = "RAM"; }
            public override void Execute()
            {
                Console.WriteLine("getRAM");
            }
        }
        public class ShutdownEntry : menu.Entry
        {
            public ShutdownEntry() { this.text = "Shutdown"; }
            public override void Execute()
            {
                Console.Clear();
                Console.WriteLine("Press any key to shutdown...");
                Console.ReadKey(true);
                userACPI.Shutdown();
            }
        }
        public class RebootEntry : menu.Entry
        {
            public RebootEntry() { this.text = "Reboot"; }
            public override void Execute()
            {
                Console.Clear();
                Console.WriteLine("Press any key to reboot...");
                Console.ReadKey(true);
                userACPI.Reboot();
            }
        }
    }
    class MainEntries
    {
        public class Exit : menu.Entry
        {
            public Exit() { this.text = "Exit"; }
            public override void Execute()
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Shell.prompt();
            }
        }
    }
}
