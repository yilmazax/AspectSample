using SQLAttribute;
using SQLAttribute.Attributes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Sample
{
    public interface interface1
    {
        [SampleMethodBoundaryAspect]
           [Logging]
        [Exception]
        [Query(CommandText = "GetSeqNextValue", CommandType = System.Data.CommandType.StoredProcedure)]
        List<long> getSurname(Object surName, SqlConnection connection);


        [Logging]


        [Exception(ExceptionClass = typeof(CatchExceptionSample))]
        [Query(CommandText = "spr_Bank_Get", CommandType = System.Data.CommandType.StoredProcedure)]
        List<Bank> getBank(Object surName, SqlConnection connection);
    }
}
