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
    public class AusentismosSolicitudesDA
    {
        LeerJson objJson = new LeerJson();
        LogEventosDA logDA = new LogEventosDA();
        string strConexionSQL = "";


        public AusentismosSolicitudesDA()
        {
            strConexionSQL = objJson.GetStrConexion();
        }
        public List<AusentismoSolicitud> AusentismosSolicitudesObtener(int id, int usuarioId)
        {
            DataSet ds = new DataSet();
            SqlConnection conexionSQL = new SqlConnection(strConexionSQL);
            SqlCommand comandoSQL = new SqlCommand();
            SqlDataAdapter adaptadorSQL = new SqlDataAdapter();
            List<AusentismoSolicitud> lst = new List<AusentismoSolicitud>();

            try
            {
                comandoSQL.Connection = conexionSQL;
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "sp_ausentismos_solicitudes_obtener";
                comandoSQL.Parameters.AddWithValue("@Id", id);
                comandoSQL.Parameters.AddWithValue("@UsuarioId", usuarioId);
                adaptadorSQL.SelectCommand = comandoSQL;
                adaptadorSQL.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            AusentismoSolicitud obj = new AusentismoSolicitud();
                            obj.Id = Convert.ToInt32(item["Id"].ToString());
                            obj.UsuarioId = Convert.ToInt32(item["UsuarioId"].ToString());
                            obj.AusentismoTipoId = Convert.ToInt32(item["AusentismoTipoId"].ToString());
                            obj.AusentismoTipoNombre = item["AusentismoTipoNombre"].ToString();
                            obj.FechaInicio = Convert.ToDateTime(item["FechaInicio"].ToString());
                            obj.FechaFin = Convert.ToDateTime(item["FechaFin"].ToString());
                            obj.FechaInicioStr = item["FechaInicioStr"].ToString();
                            obj.FechaFinStr = item["FechaFinStr"].ToString();
                            obj.HoraInicio =item["HoraInicio"].ToString();
                            obj.HoraFin = item["HoraFin"].ToString();
                            obj.Hora = item["Hora"].ToString();
                            obj.Descripcion = item["Descripcion"].ToString();
                            obj.ArchivoRuta = item["ArchivoRuta"].ToString();
                            obj.Estado = item["Estado"].ToString();
                            obj.EstadoDescripcion = item["EstadoDescripcion"].ToString();
                            obj.FechaRegistro = Convert.ToDateTime(item["FechaRegistro"].ToString());
                            obj.FechaRegistroStr = item["FechaRegistroStr"].ToString();
                            lst.Add(obj);
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

        public bool AusentismosSolicitudesIngresar(AusentismoSolicitud model)
        {
            SqlConnection conexionSQL = new SqlConnection(strConexionSQL);
            SqlCommand comandoSQL = new SqlCommand();

            try
            {
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "sp_ausentismos_solicitudes_ingresar";
                comandoSQL.Parameters.AddWithValue("@UsuarioId", model.UsuarioId);
                comandoSQL.Parameters.AddWithValue("@AusentismoTipoId", model.AusentismoTipoId);
                comandoSQL.Parameters.AddWithValue("@FechaInicio", model.FechaInicio);
                comandoSQL.Parameters.AddWithValue("@FechaFin", model.FechaFin);
                comandoSQL.Parameters.AddWithValue("@HoraInicio", model.HoraInicio);
                comandoSQL.Parameters.AddWithValue("@HoraFin", model.HoraFin);
                comandoSQL.Parameters.AddWithValue("@Descripcion", model.Descripcion);
                comandoSQL.Parameters.AddWithValue("@ArchivoRuta", model.ArchivoRuta);
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

        public bool AusentismosSolicitudesEditar(AusentismoSolicitud model)
        {
            SqlConnection conexionSQL = new SqlConnection(strConexionSQL);
            SqlCommand comandoSQL = new SqlCommand();

            try
            {
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "sp_ausentismos_solicitudes_editar";
                comandoSQL.Parameters.AddWithValue("@Id", model.Id);
                comandoSQL.Parameters.AddWithValue("@UsuarioId", model.UsuarioId);
                comandoSQL.Parameters.AddWithValue("@AusentismoTipoId", model.AusentismoTipoId);
                comandoSQL.Parameters.AddWithValue("@FechaInicio", model.FechaInicio);
                comandoSQL.Parameters.AddWithValue("@FechaFin", model.FechaFin);
                comandoSQL.Parameters.AddWithValue("@HoraInicio", model.HoraInicio);
                comandoSQL.Parameters.AddWithValue("@HoraFin", model.HoraFin);
                comandoSQL.Parameters.AddWithValue("@Descripcion", model.Descripcion);
                comandoSQL.Parameters.AddWithValue("@ArchivoRuta", model.ArchivoRuta);
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

        public bool AusentismosSolicitudesEliminar(int id)
        {
            SqlConnection conexionSQL = new SqlConnection(strConexionSQL);
            SqlCommand comandoSQL = new SqlCommand();

            try
            {
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "sp_ausentismos_solicitudes_eliminar";

                comandoSQL.Parameters.AddWithValue("@Id", id);
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
