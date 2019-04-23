using System;

namespace SQLAttribute
{
    public class LoggerLog4Net : ILogger
    {
        protected static readonly log4net.ILog Logger;
        static LoggerLog4Net()
        {
            //özge
            //config bilgilerini ayrı bir config dosyası içinden yaparsa bu satıt açılacak
            //log4net.Config.XmlConfigurator.Configure(new FileInfo(string.Concat(AppDomain.CurrentDomain.BaseDirectory, "config\\Log4Net.config")));

            //özge
            //config bilgilerini ayırmadığım için bu satır ile configure ettim
            log4net.Config.XmlConfigurator.Configure();

            //Logger = log4net.LogManager.GetLogger(typeof(BaseTest));
            Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            Logger.Debug("Test");
        }

        public void Debug(string message)
        {
            Logger.Debug(message);
        }

        public void Error(string message, Exception exception = null)
        {
            Logger.Error(message, exception);
        }

        public void Fatal(string message, Exception exception = null)
        {
            Logger.Fatal(message, exception);
        }

        public void Info(string message)
        {
            throw new NotImplementedException();
        }

        public void Warn(string message)
        {
            throw new NotImplementedException();
        }

        public void WriteToCategory(object data, string category)
        {
            throw new NotImplementedException();
        }
    }
}