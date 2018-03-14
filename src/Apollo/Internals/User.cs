using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Apollo.Environment;

namespace Apollo.Internals
{
	public class User
	{
		public static List<User> users = new List<User>();
		public string username;
		public string Name;
		public string pass;
		public string userdir;

		private string usrfile;
		private string namefile;
		private string passfile;

		/// <summary>
		/// Changes the user's password
		/// </summary>
		public void ChangePassword()
		{
			Console.Write("Insert new password:");
			string pass = Console.ReadLine();
			Console.Write("Type password again:");
			string passcheck = Console.ReadLine();
			if (pass == passcheck)
			{
				string newpass = UserMgmt.GetHash(pass);
				this.pass = newpass;
				if (Environment_variables.current_usr == this)
				{
					Environment_variables.current_usr.pass = newpass;
				}
				//File.Delete(Vars.usr.userdir + User.passfile);
				File.WriteAllText(KernelVariables.homedir + Environment_variables.current_usr.passfile, newpass);
				Console.WriteLine("Password changed successfully!");
			}
			else
			{
				Console.WriteLine("Passwords did not match!");
			}
		}

		/// <summary>
		/// Constructor for user, specifying username, full name and password
		/// </summary>
		/// <param name="username"></param>
		/// <param name="Name"></param>
		/// <param name="password"></param>
		public User(string username, string Name, string password)
		{
			this.username = username;
			this.Name = Name;
			pass = UserMgmt.GetHash(password);
			userdir = KernelVariables.homedir + @"\" + username;

			namefile = userdir + @"\name.sys";
			usrfile = userdir + @"\user.sys";
			passfile = userdir + @"\pass.sys";

			if (Directory.Exists(userdir))
			{
				Directory.Delete(userdir, true);
			}
			Directory.CreateDirectory(userdir);
			File.WriteAllText(usrfile, username);
			File.WriteAllText(namefile, Name);
			File.WriteAllText(passfile, pass);

			users.Add(this);
		}

		/// <summary>
		/// Constructor for user, only specifying user directory - fields are read from file
		/// </summary>
		/// <param name="userdir"></param>
		public User(string userdir)
		{
			if (File.Exists(userdir + usrfile))
			{
				username = File.ReadAllText(userdir + @"/user.sys");
				if (File.Exists(userdir + namefile))
				{
					Name = File.ReadAllText(userdir + namefile);
					if (File.Exists(userdir + passfile))
					{
						pass = File.ReadAllText(userdir + @"/pass.sys");
						users.Add(this);
					}
					else
					{
						Console.WriteLine("This user does not have a password set! " + username);
					}
				}
				else
				{
					Console.WriteLine("No fullname set! " + username);
					Console.WriteLine("Using username as fullname.");
					Name = username;
				}
			}
			else
			{
				Console.WriteLine("User directory is invalid or corrupted!" + "");
			}
		}
	}
}
