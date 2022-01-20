using ZeroPapel.Server.Helper;
using ZeroPapel.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ZeroPapel.Server.Data
{
    public class LogEventosDA
    {
        LeerJson objJson = new LeerJson();
        string strConexionSQL = "";

        public LogEventosDA()
        {
            strConexionSQL = objJson.GetStrConexion();
        }


        public List<LogEvento> LogEventosObtener()
        {
            DataSet ds = new DataSet();
            SqlConnection conexionSQL = new SqlConnection(strConexionSQL);
            SqlCommand comandoSQL = new SqlCommand();
            SqlDataAdapter adaptadorSQL = new SqlDataAdapter();
            List<LogEvento> lst = new List<LogEvento>();

            try
            {
                comandoSQL.Connection = conexionSQL;
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "sp_log_eventos_obtener";
                //comandoSQL.Parameters.AddWithValue("@EmpresaId", empresaId);
                adaptadorSQL.SelectCommand = comandoSQL;
                adaptadorSQL.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            LogEvento log = new LogEvento();
                            //log.Id = Convert.ToInt32(item["Id"].ToString());
                            log.Fecha = Convert.ToDateTime(item["Fecha"].ToString());
                            log.Mensaje = item["Mensaje"].ToString();
                            log.Fuente = item["Fuente"].ToString();
                            log.Seguimiento = item["Seguimiento"].ToString();
                            log.Estado = Convert.ToBoolean(item["Estado"].ToString());
                            lst.Add(log);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                LogEventoIngresar(ex);
            }
            finally
            {
                comandoSQL.Parameters.Clear();
                comandoSQL.Connection.Close();
            }



            return lst;
        }


        public bool LogEventoIngresar(Exception ex)
        {
            LogEvento model = new LogEvento();
            model.Mensaje = ex.Message;
            model.Fuente = ex.Source;
            model.Seguimiento = ex.StackTrace;
            model.Estado = false;


            if (model.Fuente == null)
            {
                model.Fuente = "";
            }
            if (model.Seguimiento == null)
            {
                model.Seguimiento = "";
            }
            SqlConnection conexionSQL = new SqlConnection(strConexionSQL);
            SqlCommand comandoSQL = new SqlCommand();

            try
            {
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "sp_log_eventos_ingresar";
                comandoSQL.Parameters.AddWithValue("@Mensaje", model.Mensaje);
                comandoSQL.Parameters.AddWithValue("@Fuente  ", model.Fuente);
                comandoSQL.Parameters.AddWithValue("@Seguimiento", model.Seguimiento);
                comandoSQL.Parameters.AddWithValue("@Estado", model.Estado);

                comandoSQL.Connection = conexionSQL;
                comandoSQL.Connection.Open();
                comandoSQL.ExecuteNonQuery();

            }
            catch (Exception exe)
            {
                LogEventoIngresar(exe);
                return false;
            }
            finally
            {
                comandoSQL.Parameters.Clear();
                comandoSQL.Connection.Close();
            }
            return true;
        }
    }
}