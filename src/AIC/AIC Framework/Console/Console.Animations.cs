﻿/*
Copyright (c) 2012-2013, dewitcher Team
Copyright (c) 2017, Apollo OS
Copyright (c) 2017, Cosmos

All rights reserved.

See in the /Licenses folder for the licenses for each respected project.
*/

using System;
using System.Collections.Generic;
using AIC.Core;

namespace AIC_Framework
{
    public static partial class AConsole
    {
        public static class Animation
        {
            public static void RollUp(uint mspause)
            {
                for (int i = 0; i < 26; i++)
                {
                    for (int j = 0; j < 81; j++)
                    {
                        AConsole.Write(" ");
                    }
                    AIC.Core.PIT.SleepMilliseconds(mspause);
                }
                AConsole.Clear();
            }
            public static void RollDown(uint mspause)
            {
                for (int i = 0; i < 26; i++)
                {
                    for (int j = 0; j < 81; j++)
                    {
                        AConsole.Write(" ");
                        AIC.Core.PIT.SleepMilliseconds(mspause);
                    }
                }
                AConsole.Clear();
            }
        }
    }
}
