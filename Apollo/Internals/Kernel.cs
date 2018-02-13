using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using System.IO;
using Cosmos.System.FileSystem.VFS;
using AIC_Framework;
using Apollo.Environment;

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
            Directory.SetCurrentDirectory(KernelVariables.rootdir);
            //Bootscreen.Show("Launching Apollo OS...", Bootscreen.Effect.Matrix, ConsoleColor.Red, 1);
            Console.Clear();
            if (!Directory.Exists(KernelVariables.devdir))
            {
                Init.Start();
            }
            else
            {
                KernelVariables.user = File.ReadAllText(KernelVariables.usrdir + @"\" + "usr.sys");
            }
            Console.WriteLine("Welcome to Apollo");
            if (!Directory.Exists(KernelVariables.bindir))
            {
                Directory.CreateDirectory(KernelVariables.currentdir);
                File.Create(KernelVariables.bindir + "vars.sys").Dispose();
            }
            else
            {
                usr_vars.ReadVars();
            }
            Console.Clear();
        }
        public static void MainProcess()
        {
            Console.Write(KernelVariables.user + " ~" + KernelVariables.currentdir + " /> ");
            string cmd = Console.ReadLine();
            Shell.prompt(cmd);
        }
        protected override void Run()
        {
            MainProcess();
        }
        
    }
    
}
