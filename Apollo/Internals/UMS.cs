using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Apollo.Internals
{
    public class Account
    {
        public static List<Account> Accounts = new List<Account>();
        public static int acc_ids = 0;
        public string Username;
        public string Password;
        public string userdir;
        public int acc_id;
        public Account(string user, string pass)
        {
            this.Username = user;
            this.userdir = Environment.KernelVariables.homedir + @"\" + this.Username;
            this.Password = AIC_Framework.Crypto.MD5.hash(pass);
            //this.Password = Environment.UsefulFunctions.CalculateMD5Hash(pass);
            this.acc_id = acc_ids + 1;
            Directory.CreateDirectory(userdir);
            File.WriteAllText(userdir + @"\" + "pass.sys", this.Password);
            File.WriteAllText(userdir + @"\" + "usr_id.sys", this.acc_id.ToString());
        }
    }
}