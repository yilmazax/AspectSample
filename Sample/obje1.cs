using LightInject;
using LightInject.Interception;
using SQLAttribute;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Sample
{
   public class obje1:interface1
    {

        
        public List<Bank> getBank(object surName, SqlConnection connection)
        {
            throw new NotImplementedException();
        }

        public List<long> getSurname(object surName, SqlConnection connection)
        {
            throw new NotImplementedException();
        }




    }
}
