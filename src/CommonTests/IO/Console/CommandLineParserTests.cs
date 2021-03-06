﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.IO.Console.Tests
{
    [TestClass()]
    public class CommandLineParserTests
    {
        [TestMethod()]
        public void ParseArgsTest()
        {
         

            AgentCommandLineOptions expectedOptions = new AgentCommandLineOptions
            {
                Address = "172.16.254.1",
                Port = 666
            };

            //"17-PL-01",
            string[] args = new[] { "--address", "172.16.254.1", "--port", "666" };
           // ICommandLineOptions commandLineOptions = ;
            AgentCommandLineOptions options = CommandLineParser.ParseArgs<AgentCommandLineOptions>(args, new AgentCommandLineOptions());

            Assert.AreEqual(expectedOptions.Address, options.Address);
            Assert.AreEqual(expectedOptions.Port, options.Port);
        }
    }
}