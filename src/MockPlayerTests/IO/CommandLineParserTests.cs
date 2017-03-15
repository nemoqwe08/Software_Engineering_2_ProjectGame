﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockPlayer.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockPlayer.IO.Tests
{
    [TestClass()]
    public class CommandLineParserTests
    {
        [TestMethod()]
        public void ParseArgsTest()
        {
            CommandLineOptions expectedOptions = new CommandLineOptions
            {
                Address = "172.16.254.1",
                Port = 666
            };

            //"17-PL-01",
            string[] args = new[] {"--address", "172.16.254.1", "--port", "666" };
            CommandLineOptions options = CommandLineParser.ParseArgs(args);

            Assert.AreEqual(expectedOptions.Address, options.Address);
            Assert.AreEqual(expectedOptions.Port, options.Port);
        }
    }
}