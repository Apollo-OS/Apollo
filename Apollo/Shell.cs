using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using System.IO;
using Apollo.Command_db;
using Cosmos.System.FileSystem.VFS;
using AIC_Framework;
using Apollo.Environment;
using Apollo.Applications;

namespace Apollo
{
    public static class Shell
    {
        public static cmd_mgmt cmds = new cmd_mgmt();
        public static void prompt(string cmdline)
        {
            var command = cmdline.ToLower();
            var cmdCI = cmdline;
            string[] cmdCI_args = cmdline.Split(' ');
            string[] cmd_args = command.Split(' ');
            if (cmdline.StartsWith("echo"))
            {
                if (cmd_args[1].StartsWith("$"))
                {
                    Console.WriteLine("Dictionaries not yet implemented!");
                    //usr_vars.readVars();
                    Console.WriteLine(usr_vars.retrieve(cmd_args[1].Remove(0, 1)));
                }
                else
                {
                    Console.WriteLine(cmdCI_args[1]);
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
            else if (command == "cowsay")
            {
                Cowsay.Cow("Say something using 'Cowsay <message>'");
                Console.WriteLine(@"You can also use 'cowsay -f' tux for penguin, cow for cow and 
sodomized-sheep for, you guessed it, a sodomized-sheep");
            }
            else if (command.StartsWith("cowsay"))
            {
                if (cmd_args[1] == "-f")
                {
                    if (cmd_args[2] == "cow")
                    {
                        Cowsay.Cow(command.Remove(0, cmd_args[0].Length + cmd_args[1].Length + cmd_args[2].Length + 3));
                    }
                    else if (cmd_args[2] == "tux")
                    {
                        Cowsay.Tux(command.Remove(0, cmd_args[0].Length + cmd_args[1].Length + cmd_args[2].Length + 3));
                    }
                    else if (cmd_args[2] == "sodomized-sheep")
                    {
                        Cowsay.SodomizedSheep(command.Remove(0, cmd_args[0].Length + cmd_args[1].Length + cmd_args[2].Length + 3));
                    }
                }
                else
                {
                    Cowsay.Cow(command.Substring(7));
                }
            }
            else if (command.StartsWith("$"))
            {
                Console.WriteLine("Dictionaries not yet implemented!");
                //usr_vars.store(command.Remove(0, 1), cmd_args[2]);
            }
            else if (command.StartsWith("run "))
            {
                if (!File.Exists(KernelVariables.currentdir + cmd_args[1]))
                {
                    Console.WriteLine("File doesn't exist!");
                }
                else
                {
                    Mdscript.Execute(KernelVariables.currentdir + cmd_args[1]);
                }
            }
            else if (command.StartsWith("get "))
            {
                //usr_vars.retrieve(cmd_args[1]);
            }
            else if (command.StartsWith("edit "))
            {
                Applications.cocoapadEditor.Run(cmd_args[1]);
            }
            else if (command == "edit")
            {
                Console.WriteLine("Usage: edit <filename>");
                Console.WriteLine("Launches the text editor using the filename specified");
            }
            else if (command.StartsWith("mkdir"))
            {
                fsfunc.mkdir(KernelVariables.currentdir + cmd_args[1]);
            }
            else if (command.StartsWith("cv "))
            {
                cocoapadViewer.ViewFile(cmd_args[1]);
            }
            else if (command == "miv")
            {
                MIV.StartMIV();
            }
            else if (command.StartsWith("miv "))
            {
                MIV.StartMIV(cmd_args[1]);
            }
            else if (command.StartsWith("copy "))
            {
                if (File.Exists(cmd_args[1]))
                {
                    File.Copy(KernelVariables.rootdir + cmd_args[1], KernelVariables.rootdir + cmd_args[2]);
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
            if (command == "cd ..")
            {
                try
                {
                    if (KernelVariables.currentdir == KernelVariables.rootdir)
                    {
                        Console.WriteLine("Cannot go up any more levels!");
                    }
                    else
                    {
                        var pos = KernelVariables.currentdir.LastIndexOf('\\');
                        if (pos >= 0)
                        {
                            KernelVariables.currentdir = KernelVariables.currentdir.Substring(0, pos) + @"\";
                        }
                        /*                        
                        var dir = FSfunc.fs.GetDirectory(Kernel.current_dir);
                        string p = dir.mParent.mName;
                        if (!string.IsNullOrEmpty(p))
                        {
                            Kernel.current_dir = p;
                        }
                        */
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to change directory!");
                    //ErrorHandler.Init(0, ex.Message, false, "");
                }
            }
            else if (command == "dir")
            {
                fsfunc.dir();
            }
            else if (command == "help")
            {
                Command_db.Commands.GetHelp.Full();
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
                Command_db.Commands.GetHelp.Specific(cmd_args[1]);
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