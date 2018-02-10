using System;
using System.Collections.Generic;
using System.Text;
using AIC_Framework;
using Apollo.Environment;
using Apollo.Internals;

namespace Apollo
{
    class Init
    {
        public static void Start()
        {
            AConsole.WriteLineEx("    Welcome to Apollo OS    ", ConsoleColor.White, ConsoleColor.Gray, true, false);
            AConsole.WriteLineEx("Press any key to continue...", ConsoleColor.White, ConsoleColor.Gray, true, false);
            AConsole.ReadKey(true);
            make_sys_dir();
            UserInit();
        }
        public static void make_sys_dir()
        {
            Console.WriteLine("Creating system directories...");
            try
            {
                Console.WriteLine("Creating " + KernelVariables.etcdir + "...");
                fsfunc.mkdir(KernelVariables.etcdir, true);
                Console.WriteLine("Creating " + KernelVariables.bindir + "...");
                fsfunc.mkdir(KernelVariables.bindir, true);
                Console.WriteLine("Creating " + KernelVariables.sbindir + "...");
                fsfunc.mkdir(KernelVariables.sbindir, true);
                Console.WriteLine("Creating " + KernelVariables.procdir + "...");
                fsfunc.mkdir(KernelVariables.procdir, true);
                Console.WriteLine("Creating " + KernelVariables.usrdir + "...");
                fsfunc.mkdir(KernelVariables.usrdir, true);
                Console.WriteLine("Creating " + KernelVariables.homedir + "...");
                fsfunc.mkdir(KernelVariables.homedir, true);
                Console.WriteLine("Creating " + KernelVariables.rootusrdir + "...");
                fsfunc.mkdir(KernelVariables.rootusrdir, true);
                Console.WriteLine("Creating " + KernelVariables.tmpdir + "...");
                fsfunc.mkdir(KernelVariables.tmpdir, true);
                Console.WriteLine("Creating " + KernelVariables.vardir + "...");
                fsfunc.mkdir(KernelVariables.vardir, true);
                Console.WriteLine("Creating " + KernelVariables.srvdir + "...");
                fsfunc.mkdir(KernelVariables.srvdir, true);
                Console.WriteLine("Creating " + KernelVariables.libdir + "...");
                fsfunc.mkdir(KernelVariables.libdir, true);
                Console.WriteLine("Creating " + KernelVariables.optdir + "...");
                fsfunc.mkdir(KernelVariables.optdir, true);
                Console.WriteLine("Creating " + KernelVariables.devdir + "...");
                fsfunc.mkdir(KernelVariables.devdir, true);
            }
            catch
            {
                Console.WriteLine("Failed to create directories!");
            }
        }
        public static void UserInit()
        {
            Console.WriteLine("It is dangerous to run some commands as a root user,\nso it's important that you use a non-admin user.");
            Console.WriteLine("Enter a new username for first user:");
            string user = Console.ReadLine();
            string pass = Console.ReadLine();
            Account.Accounts.Add(new Account(user, pass));
            KernelVariables.user = user;
        }
    }
}