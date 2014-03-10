using System;
using System.IO;
using System.Text;

namespace WindowsFormsApplication1
{
    public abstract class Logger
    {
        public Logger()
        {
            Log.OnLogHandler += new Log.LogEventHandler(LogMessage);
        }

        public abstract void LogMessage(string Message);
    }

    /// 
    /// Save logs to file
    /// 

    public class FileLogger : Logger
    {
        string FileName = "";
        public FileLogger(string fileName)
            : base()
        {
            if (fileName == null) fileName = "";
            FileName = fileName;
            if (!File.Exists(fileName) && fileName != "") File.AppendAllText(FileName, DateTime.Now + ": Log file was created." + Environment.NewLine, Encoding.GetEncoding("Windows-1251"));
        }

        public override void LogMessage(string Message)
        {
            if (Message == null) Message = "";
            File.AppendAllText(FileName, DateTime.Now + ": " + Message + Environment.NewLine, Encoding.GetEncoding("Windows-1251"));
        }
    }

    /// 
    /// Global variant 
    /// 

    public class Log
    {
        /// 
        /// property and delegate
        /// 

        public delegate void LogEventHandler(string Message);
        static public event LogEventHandler OnLogHandler;

        /// 
        /// User functions
        /// 

        static public void WriteLine(string Message)
        {
            if (OnLogHandler != null)
            {
                if (Message == null) Message = "";
                OnLogHandler(Message);
            }
        }
    }

}
