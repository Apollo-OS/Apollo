using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Apollo
{
    class fsfunc
    {
        public static void dir()
        {
            try
            {
                foreach (var dir in Directory.GetDirectories(Kernel.rootdir))
                {
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("<Directory>\t" + dir);
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                foreach (var dir in Directory.GetFiles(Kernel.rootdir))
                {
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        string[] sp = dir.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                        Console.WriteLine(sp[sp.Length - 1] + "\t" + dir);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
