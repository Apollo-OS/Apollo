using System;
using System.Collections.Generic;
using System.Text;
using AIC_Framework;
using Apollo.Environment;
using Apollo.Internals;
using System.IO;
using Sys = Cosmos.System;
using Cosmos.System.FileSystem.VFS;

namespace Apollo
{
    public class Init
    {
		public static Sys.FileSystem.CosmosVFS fs = new Sys.FileSystem.CosmosVFS();
		/// <summary>
		/// Starts the INIT method, creating filesystem, registering the filesystem
		/// </summary>
		public static void Start()
        {
			VFSManager.RegisterVFS(fs);
			fs.Initialize();
			AConsole.WriteLineEx("    Welcome to Apollo OS    ", ConsoleColor.White, ConsoleColor.Gray, true, false);
            AConsole.WriteLineEx("Press any key to continue...", ConsoleColor.White, ConsoleColor.Gray, true, false);
            AConsole.ReadKey(true);
			if (IntegrityCheck() == false)
			{
				Console.Clear();
				Console.WriteLine("Filesystem integrity checks completed!");
				Console.WriteLine("Not all directories were present however, so they have been recreated.");
				Console.WriteLine("Data loss is to be expected.");
				Environment_variables.PressAnyKey();
				Console.Clear();
			}
			else
			{
				Console.Clear();
				Console.WriteLine("Filesystem integrity checks completed!");
				Console.WriteLine("All filesystem checks passed successfully, but be sure to check files in case.");
				Environment_variables.PressAnyKey();
				Console.Clear();
			}
			UserInit();
            if (!File.Exists(usr_vars.varsfile))
            {
                File.Create(KernelVariables.bindir + "vars.sys").Dispose();
            }
            else
            {
                usr_vars.ReadVars();
            }
            Console.WriteLine("SysGuard Checks proceeded.");
            Environment_variables.PressAnyKey("Press any key to continue boot...");
            Console.Clear();
            
        }
        private static void Make_sys_dir()
        {
            foreach (string dir in KernelVariables.SystemDirectories)
            {
				if (dir == KernelVariables.rootdir)
				{
					continue;
				}
                Console.WriteLine("Creating " + dir + "...");
                try
                {
                    fsfunc.mkdir(dir, true);
                }
                catch
                {
                    Console.WriteLine("Failed to create " + dir + " directory!");
                }
            }
        }

		/// <summary>
		/// IEnumerable bool, returns true if a directory exists, if not, return false
		/// </summary>
		/// <returns></returns>
        public static bool IntegrityCheck()
        {
			int i;
			int dirs = KernelVariables.SystemDirectories.Count;
			for (i = 0; i < dirs;)
			{
				foreach (string dir in KernelVariables.SystemDirectories)
				{
					if (dir == KernelVariables.rootdir)
					{
						i++;
						continue;
					}
					if (!Directory.Exists(dir))
					{
						return false;
					}
					else if (Directory.Exists(dir))
					{
						i++;
						continue;
					}
					else
					{
						return false;
					}
				}
				return true;
			}
			return true;
        }

		/// <summary>
		/// Initiates users
		/// If any are found, add them to the list ( UserMgmt.AddUsers )
		/// If no users are found, create them
		/// </summary>
		public static void UserInit()
        {
			string[] users = Directory.GetDirectories(KernelVariables.homedir);
			if (users.Length == 0)
			{
				Environment_variables.current_usr = UserMgmt.NewUser();
			}
			else
			{
				UserMgmt.AddUsers();
				Environment_variables.current_usr = UserMgmt.Login();
			}
        }
    }
}