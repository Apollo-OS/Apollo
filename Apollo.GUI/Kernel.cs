using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.System.Graphics;

namespace Apollo.GUI
{
    public class Kernel: Sys.Kernel
    {
		Canvas desktop;
        protected override void BeforeRun()
        {
			desktop = FullScreenCanvas.GetFullScreenCanvas();
            Console.WriteLine("Cosmos booted successfully. Type a line of text to get it echoed back.");
        }
        
        protected override void Run()
        {
            Console.Write("Input: ");
            var input = Console.ReadLine();
            Console.Write("Text typed: ");
            Console.WriteLine(input);
        }
    }
}
