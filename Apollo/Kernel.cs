using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using System.IO;
using Apollo.Command_db;
using Cosmos.System.FileSystem.VFS;
using AIC_Framework;

namespace Apollo
{
    public class Kernel: Sys.Kernel
    {
        Sys.FileSystem.CosmosVFS fs;
        public static cmd_mgmt cmds = new cmd_mgmt();
        public static string rootdir = @"0:\\";
        public static string currentdir = rootdir;
        protected override void BeforeRun()
        {
            fs = new Sys.FileSystem.CosmosVFS();
            VFSManager.RegisterVFS(fs);
            fs.Initialize();
            AIC_Framework.Bootscreen.Show("Apollo OS", Bootscreen.Effect.Matrix, ConsoleColor.DarkGreen, 5);
            Init.Start();
            Console.WriteLine("Welcome to Apollo");
            if (!Directory.Exists(currentdir))
            {
                Directory.CreateDirectory(currentdir);
                File.Create(rootdir + "vars.sys").Dispose();
            }
            else
            {
                //usr_vars.readVars();
            }
            Console.Clear();

            Console.Clear();
        }
        protected override void Run()
        {
            prompt();
        }
        public static void prompt()
        {
            Console.Write(currentdir + " />");
            var command = Console.ReadLine();
            string[] cmd_args = command.Split(' ');
            //if (command.StartsWith("mv "))
            //{
            //    if (File.Exists(cmd_args[1]))
            //    {
            //        File.Move(currentdir + cmd_args[1], rootdir + cmd_args[2]);
            //    }
            //    else
            //    {
            //        Console.WriteLine("File does not exist");
            //    }
            //}
            if (command.StartsWith("echo"))
            {
                if (cmd_args[1].StartsWith("$"))
                {
                    Console.WriteLine("Dictionaries not yet implemented!");
                    //usr_vars.readVars();
                    //Console.WriteLine(usr_vars.retrieve(cmd_args[1].Remove(0, 1)));
                }
                else
                {
                    Console.WriteLine(cmd_args[1]);
                }
            }
            else if (command == "tui")
            {
                TUI.TUI.Run();
            }
            else if (command.StartsWith("$"))
            {
                Console.WriteLine("Dictionaries not yet implemented!");
                //usr_vars.store(command.Remove(0, 1), cmd_args[2]);
            }
            else if (command.StartsWith("get "))
            {
                //usr_vars.retrieve(cmd_args[1]);
            }
            else if (command.StartsWith("cp "))
            {
                cpedit.Run(cmd_args[1]);
            }
            else if (command == "cv")
            {
                cpview.Run();
            }
            else if (command.StartsWith("mkdir"))
            {
                fsfunc.mkdir(currentdir + cmd_args[1]);
            }
            else if (command.StartsWith("cv "))
            {
                cpview.ViewFile(cmd_args[1]);
            }
            else if (command.StartsWith("copy "))
            {
                if (File.Exists(cmd_args[1]))
                {
                    File.Copy(rootdir + cmd_args[1], rootdir + cmd_args[2]);
                }
                else
                {
                    Console.WriteLine("File does not exist");
                }
            }
            else if (command.StartsWith("cd"))
            {
                fsfunc.cd(cmd_args[1]);
            }
            else if (command == "dir")
            {
                fsfunc.dir();
            }
            else if (command == "help")
            {
                cmds.Run("help");
            }
            else if (command == "shutdown")
            {
                Console.WriteLine("Dictionaries not yet implemented!");
                //usr_vars.saveVars();
                userACPI.Shutdown();
            }
            else if (command == "reboot")
            {
                Console.WriteLine("Dictionaries not yet implemented!");
                //usr_vars.saveVars();
                userACPI.Reboot();
            }
            else if (command == "savevars")
            {
                Console.WriteLine("Dictionaries not yet implemented!");
                //usr_vars.saveVars();
            }
            else if (command == "loadvars")
            {
                Console.WriteLine("Dictionaries not yet implemented!");
                //usr_vars.readVars();
            }
            else if (command.StartsWith("help "))
            {

            }
            else if (command == "")
            {

            }
            else
            {
                Console.WriteLine("Invalid command");
            }
    }
    }
    public class KernelVariables
    {
        public static string etcdir = Kernel.rootdir + "/" + "etc";
        public static string bindir = Kernel.rootdir + "/" + "bin";
        public static string sbindir = Kernel.rootdir + "/" + "sbin";
        public static string procdir = Kernel.rootdir + "/" + "proc";
        public static string usrdir = Kernel.rootdir + "/" + "usr";
        public static string homedir = Kernel.rootdir + "/" + "home";
        public static string rootusrdir = Kernel.rootdir + "/" + "root";
        public static string tmpdir = Kernel.rootdir + "/" + "tmp";
        public static string vardir = Kernel.rootdir + "/" + "var";
        public static string srvdir = Kernel.rootdir + "/" + "srv";
        public static string libdir = Kernel.rootdir + "/" + "lib";
        public static string optdir = Kernel.rootdir + "/" + "opt";
        public static string devdir = Kernel.rootdir + "/" + "dev";
    }
}
