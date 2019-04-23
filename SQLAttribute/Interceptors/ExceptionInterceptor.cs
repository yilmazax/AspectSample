using Dapper;
using LightInject.Interception;
using SQLAttribute.Attributes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SQLAttribute
{
    public class ExceptionInterceptor : IInterceptor
    {



        private ExceptionAttribute exceptionAttribute;
        private IException exceptionClass;

        private readonly ILogger logger;

        public ExceptionInterceptor(ILogger Logger)
        {
            this.logger = Logger;
        }

        public object Invoke(IInvocationInfo invocationInfo)
        {

            try
            {
                exceptionAttribute = invocationInfo.Method.GetCustomAttributes<ExceptionAttribute>().FirstOrDefault();

                object returnValue = Activator.CreateInstance(invocationInfo.Method.ReturnType);

                exceptionClass = (exceptionAttribute.ExceptionClass == null) ? null : (IException)Activator.CreateInstance(exceptionAttribute.ExceptionClass, logger);
                try
                {
                    returnValue = invocationInfo.Proceed();
                }
                catch (Exception ex)
                {
                    if (exceptionClass == null)
                    {
                        logger.Error(invocationInfo.Method.Name, ex);
                    }
                    else
                    {
                        exceptionClass.CatchException(ex);
                    }

                }


                return returnValue;

            }
            catch (Exception ex)
            {

                logger.Error("", ex);

            }
            return null;
        }
    }
}
