using System;
using System.Collections.Generic;
using System.Text;
using Apollo.Environment;

namespace Apollo.Internals
{
	class UserManagementConsole
	{
		/// <summary>
		/// Run() method for the User Management Console - calls Main() method and passes arguments
		/// </summary>
		public static void Run()
		{
			Console.WriteLine("Apollo User Management Console (AUMC)");
			while (true)
			{
				Console.Write(Environment_variables.current_usr.Name + " />");
				string cmd = Console.ReadLine();
				string[] cmdargs = cmd.Split(' ');
				if (cmd.ToLower() == "quit")
				{
					break;
				}
				Main(cmd, cmdargs);
			}
		}

		/// <summary>
		/// Main method of the user management console
		/// Called by 'Run()' and accepts two strings, one for the command, another for the arguments
		/// </summary>
		/// <param name="command"></param>
		/// <param name="args"></param>
		public static void Main(string command, string[] args)
		{
			if (command.ToLower() == "newuser")
			{
				UserMgmt.NewUser();
			}
			else if (command.ToLower() == "switch")
			{
				UserMgmt.SwitchUsr();
			}
			else if (command.ToLower() == "changepassword")
			{
				Environment_variables.current_usr.ChangePassword();
			}
			else if (command.ToLower() == "list")
			{
				UserMgmt.ListUsers();
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