using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using System.IO;
using Cosmos.System.FileSystem.VFS;
using AIC_Framework;
using Apollo.Environment;
using Apollo;

namespace Apollo.Classic
{
    public class Kernel: Sys.Kernel
    {
		
		protected override void BeforeRun()
        {
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
