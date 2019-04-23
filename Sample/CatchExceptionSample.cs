
using SQLAttribute;
using System;


namespace Sample
{
    public class CatchExceptionSample : IException
    {
        private readonly ILogger logger;
        public CatchExceptionSample(ILogger logger)
        {
            this.logger = logger;
        }

        public CatchExceptionSample()
        {

        }

        public void CatchException(Exception exception)
        {
            logger.Error("CatchExceptionSample", exception);
        }
    }
}
