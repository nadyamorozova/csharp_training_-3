﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using addressbook_webtest;

namespace addressbook_webtest
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            StreamWriter writer = new StreamWriter(args[1]);
            for (int i = 0; i < count; i++)
            {
                writer.WriteLine(String.Format("$(0), $(1), $(2)",
                TestBase.GenerateRandomString(10),
                TestBase.GenerateRandomString(100),
                TestBase.GenerateRandomString(100)));
            }
            writer.Close();
        }
    }
}