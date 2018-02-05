using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Apollo.Environment;

namespace Apollo
{
    class usr_vars
    {
        public static string varsfile = KernelVariables.rootdir + "vars.sys";
        public static Dictionary<string, string> usr_var = new Dictionary<string, string>();
        public static void store(string var, string contents)
        {
            usr_var.Add(var, contents);
        }
        public static string retrieve(string var)
        {
            
            if (usr_var.ContainsKey(var))
            {
                string content = usr_var[var];
                return content;
            }
            else
            {
                return "Value not found!";
            }
        }
        public static void readVars()
        {
            try
            {
                string[] vars = File.ReadAllLines(varsfile);
                foreach (string var in vars)
                {
                    string[] varcontent = var.Split(' ');
                    if (!usr_var.ContainsKey(var))
                    {
                        usr_var.Add(var, varcontent[1]);
                    }
                    else
                    {
                        Console.WriteLine("Variable already loaded: " + varcontent[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to retrieve variables");
                Console.WriteLine(ex.Message);
            }
            
        }
        public static void saveVars()
        {
            using (StreamWriter file = new StreamWriter(File.OpenWrite(varsfile)))
            {
                foreach (var entry in usr_var)
                {
                    file.WriteLine("{0} {1}", entry.Key, entry.Value);
                }
            }
        }
    }
}
