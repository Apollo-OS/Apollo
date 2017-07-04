using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo
{
    class Init
    {
        public static void Start()
        {
            make_sys_dir();
            UserInit();
        }
        public static void make_sys_dir()
        {
            Console.WriteLine("Creating system directories...");
            try
            {
                fsfunc.mkdir(KernelVariables.etcdir);
                fsfunc.mkdir(KernelVariables.bindir);
                fsfunc.mkdir(KernelVariables.sbindir);
                fsfunc.mkdir(KernelVariables.procdir);
                fsfunc.mkdir(KernelVariables.usrdir);
                fsfunc.mkdir(KernelVariables.homedir);
                fsfunc.mkdir(KernelVariables.rootdir);
                fsfunc.mkdir(KernelVariables.tmpdir);
                fsfunc.mkdir(KernelVariables.vardir);
                fsfunc.mkdir(KernelVariables.srvdir);
                fsfunc.mkdir(KernelVariables.libdir);
                fsfunc.mkdir(KernelVariables.optdir);
                fsfunc.mkdir(KernelVariables.devdir);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void UserInit()
        {
            Console.WriteLine("It is dangerous to run some commands as a root user,\nso it's important that you use a non-admin user.");
            Console.WriteLine("Enter a new username for first user:");
            string username = Console.ReadLine();
            fsfunc.mkdir(KernelVariables.homedir + "/" + username);
        }
    }
}
