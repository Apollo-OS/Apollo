using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Apollo
{
    public class fsfunc
    {
        public static void mkdir(string dirname)
        {
            try
            {
                if (!Directory.Exists(dirname))
                {
                    Directory.CreateDirectory(dirname);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("mkdir: " + ex.Message);
            }
        }
        public static void cd(string input)
        {
            string path = input.Remove(0, 3); //cd <- 2 chars
            if (Directory.Exists(Kernel.currentdir + path))
            {
                Kernel.currentdir = Kernel.currentdir + path;
            }
            else if (Directory.Exists(path))
            {
                Kernel.currentdir = path;
            }
            else
            {
                Console.WriteLine("Folder does not exist " + Kernel.currentdir + "/" + path);
            }
        }
        public static void deldir(string dirname)
        {
            Directory.Delete(Kernel.currentdir + "/" + dirname);
        }
        public static void delfile(string filename)
        {
            File.Delete(Kernel.currentdir + "/" + filename);
        }
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
