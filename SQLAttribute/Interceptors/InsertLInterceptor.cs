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
    public class InsertLInterceptor : IInterceptor
    {

        protected InsertAttribute InsertAttribute;
        protected SqlConnection con = null;
        protected static readonly string connectionString;
        static InsertLInterceptor()
        {
            connectionString = System.Configuration
                            .ConfigurationManager
                            .ConnectionStrings["DbConnect"]
                            .ConnectionString;
        }


        public object Invoke(IInvocationInfo invocationInfo)
        {
            object result = null;
            InsertAttribute = invocationInfo.Method.GetCustomAttributes<InsertAttribute>().FirstOrDefault();
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

             result= method.Invoke(this, new object[1] { invocationInfo });

            return result;

        }


        

        IEnumerable<T> generic<T>(IInvocationInfo invocationInfo)
        {
            

            Type x = invocationInfo.Method.ReturnType;
            return con.Query<T>(sql: InsertAttribute.Table, param: invocationInfo.Arguments[0], commandType: System.Data.CommandType.Text, transaction: null);


        }
    }
}
