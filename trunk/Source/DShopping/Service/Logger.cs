using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Service
{
    public class Logger
    {
        private static Logger _logger;

        private Logger(){}

        public void log(String _logMessage)
        {
            logFile(_logMessage);
        }
        private void logFile(string _logMessage)
        {
            try
            {
                String fileName = DateTime.Today.Year + "" + DateTime.Today.Month + "" + DateTime.Today.Day;
                String fileLoc = @"C://Log//" + fileName + ".txt";
                FileStream fs = null;
                if (!File.Exists(fileLoc))
                {
                    fs = File.Create(fileLoc);
                }
                StreamWriter sw = new StreamWriter(fileLoc);
                sw.Write( _logMessage);
                sw.Flush();
                sw.Close();
            }
            catch (Exception e)
            {


            }
        }

        private void logDb(string _logMessage)
        {

        }

        private void log4Net(string _logMessage)
        {
            
        }
        public static Logger getInstance()
        {
            if (_logger == null)
            {
                _logger = new Logger();
                
            }
            return _logger;
        }
    }
}
