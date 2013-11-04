using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

namespace Service
{
    public class Logger
    {
        public static Logger Instance { get; private set; }

        static Logger()
        {
            XmlConfigurator.Configure();

            Instance = new Logger("Application.Default");
        }

        private readonly ILog defaultLogger;
        private readonly ILog debugLogger;
        private readonly ILog infoLogger;
        private readonly ILog warnLogger;
        private readonly ILog errorLogger;
        private readonly ILog fatalLogger;

        public Logger(string name)
        {
            defaultLogger = LogManager.GetLogger(name);

            debugLogger = LogManager.Exists("Application.Debug") ?? defaultLogger;
            infoLogger = LogManager.Exists("Application.Info") ?? defaultLogger;
            warnLogger = LogManager.Exists("Application.Warn") ?? defaultLogger;
            errorLogger = LogManager.Exists("Application.Error") ?? defaultLogger;
            fatalLogger = LogManager.Exists("Application.Fatal") ?? defaultLogger;
        }
        
        public void Write(Exception ex, LogType type, params object[] args)
        {
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }

            Write(ex.Message, type, args);
        }

        private void Write(string message, LogType type, params object[] args)
        {
            switch (type)
            {
                case LogType.Debug:
                    debugLogger.DebugFormat(message, args);
                    break;

                case LogType.Info:
                    infoLogger.InfoFormat(message, args);
                    break;

                case LogType.Warn:
                    warnLogger.WarnFormat(message, args);
                    break;

                case LogType.Error:
                    errorLogger.ErrorFormat(message, args);
                    break;

                case LogType.Fatal:
                    fatalLogger.FatalFormat(message, args);
                    break;
            }
        }

        public void Info(string message)
        {
            infoLogger.Info(message);
        }
    }

    public enum LogType
    {
        Debug,
        Info,
        Warn,
        Error,
        Fatal
    }
}
