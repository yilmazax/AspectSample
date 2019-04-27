

using System;
using LightInject.Interception;

namespace SQLAttribute
{
    [AttributeUsage(AttributeTargets.Method)]
    public abstract class MethodBoundaryAspectAttribute : System.Attribute
    {
        public virtual void OnEntry(IInvocationInfo invocationInfo) { }

        public virtual  void OnExit(IInvocationInfo invocationInfo, object returnValue) { }

        public virtual void OnSuccecs(IInvocationInfo invocationInfo, object returnValue) { }
    }


}
