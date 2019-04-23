using Dapper;
using LightInject.Interception;
using SQLAttribute.Attributes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;


namespace SQLAttribute
{
    public class SQLInterceptor : IInterceptor
    {

        private QueryAttribute QueryAttribute;
        private SqlConnection con = null;
        private static readonly string connectionString;
        static SQLInterceptor()
        {
            connectionString = System.Configuration
                            .ConfigurationManager
                            .ConnectionStrings["DbConnect"]
                            .ConnectionString;
        }


        public object Invoke(IInvocationInfo invocationInfo)
        {
            object result = null;
            QueryAttribute = invocationInfo.Method.GetCustomAttributes<QueryAttribute>().FirstOrDefault();

            if (QueryAttribute != null)
            {
                Type x = invocationInfo.Method.ReturnType;
                con = (SqlConnection)invocationInfo.Arguments.Where(t => t.GetType().Equals(typeof(SqlConnection))).FirstOrDefault();
                x = (x.IsGenericType && x.GetGenericTypeDefinition() == typeof(List<>))
                           ? x.GetGenericArguments()[0]
                           : x;

                MethodInfo method = this.GetType().GetMethod("generic",
                                BindingFlags.Instance | BindingFlags.NonPublic,
                                null,
                                new Type[] { typeof(IInvocationInfo) },
                                null);

                method = method.MakeGenericMethod(new Type[1] { x });
                con = con ?? new SqlConnection(connectionString);

                result = method.Invoke(this, new object[1] { invocationInfo });



            }
            return result;
        }



        IEnumerable<T> generic<T>(IInvocationInfo invocationInfo)
        {


            Type x = invocationInfo.Method.ReturnType;
            return con.Query<T>(sql: QueryAttribute.CommandText, param: invocationInfo.Arguments[0], commandType: QueryAttribute.CommandType, transaction: null);


        }
    }
}
