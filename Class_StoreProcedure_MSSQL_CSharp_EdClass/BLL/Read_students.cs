using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; 
using System.Data.SqlClient;

namespace Class_StoreProcedure_MSSQL_CSharp_EdClass.BLL
{
    public class Read_students
    {
        public DataTable ReadStudents()
        {
            DAL.CONNECTION obj = new DAL.CONNECTION();
            obj.Open_Connection();
            DataTable MyQuery = obj.Query_Procedure("read_sp_students", new object[]{ });
            obj.Close_Connection();
            return MyQuery;
        }

        public DataTable ReadNotes()
        {
            DAL.CONNECTION obj = new DAL.CONNECTION();
            obj.Open_Connection();
            DataTable MyQuery = obj.simple_query("select name,course, note from information");
            obj.Close_Connection();
            return MyQuery;
        }


    }
}
