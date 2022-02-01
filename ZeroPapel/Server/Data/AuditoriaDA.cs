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
    public class AuditoriaDA
    {
        LeerJson objJson = new LeerJson();
        LogEventosDA logDA = new LogEventosDA();
        string strConexionSQL = "";

        public AuditoriaDA()
        {
            strConexionSQL = objJson.GetStrConexion();
        }
        public List<Auditoria> AuditoriaObtener(int empresaId, int id)
        {
            DataSet ds = new DataSet();
            SqlConnection conexionSQL = new SqlConnection(strConexionSQL);
            SqlCommand comandoSQL = new SqlCommand();
            SqlDataAdapter adaptadorSQL = new SqlDataAdapter();
            List<Auditoria> lst = new List<Auditoria>();

            try
            {
                comandoSQL.Connection = conexionSQL;
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "sp_auditoria_obtener";
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
                            Auditoria log = new Auditoria();
                            log.Id = Convert.ToInt32(item["Id"].ToString());
                            log.EmpresaId = Convert.ToInt32(item["EmpresaId"].ToString());
                            log.Accion = item["Accion"].ToString();
                            log.Mensaje = item["Mensaje"].ToString();
                            log.Campo1 = item["Campo1"].ToString();
                            log.Campo2 = item["Campo2"].ToString();
                            log.Campo3 = item["Campo3"].ToString();
                            log.Campo4 = item["Campo4"].ToString();
                            log.Campo5 = item["Campo5"].ToString();
                            log.Tabla = item["Tabla"].ToString();
                            log.Usuario = item["Usuario"].ToString();
                            log.UsuarioNombre = item["UsuarioNombre"].ToString();
                            log.UsuarioRegistroId = Convert.ToInt32(item["UsuarioRegistroId"].ToString());
                            log.FechaRegistro = Convert.ToDateTime(item["FechaRegistro"].ToString());
                            lst.Add(log);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                LogEventosIngresar(ex);
            }
            finally
            {
                comandoSQL.Parameters.Clear();
                comandoSQL.Connection.Close();
            }



            return lst;
        }


        public bool AuditoriaIngresar(Auditoria model)
        {
     
            SqlConnection conexionSQL = new SqlConnection(strConexionSQL);
            SqlCommand comandoSQL = new SqlCommand();

            try
            {
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "sp_auditoria_ingresar";
                comandoSQL.Parameters.AddWithValue("@EmpresaId", model.EmpresaId);
                comandoSQL.Parameters.AddWithValue("@Accion  ", model.Accion);
                comandoSQL.Parameters.AddWithValue("@Mensaje", model.Mensaje);
                comandoSQL.Parameters.AddWithValue("@Campo1", model.Campo1);
                comandoSQL.Parameters.AddWithValue("@Campo2", model.Campo2);
                comandoSQL.Parameters.AddWithValue("@Campo3", model.Campo3);
                comandoSQL.Parameters.AddWithValue("@Campo4", model.Campo4);
                comandoSQL.Parameters.AddWithValue("@Campo5", model.Campo5);
                comandoSQL.Parameters.AddWithValue("@Tabla", model.Tabla);
                comandoSQL.Parameters.AddWithValue("@Usuario", model.Usuario);
                comandoSQL.Parameters.AddWithValue("@UsuarioNombre", model.UsuarioNombre);
                comandoSQL.Parameters.AddWithValue("@UsuarioRegistroId", model.UsuarioRegistroId);

                comandoSQL.Connection = conexionSQL;
                comandoSQL.Connection.Open();
                comandoSQL.ExecuteNonQuery();

            }
            catch (Exception exe)
            {
                LogEventosIngresar(exe);
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
