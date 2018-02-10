using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Apollo.Environment;

namespace Apollo
{
    public class fsfunc
    {
        public static void mkdir(string dirname, bool issys)
        {
            try
            {
                if (issys == true)
                {
                    if (!Directory.Exists(dirname))
                    {
                        Directory.Exists(dirname);
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
        public static void cd_dot_dot()
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
                                            
                    var dir = Kernel.fs.GetDirectory(Environment.KernelVariables.currentdir);
                    string p = dir.mParent.mName;
                    if (!string.IsNullOrEmpty(p))
                    {
                        Environment.KernelVariables.currentdir = p;
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
            }
            else if (Directory.Exists(path))
            {
                KernelVariables.currentdir = path + @"\";
            }
            else
            {
                Console.WriteLine("Folder does not exist " + KernelVariables.currentdir + @"\" + path);
            }
        }
        public static void del(string filename)
        {
            if (File.Exists(filename))
            {
                try
                {
                    File.Delete(KernelVariables.currentdir + @"\" + filename);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else if (Directory.Exists(filename))
            {
                try
                {
                    Directory.Delete(KernelVariables.currentdir + @"\" + filename);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("File/Directory doesn't exist!");
            }

        }
        public static void dir()
        {
            foreach (var dir in Directory.GetDirectories(KernelVariables.currentdir))
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
            foreach (var file in Directory.GetFiles(KernelVariables.currentdir))
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    string[] sp = file.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                    Console.WriteLine(sp[sp.Length - 1] + "\t" + file);
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
