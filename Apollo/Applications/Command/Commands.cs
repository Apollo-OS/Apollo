using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo.Applications.Commands
{
    public abstract class Command
    {
        string help;
        string cmdName;
        void Help()
        {
            Console.WriteLine(this.cmdName + ":");
        }
        void Run()
        {

        }
    }
}
