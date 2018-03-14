﻿/*
Copyright (c) 2012-2013, dewitcher Team
Copyright (c) 2017, Apollo OS
Copyright (c) 2017, Cosmos

All rights reserved.

See in the /Licenses folder for the licenses for each respected project.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIC.Core
{
    public unsafe class Heap
    {
        public static void MemAlloc(uint length)
        {
            Cosmos.Core.Memory.Heap.Alloc(length);
        }
    }
    public class GetRAM
    {
        public static uint GetAmountOfRAM = Cosmos.Core.CPU.GetAmountOfRAM();
    }
}
