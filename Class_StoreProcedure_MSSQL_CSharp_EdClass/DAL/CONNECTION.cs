using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;// dataset 
using System.Data.SqlClient;//sqlconnection

namespace Class_StoreProcedure_MSSQL_CSharp_EdClass.DAL
{
    public class CONNECTION
    {
        /* ---------------------- Connection DB Area ---------------------- */
        /* ---------------------- Área de conexión a BD ---------------------- */

        #region ConnectionDB/ConectarBD
        private SqlConnection stringconnection = new SqlConnection("Data Source=yourserver; Initial Catalog=yourDBA; User ID=youruser; Password=yourpassword");
        public void Open_Connection()
        {
            try
            {
                stringconnection.Open();
            }
            catch (Exception ex)
            {

                throw new Exception("Error when connecting to the Database, Error Detail." + ex.Message);
            }
        }
        public void Close_Connection()
        {
            try
            {
                this.stringconnection.Close(); 
                this.stringconnection.Dispose(); 
                this.stringconnection = null;
            }
            catch (Exception ex)
            {

                throw new Exception("Error when disconnecting the Database, Detail of the Error" + ex.Message);
            }
        }
        #endregion

        /* ---------------------- Query Building Area ---------------------- */
        /* ---------------------- Área de construcción de consultas ---------------------- */

        #region Simple Query (select) / Consulta simple (select)
        public DataTable simple_query(string SQLQuery)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(SQLQuery, stringconnection);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {

                throw new Exception("Failure to consult data, detail of the error: " + ex.Message);
            }
        }
        #endregion

        #region Store Procedure Query / Procedimiento almacenado de consulta
        public DataTable Query_Procedure(string storeprocedure, object[] parameters)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(storeprocedure, stringconnection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter parametro in parameters)
                {
                    da.SelectCommand.Parameters.Add((SqlParameter)parametro);
                }
                DataSet ds = new DataSet();
                da.Fill(ds); 
                return ds.Tables[0];
            }
            catch (Exception ex)
            {

                throw new Exception("Failure to consult data, detail of the error: " + ex.Message);
            }
        }
        #endregion

        #region Execute Procedure / Ejecutar procedimiento Insert, update, delete
        public int Execute_Procedure(string storeprocedure, object[] parameters)
        {
            // string stringdatas = "";
            try
            {
                SqlCommand cm = new SqlCommand(storeprocedure);
                cm.CommandType = CommandType.StoredProcedure;
                cm.Connection = stringconnection;

                foreach (SqlParameter parameter in parameters)
                {
                    //parametro.Direction = ParameterDirection.InputOutput;
                    cm.Parameters.Add((SqlParameter)parameter);
                }
                return cm.ExecuteNonQuery();
                //  return stringdatas; 
            }
            catch (Exception ex)
            {
                throw new Exception("Error executing the Transaction, detail of the error: " + ex.Message); ;
            }
        }
        #endregion

    }
}
