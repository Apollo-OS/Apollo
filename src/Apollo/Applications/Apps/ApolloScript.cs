using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Apollo.Apps
{
    public class ApolloScript : Command
    {
        public new static string cmdName;
        public new string help = cmdName + " ";
        /// <summary>
        /// Executes a script passed to the application,
        /// parsing the commands listed in a valid text file
        /// that has the extension '.mds'
        /// </summary>
        /// <param name="scriptname"></param>
        public static void Help()
        {
            
        }
        public static void Run(string scriptname)
        {
            try
            {
                if (scriptname.EndsWith(".as"))
                {
                    string[] lines = File.ReadAllLines(scriptname);
                    foreach (string line in lines)
                    {
                        Shell.prompt(line);
                        //Console.WriteLine("");
                    }
                }
                else
                {
                    Console.WriteLine("Not a valid Apolloscript file.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
