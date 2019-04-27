using LightInject.Interception;
using SQLAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{
    class SampleMethodBoundaryAspectAttribute: MethodBoundaryAspectAttribute
    {
        public override void OnEntry(IInvocationInfo invocationInfo)
        {
            base.OnEntry(invocationInfo);
        }
    }
}
