using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Apollo.Environment;

namespace Apollo
{
    public class fsfunc
    {
        //public static string CurrentDirectory = Directory.GetCurrentDirectory();
        public static void mkdir(string dirname, bool issys)
        {
            try
            {
                if (issys == true)
                {
                    if (!Directory.Exists(dirname))
                    {
                        Directory.CreateDirectory(dirname);
                    }
                }
                else
                {
                    if (!Directory.Exists(dirname))
                    {
                        Directory.CreateDirectory(KernelVariables.currentdir + @"\" + dirname);
                    }
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
        public static void CDP()
        {
            try
            {
                if (KernelVariables.currentdir == KernelVariables.rootdir)
                {
                    Console.WriteLine("Cannot go up any more levels!");
                }
                else
                {
                    //var pos = KernelVariables.currentdir.LastIndexOf('\\');
                    //if (pos >= 0)
                    //{
                        //KernelVariables.currentdir = KernelVariables.currentdir.Substring(0, pos) + @"\";
                    //}
                                            
                    var dir = Kernel.fs.GetDirectory(KernelVariables.currentdir);
                    string p = dir.mParent.mName;
                    if (!string.IsNullOrEmpty(p))
                    {
                        KernelVariables.currentdir = p;
                        Directory.SetCurrentDirectory(p);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to change directory!");
                //ErrorHandler.Init(0, ex.Message, false, "");
            }
        }
        public static void cd(string input)
        {
            string path = input;
            if (Directory.Exists(KernelVariables.currentdir + path))
            {
                KernelVariables.currentdir = KernelVariables.currentdir + @"\" + path;
                string cd = Directory.GetCurrentDirectory();
                Directory.SetCurrentDirectory(cd + path);
            }
            else if (Directory.Exists(path))
            {
                KernelVariables.currentdir = path;
                Directory.SetCurrentDirectory(path);
            }
            else
            {
                Console.WriteLine("Folder does not exist " + KernelVariables.currentdir + @"\" + path);
            }
        }
        public static void del(string filename, bool recursive)
        {
            if (File.Exists(filename))
            {
                try
                {
                    File.Delete(KernelVariables.currentdir + filename);
                }
                catch
                {
                    Console.WriteLine("Failed to delete file!");
                }
            }
            else if (Directory.Exists(filename))
            {
                if (recursive == true)
                {
                    try
                    {
                        Directory.Delete(filename, true);
                    }
                    catch
                    {
                        Console.WriteLine("Failed to recursively delete directory!");
                    }
                }
                try
                {
                    Directory.Delete(KernelVariables.currentdir + filename);
                }
                catch
                {
                    Console.WriteLine("Failed to delete directory!");
                }
            }
            else
            {
                Console.WriteLine("File/Directory doesn't exist!");
            }

        }
        public static void dir()
        {
            dir(KernelVariables.currentdir);
        }
        public static void dir(string path)
        {

            string[] directories = Directory.GetDirectories(path);
            string[] files = Directory.GetFiles(path);
            //Array.Sort(directories);
            //Array.Sort(files);
            try
            {
                Console.WriteLine("-: Directories :-");
                foreach (string dir in directories)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("<Directory>\t" + dir);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch
            {
                Console.WriteLine("Failed to retrieve directories/files");
            }
            try
            {
                Console.WriteLine("-: Files :-");
                foreach (string file in files)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    string[] sp = file.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                    Console.WriteLine(sp[sp.Length - 1] + "\t" + file);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch
            {
                Console.WriteLine("Failed to retrieve directories/files");
            }
    }
    }
}
