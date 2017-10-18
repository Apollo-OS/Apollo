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

        protected override void BeforeRun()
        {
            fs = new Sys.FileSystem.CosmosVFS();
            VFSManager.RegisterVFS(fs);
            fs.Initialize();
            Console.Clear();
            Bootscreen.Show("Launching Apollo OS...", Bootscreen.Effect.Matrix, ConsoleColor.Red, 1);
            Console.Clear();
            Init.Start();
            Console.WriteLine("Welcome to Apollo");
            if (!Directory.Exists(KernelVariables.currentdir))
            {
                Directory.CreateDirectory(KernelVariables.currentdir);
                File.Create(KernelVariables.rootdir + "vars.sys").Dispose();
            }
            else
            {
                //usr_vars.readVars();
            }
            Console.Clear();
        }
        protected override void Run()
        {
            Shell.prompt();
        }
        
    }
    public class KernelVariables
    {
        public static string rootdir = @"0:\\";
        public static string currentdir = rootdir;
        public static string etcdir = rootdir + "/" + "etc";
        public static string bindir = rootdir + "/" + "bin";
        public static string sbindir = rootdir + "/" + "sbin";
        public static string procdir = rootdir + "/" + "proc";
        public static string usrdir = rootdir + "/" + "usr";
        public static string homedir = rootdir + "/" + "home";
        public static string rootusrdir = rootdir + "/" + "root";
        public static string tmpdir = rootdir + "/" + "tmp";
        public static string vardir = rootdir + "/" + "var";
        public static string srvdir = rootdir + "/" + "srv";
        public static string libdir = rootdir + "/" + "lib";
        public static string optdir = rootdir + "/" + "opt";
        public static string devdir = rootdir + "/" + "dev";
    }
}
