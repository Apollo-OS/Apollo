using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using System.IO;
using Apollo.Command_db;
using Cosmos.System.FileSystem.VFS;

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
            Console.WriteLine("Welcome to the Medli NG Kernel");
            if (!Directory.Exists(currentdir))
            {
                Directory.CreateDirectory(currentdir);
                File.Create(rootdir + "vars.sys").Dispose();
            }
            else
            {
                usr_vars.readVars();
            }
        }
        protected override void Run()
        {
            Console.Write("/>");
            var command = Console.ReadLine();
            string[] cmd_args = command.Split(' ');
            if (command.StartsWith("mv "))
            {
                if (File.Exists(cmd_args[1]))
                {
                    File.Move(currentdir + cmd_args[1], rootdir + cmd_args[2]);
                }
                else
                {
                    Console.WriteLine("File does not exist");
                }
            }
            else if (command.StartsWith("echo"))
            {
                if (cmd_args[1].StartsWith("$"))
                {
                    usr_vars.readVars();
                    Console.WriteLine(usr_vars.retrieve(cmd_args[1].Remove(0, 1)));
                }
                else
                {
                    Console.WriteLine(cmd_args[1]);
                }
            }
            else if (command.StartsWith("$"))
            {
                usr_vars.store(command.Remove(0, 1), cmd_args[2]);
            }
            else if (command.StartsWith("get "))
            {
                usr_vars.retrieve(cmd_args[1]);
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
                Directory.CreateDirectory(currentdir + cmd_args[1]);
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
                usr_vars.saveVars();
                //shutdown();
            }
            else if (command == "savevars")
            {
                usr_vars.saveVars();
            }
            else if (command == "loadvars")
            {
                usr_vars.readVars();
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
}
