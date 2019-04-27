using LightInject.Interception;
using System;
using System.Text;
using System.Linq;
using System.Reflection;


namespace SQLAttribute
{
    public class MethodAspectInterceptor : IInterceptor
    {

        private MethodBoundaryAspectAttribute method;
        private readonly ILogger logger;

        public MethodAspectInterceptor(ILogger Logger)
        {
            this.logger = Logger;
        }


        public object Invoke(IInvocationInfo invocationInfo)
        {
            object returnValue = null;
            Exception exception = null;
            method = invocationInfo.Method.GetCustomAttributes<MethodBoundaryAspectAttribute>().FirstOrDefault();
            if (method != null)
            {
                try
                {
                    method.OnEntry(invocationInfo);
                    returnValue = invocationInfo.Proceed();
                    method.OnSuccecs(invocationInfo, returnValue);

                }
                catch (Exception ex)
                {

                    exception = ex;
                }

                method.OnExit(invocationInfo, returnValue);
                if (exception!=null)
                {
                    throw exception;
                }
            }


            // Perform logic after invoking the target method

            return returnValue;

        }




    }
}

