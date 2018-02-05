using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo.Environment
{
    public class KernelVariables
    {
        public static string user;
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
    class env_vars
    {
        public static void PressAnyKey()
        {
            PressAnyKey("Press any key to continue...");
        }
        public static void PressAnyKey(string text)
        {
            Console.WriteLine(text);
            Console.ReadKey(true);
        }
    }
}
