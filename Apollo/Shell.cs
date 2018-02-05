using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using System.IO;
using Apollo.Command_db;
using Cosmos.System.FileSystem.VFS;
using AIC_Framework;
using Apollo.Environment;

namespace Apollo
{
    public static class Shell
    {
        public static cmd_mgmt cmds = new cmd_mgmt();
        public static void prompt()
        {
            Console.Write(KernelVariables.user + "/> " + KernelVariables.currentdir + "$");
            var command = Console.ReadLine();
            string[] cmd_args = command.Split(' ');
            if (command.StartsWith("echo"))
            {
                if (cmd_args[1].StartsWith("$"))
                {
                    Console.WriteLine("Dictionaries not yet implemented!");
                    //usr_vars.readVars();
                    Console.WriteLine(usr_vars.retrieve(cmd_args[1].Remove(0, 1)));
                }
                else
                {
                    Console.WriteLine(cmd_args[1]);
                }
            }
            else if (command.StartsWith("mv"))
            {
                fsfunc.mv(KernelVariables.currentdir + cmd_args[1], KernelVariables.currentdir + cmd_args[2]);
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
                Applications.cocoapadEditor.Run(cmd_args[1]);
            }
            else if (command == "cv")
            {
                cpview.Run();
            }
            else if (command.StartsWith("mkdir"))
            {
                fsfunc.mkdir(Environment.KernelVariables.currentdir + cmd_args[1]);
            }
            else if (command.StartsWith("cv "))
            {
                cpview.ViewFile(cmd_args[1]);
            }
            else if (command.StartsWith("copy "))
            {
                if (File.Exists(cmd_args[1]))
                {
                    File.Copy(Environment.KernelVariables.rootdir + cmd_args[1], Environment.KernelVariables.rootdir + cmd_args[2]);
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
                Command_db.Commands.GetHelp.full();
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
}