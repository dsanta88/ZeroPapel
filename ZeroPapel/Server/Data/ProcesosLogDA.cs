using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ZeroPapel.Server.Helper;
using ZeroPapel.Shared;

namespace ZeroPapel.Server.Data
{
    public class ProcesosLogDA
    {

        LeerJson objJson = new LeerJson();
        LogEventosDA logDA = new LogEventosDA();
        string strConexionSQL = "";


        public ProcesosLogDA()
        {
            strConexionSQL = objJson.GetStrConexion();
        }


        public List<ProcesoLog> ProcesosLogObtener(int empresaId, int id)
        {
            DataSet ds = new DataSet();
            SqlConnection conexionSQL = new SqlConnection(strConexionSQL);
            SqlCommand comandoSQL = new SqlCommand();
            SqlDataAdapter adaptadorSQL = new SqlDataAdapter();
            List<ProcesoLog> lst = new List<ProcesoLog>();

            try
            {
                comandoSQL.Connection = conexionSQL;
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "sp_procesos_log_obtener";
                comandoSQL.Parameters.AddWithValue("@EmpresaId", empresaId);
                comandoSQL.Parameters.AddWithValue("@Id", id);
                adaptadorSQL.SelectCommand = comandoSQL;
                adaptadorSQL.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            ProcesoLog log = new ProcesoLog();
                            log.Id = Convert.ToInt32(item["Id"].ToString());
                            log.EmpresaId = Convert.ToInt32(item["EmpresaId"].ToString());
                            log.ProcesoCodigo = Convert.ToInt32(item["ProcesoCodigo"].ToString());
                            log.ProcesoNombre = item["ProcesoNombre"].ToString();
                            log.Campo1 = item["Campo1"].ToString();
                            log.Campo2 = item["Campo2"].ToString();
                            log.Campo3 = item["Campo3"].ToString();
                            log.Campo4 = item["Campo4"].ToString();
                            log.Campo5 = item["Campo5"].ToString();
                            log.Campo6 = item["Campo6"].ToString();
                            log.Campo7 = item["Campo7"].ToString();
                            log.Campo8 = item["Campo8"].ToString();
                            log.Campo9 = item["Campo9"].ToString();
                            log.Campo10 = item["Campo10"].ToString();
                            log.Estado = Convert.ToInt32(item["Estado"].ToString());
                            log.EstadoDescripcion = item["EstadoDescripcion"].ToString();
                            log.UsuarioRegistroId = Convert.ToInt32(item["UsuarioRegistroId"].ToString());
                            log.UsuarioRegistroNombre = item["UsuarioRegistroNombre"].ToString();
                            log.FechaRegistro = Convert.ToDateTime(item["FechaRegistro"].ToString());
                            lst.Add(log);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                logDA.LogEventoIngresar(ex);
            }
            finally
            {
                comandoSQL.Parameters.Clear();
                comandoSQL.Connection.Close();
            }



            return lst;
        }

        public bool ProcesosLogIngresar(ProcesoLog model)
        {
            SqlConnection conexionSQL = new SqlConnection(strConexionSQL);
            SqlCommand comandoSQL = new SqlCommand();

            try
            {
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "sp_procesos_log_ingresar";
                comandoSQL.Parameters.AddWithValue("@EmpresaId", model.EmpresaId);
                comandoSQL.Parameters.AddWithValue("@ProcesoCodigo", model.ProcesoCodigo);
                comandoSQL.Parameters.AddWithValue("@Campo1", model.Campo1);
                comandoSQL.Parameters.AddWithValue("@Campo2", model.Campo2);
                comandoSQL.Parameters.AddWithValue("@Campo3", model.Campo3);
                comandoSQL.Parameters.AddWithValue("@Campo4", model.Campo4);
                comandoSQL.Parameters.AddWithValue("@Campo5", model.Campo5);
                comandoSQL.Parameters.AddWithValue("@Campo6", model.Campo6);
                comandoSQL.Parameters.AddWithValue("@Campo7", model.Campo7);
                comandoSQL.Parameters.AddWithValue("@Campo8", model.Campo8);
                comandoSQL.Parameters.AddWithValue("@Campo9", model.Campo9);
                comandoSQL.Parameters.AddWithValue("@Campo10", model.Campo10);
                comandoSQL.Parameters.AddWithValue("@Estado", model.Estado);
                comandoSQL.Parameters.AddWithValue("@UsuarioRegistroId", model.UsuarioRegistroId);
                comandoSQL.Connection = conexionSQL;
                comandoSQL.Connection.Open();
                comandoSQL.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                LogEventosIngresar(ex);
                return false;
            }
            finally
            {
                comandoSQL.Parameters.Clear();
                comandoSQL.Connection.Close();
            }

            return true;
        }
        public bool LogEventosIngresar(Exception ex)
        {
            logDA.LogEventoIngresar(ex);
            return true;
        }

    }
}
