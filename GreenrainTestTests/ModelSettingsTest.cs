using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WindowsFormsApplication1.Model;
using System.Configuration;
using WindowsFormsApplication1;
using System.IO;
using System.Windows.Forms;

namespace GreenrainTestTests
{
    [TestClass]
    public class ModelSettingsTest
    {
        IModelSettings model;

        [TestInitialize]
        public void PreTestInitialize()
        {
            model = new ModelSettings();
        }

        [TestMethod]
        public void SaveConnectionStringToConfigTest()
        {
            FileLogger fileLog = new FileLogger("TestLog.txt");
            string ConnectionStringTest = "Server=localhosttest;Integrated Security=true;Database=NORTHWND;User Id=sa;Password=";
            string Config = "TestConnectionString";

            bool IsSaved = model.SaveConnectionStringToConfig(ConnectionStringTest, Config);

            //verify saving connection string to config file
            Assert.AreEqual(ConfigurationManager.ConnectionStrings[Config].ConnectionString,
                ConnectionStringTest);
            Assert.IsTrue(IsSaved);
        }

        [TestMethod]
        public void LoadConnectionStringFromConfigTest()
        {
            string Config = "TestConnectionString";
            string ConnectionStringTest = ConfigurationManager.ConnectionStrings[Config].ConnectionString;

            string ConnectionString = model.LoadConnectionStringFromConfig(Config);
            //verify loading connection string from config
            Assert.AreEqual(ConnectionStringTest, ConnectionString);
        }

        [TestMethod]
        public void SaveNullConnectionStringToConfigTest()
        {
            string ConnectionStringTest = null;
            string Config = "TestConnectionString";

            bool IsSaved = model.SaveConnectionStringToConfig(ConnectionStringTest, Config);
            //if ConnectionString that should be saved is null, connection string in config should be empty string
            Assert.AreEqual(ConfigurationManager.ConnectionStrings[Config].ConnectionString,
                String.Empty);
            Assert.IsTrue(IsSaved);
        }

        [TestMethod]
        public void SaveNullConnectionStringToNullConfigTestAndAddExceptionToLog()
        {
            string ConnectionStringTest = null;
            string Config = null;
            //get length of file in bytes
            long size = GetSize();
            //impossible to save connection string to null config, saving will not happened
            bool IsSaved = model.SaveConnectionStringToConfig(ConnectionStringTest, Config);
            long sizeaftersave = GetSize();
            //if log file was changed exception added to log
            Assert.AreNotEqual(size, sizeaftersave);
            //function return false, ConnectionString doesn't saved
            Assert.IsFalse(IsSaved);
        }

        [TestMethod]
        public void LoadConnectionStringFromNullConfigTest()
        {
            IModelSettings model = new ModelSettings();
            string Config = null;
            //get length of file in bytes
            long size = GetSize();

            string ConnectionString = model.LoadConnectionStringFromConfig(Config);
            long sizeaftersave = GetSize();
            //if log file was changed exception added to log
            Assert.AreNotEqual(size, sizeaftersave);
            //if confiig is null, connection string cannot be loaded, function return empty string
            Assert.AreEqual(ConnectionString, "");
        }

        [TestMethod]
        public void LoadConnectionStringFromNonExistentConfigTest()
        {
            IModelSettings model = new ModelSettings();
            string Config = "Test";
            //get length of file in bytes
            long size = GetSize();

            string ConnectionString = model.LoadConnectionStringFromConfig(Config);
            long sizeaftersave = GetSize();
            //if log file was changed exception added to log
            Assert.AreNotEqual(size, sizeaftersave);
            //if confiig is nonexistent, connection string cannot be loaded, function return empty string
            Assert.AreEqual(ConnectionString, "");
        }

        private long GetSize()
        {
            FileInfo file = new FileInfo("TestLog.txt");
            return file.Length;
        }
    }
}
