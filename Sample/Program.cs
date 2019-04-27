using SQLAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LightInject;
using LightInject;
using LightInject.Interception;
using System.Data.SqlClient;
using SQLAttribute.Attributes;

namespace Sample
{

    class Program
    {
        public static void DefineProxyType(ProxyDefinition proxyDefinition, IServiceContainer container)
        {
            // ILogger logger = new LoggerLog4Net();// container.GetInstance<ILogger>();
            proxyDefinition.Implement(() => new ExceptionInterceptor(container.GetInstance<ILogger>()), m => m.GetCustomAttributes(typeof(ExceptionAttribute), true).Count() > 0);
            
            proxyDefinition.Implement(() => new MethodAspectInterceptor(container.GetInstance<ILogger>()), m => m.GetCustomAttributes(typeof(MethodBoundaryAspectAttribute), true).Count() > 0);
            proxyDefinition.Implement(() => new LoggingInterceptor(container.GetInstance<ILogger>()), m => m.GetCustomAttributes(typeof(LoggingAttribute), true).Count() > 0);
            proxyDefinition.Implement(() => new SQLInterceptor(), m => m.GetCustomAttributes(typeof(QueryAttribute), true).Count() > 0);

        }

        static void Main(string[] args)
        {
            var connection =
System.Configuration.ConfigurationManager.
ConnectionStrings["DbConnect"].ConnectionString;

            var container = new LightInject.ServiceContainer();
            container.Register<interface1, obje1>();
            container.Register<interface2, obje2>();
            container.Register<IInterceptor, SQLInterceptor>();
            container.Register<IInterceptor, LoggingInterceptor>("Logging");
            container.Register<ILogger, LoggerLog4Net>();
            container.EnableAnnotatedPropertyInjection();
            //       container.Intercept(sr => true, factory => factory.GetInstance<IInterceptor>());
            //      container.Intercept(sr => true, factory => factory.GetInstance<IInterceptor>("Logging"));


            container.Intercept(sr => true, (sf, pd) => DefineProxyType(pd, container));




            interface1 obj1 = container.GetInstance<interface1>();

            SqlConnection con = new SqlConnection(connection);

            List<long> sonucattribute = obj1.getSurname(surName: new { SeqName = "CountBy1" }, connection: con);
            List<Bank> sonucattribute2 = obj1.getBank(surName: new { BankId = 2 }, connection: con);
            List<Bank> sonucattribute3 = obj1.getBank(surName: new { BankId = 1 }, connection: con);
            List<Bank> sonucattribute4 = obj1.getBank(surName: new { BankId = 3 }, connection: con);
            List<Bank> sonucattribute5 = obj1.getBank(surName: new { w = 2 }, connection: con);


            Console.WriteLine("");
        }


    }
}
