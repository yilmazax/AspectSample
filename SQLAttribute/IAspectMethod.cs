using LightInject.Interception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLAttribute
{
   public  interface IAspectMethod
    {
        void OnEntry(IInvocationInfo invocationInfo);
        void OnSuccecs(IInvocationInfo invocationInfo);
        void OnExit(IInvocationInfo invocationInfo);



    }
}
