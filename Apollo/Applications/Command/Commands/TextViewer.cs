using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using AIC_Framework;

namespace Apollo.Applications.Commands
{
    public class TextViewer : Command
    {
        public string cmdName;
        public string help;
        public static void Help()
        {
            Console.WriteLine("view <file>      Prints the contents of a file onto the screen.");
            Console.WriteLine("Cocoapad Viewer is a file viewer that provides the functionality to view text stored in .txt and other files.");
        }
        public static void Run(string file)
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
        private static void DrawScreen()
        {
            AConsole.Fill(ConsoleColor.Blue);
            Console.CursorTop = 0;
            AConsole.WriteLineEx(" Cocoapad Viewer ", ConsoleColor.White, ConsoleColor.Gray, true, false);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.CursorTop = 3;
        }
    }
}
