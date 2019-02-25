using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Class_StoreProcedure_MSSQL_CSharp_EdClass.BLL
{
    public class Delete_students
    {
        public string DeleteStudents(int id)
        {
            DAL.CONNECTION obj = new DAL.CONNECTION();
            obj.Open_Connection();
            string message = "";
            var result = new SqlParameter("results", message)
            {
                SqlDbType = SqlDbType.VarChar,
                Size = 70,
                Direction = ParameterDirection.InputOutput
            };
            obj.Execute_Procedure("Delete_Students", new object[]
            {
                new SqlParameter("id", id),result
            });
            obj.Close_Connection();
            message = result.Value.ToString();
            return message;
        }
    }
}
