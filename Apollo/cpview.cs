using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Apollo
{
    class cpview
    {
        public static void Run()
        {
            Console.WriteLine("Cocoapad Viewer\n");
            Console.Write(cpedit.savedtext);
            Console.CursorTop = Console.CursorTop + 1;
            Console.CursorLeft = 0;
        }
        public static void ViewFile(string file)
        {
            if (File.Exists(Kernel.rootdir + @"\" + file))
            {
                string[] lines = File.ReadAllLines(Kernel.rootdir + @"\" + file);
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            else
            {
                Console.WriteLine("File not found!");
            }
        }
    }
}