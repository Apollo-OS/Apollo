using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using System.IO;
using Cosmos.System.FileSystem.VFS;
using AIC_Framework;

namespace Apollo
{
    public class Kernel : Sys.Kernel
    {
        public static Sys.FileSystem.CosmosVFS fs = new Sys.FileSystem.CosmosVFS();

        protected override void BeforeRun()
        {
            VFSManager.RegisterVFS(fs);
            fs.Initialize();
            Console.Clear();
            //Bootscreen.Show("Launching Apollo OS...", Bootscreen.Effect.Matrix, ConsoleColor.Red, 1);
            Console.Clear();
            if (!Directory.Exists(Environment.KernelVariables.devdir))
            {
                Init.Start();
            }
            else
            {
                Environment.KernelVariables.user = File.ReadAllText(Environment.KernelVariables.usrdir + @"\" + "usr.sys");
            }
            Console.WriteLine("Welcome to Apollo");
            if (!Directory.Exists(Environment.KernelVariables.bindir))
            {
                Directory.CreateDirectory(Environment.KernelVariables.currentdir);
                File.Create(Environment.KernelVariables.bindir + "vars.sys").Dispose();
            }
            else
            {
                usr_vars.readVars();
            }
            Console.Clear();
        }
        public static void MainProcess()
        {
            Console.Write(Environment.KernelVariables.user + "/> " + Environment.KernelVariables.currentdir + "$");
            string cmd = Console.ReadLine();
            Shell.prompt(cmd);
        }
        protected override void Run()
        {
            MainProcess();
        }
        
    }
    
}
