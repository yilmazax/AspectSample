using LightInject.Interception;
using System;
using System.Text;
using System.Linq;
using System.Reflection;


namespace SQLAttribute
{
    public class LoggingInterceptor : IInterceptor
    {

        private LoggingAttribute logging;
        private readonly ILogger logger;

        public LoggingInterceptor(ILogger Logger)
        {
            this.logger = Logger;
        }


        public object Invoke(IInvocationInfo invocationInfo)
        {
            logging = invocationInfo.Method.GetCustomAttributes<LoggingAttribute>().FirstOrDefault();
            StringBuilder sb = null;
            DateTime startTime = DateTime.Now;
            if (logging != null)
            {

                sb = new StringBuilder(string.Concat("Start Method Name:"
                                                   , invocationInfo.Method.Name
                                                   , " Parameters"
                                                   , string.Join(" , ", invocationInfo.Arguments)));
            }

            var returnValue = invocationInfo.Proceed();
            // Perform logic after invoking the target method
            if (logging != null)
            {
                sb.Append(String.Concat(" Time ", (DateTime.Now - startTime).Milliseconds, " Start Method Name:"
                                                , invocationInfo.Method.Name));
                logger.Debug(sb.ToString());
            }

            return returnValue;

        }




    }
}

