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
            //Bootscreen.Show("Launching Apollo OS...", Bootscreen.Effect.Matrix, ConsoleColor.Red, 1);
            Console.Clear();
            Init.Start();
        }
        public static void MainProcess()
        {
            Console.Write(env_vars.user + " ~" + KernelVariables.currentdir + " /> ");
            string cmd = Console.ReadLine();
            Shell.prompt(cmd);
        }
        protected override void Run()
        {
            MainProcess();
        }
        
    }
    
}
