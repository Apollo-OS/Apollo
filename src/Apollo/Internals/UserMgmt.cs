using System;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;
using System.Text;


namespace Apollo.Internals
{
	public class UserMgmt
	{
		public static void ListUsers()
		{
			AddUsers();
			foreach (User u in User.users)
			{
				Console.WriteLine("User: " + u);
				Console.WriteLine("Username: " + u.username);
				Console.WriteLine("User directory: " + u.userdir);
				Console.WriteLine("Fullname: " + u.Name);
			}
		}
		public static User Login()
		{
			bool logged_in = false;
			while (logged_in == false)
			{
				logged_in = true;
				return SwitchUsr();
			}
			return null;
		}

		public static string GetHash(string inputString)
		{
			//byte[] result;
			//var shaM = new SHA1Managed();
			//result = shaM.ComputeHash(Cosmos.Common.Extensions.ByteConverter.GetUtf8Bytes(inputString, 0, (uint)inputString.Length));
			//string hashed = result.ToString();

			return AIC_Framework.Crypto.MD5.hash(inputString);
		}

		/*
		public static void ChangePass()
		{
			Console.Write("Insert new password:");
			string pass = Console.ReadLine();
			Console.Write("Type password again:");
			string passcheck = Console.ReadLine();
			if (pass == passcheck)
			{
				string newpass = GetHash(pass);
				Environment.Environment_variables.usr.pass = newpass;
				//File.Delete(Vars.usr.userdir + User.passfile);
				File.WriteAllText(Environment.KernelVariables.homedir + Environment.Environment_variables.usr.passfile, newpass);
				Console.WriteLine("New password hash: " + newpass.ToString());
				Console.WriteLine("Password changed successfully!");
			}
			else
			{
				Console.WriteLine("Passwords did not match!");
			}
		}
		*/
		public static void AddUsers()
		{
			foreach (string dir in Directory.GetDirectories(Environment.KernelVariables.homedir))
			{
				new User(dir);
			}
		}
		public static User SwitchUsr()
		{
			Console.Write("Enter username:");
			string usrname = Console.ReadLine();
			Console.Write("Enter password:");
			string pass = Console.ReadLine();
			foreach (User u in User.users)
			{
				if (usrname == u.username && GetHash(pass) == u.pass)
				{
					Environment.Environment_variables.current_usr = u;
					Environment.Environment_variables.current_usr.Name = u.Name;
					Environment.Environment_variables.current_usr.userdir = u.userdir;
					Environment.Environment_variables.current_usr.username = u.username;
					Environment.Environment_variables.current_usr.pass = u.pass;
					return u;
				}
				return null;
			}
			return null;
		}
		public static User NewUser()
		{
			Console.WriteLine("User creation:");
			Console.Write("Enter username:");
			string usrname = Console.ReadLine();
			Console.Write("Enter full name:");
			string FullName = Console.ReadLine();
			Console.Write("Enter password");
			string pass = Console.ReadLine();
			return new User(usrname, FullName, pass);
		}
	}
}