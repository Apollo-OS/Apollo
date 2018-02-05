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
                    Console.WriteLine("Creating directory " + dirname + "...");
                }
            }
            catch
            {
                Console.WriteLine("mkdir: failed to create directory");
            }
        }
        public static void mv(string src, string dest)
        {
            if (File.Exists(src))
            {
                //Small little hack
                File.Copy(src, dest);
                File.Delete(src);

                //Do nowt for now - File.Move isn't plugged
                //Console.WriteLine("File.Move needs plugging!");
                //File.Move(src, dest);
            }
            else
            {
                Console.WriteLine("file does not exist");
            }
        }
        public static void cd(string input)
        {
            string path = input.Remove(0, 3); //cd <- 2 chars
            if (Directory.Exists(KernelVariables.currentdir + path))
            {
                KernelVariables.currentdir = KernelVariables.currentdir + path;
            }
            else if (Directory.Exists(path))
            {
                KernelVariables.currentdir = path;
            }
            else
            {
                Console.WriteLine("Folder does not exist " + KernelVariables.currentdir + "/" + path);
            }
        }
        public static void deldir(string dirname)
        {
            Directory.Delete(KernelVariables.currentdir + "/" + dirname);
        }
        public static void delfile(string filename)
        {
            File.Delete(KernelVariables.currentdir + "/" + filename);
        }
        public static void dir()
        {
            foreach (var dir in Directory.GetDirectories(KernelVariables.rootdir))
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("<Directory>\t" + dir);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch
                {
                    Console.WriteLine("Failed to retrieve directories");
                }
            }
            foreach (var dir in Directory.GetFiles(KernelVariables.rootdir))
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    string[] sp = dir.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                    Console.WriteLine(sp[sp.Length - 1] + "\t" + dir);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch
                {
                    Console.WriteLine("Failed to retrieve files in directory");
                }
            }
        }
    }
}
