using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Class_StoreProcedure_MSSQL_CSharp_EdClass.BLL
{
    public class Update_students
    {

        public string UpdateStudents(int id,string name, string last, string section, string course, int note, string state)
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
            obj.Execute_Procedure("Update_Students", new object[]
            {
                new SqlParameter("id", id), new SqlParameter("name", name), new SqlParameter("lastname", last), new SqlParameter("section", section),
                new SqlParameter("course", course), new SqlParameter("note", note), new SqlParameter("state",state),result
            });
            obj.Close_Connection();
            message = result.Value.ToString();
            return message;
        }

    }
}
