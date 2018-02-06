using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using AIC_Framework;

namespace Apollo.Applications
{
    class cocoapadViewer
    {
        private static void DrawScreen()
        {
            AConsole.Fill(ConsoleColor.Blue);
            Console.CursorTop = 0;
            AConsole.WriteLineEx(" Cocoapad Viewer ", ConsoleColor.White, ConsoleColor.Gray, true, false);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.CursorTop = 3;
        }
        public static void ViewFile(string file)
        {
            DrawScreen();
            try
            {
                if (File.Exists(Environment.KernelVariables.currentdir + @"\" + file))
                {
                    string[] lines = File.ReadAllLines(Environment.KernelVariables.currentdir + @"\" + file);
                    foreach (string line in lines)
                    {
                        Console.WriteLine(line);
                    }
                }
                else if (!File.Exists(Environment.KernelVariables.currentdir + @"\" + file))
                {
                    Console.WriteLine("File does not exist!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Environment.env_vars.PressAnyKey();
        }
    }
}
