using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
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
        public List<AusentismoSolicitud> AusentismosSolicitudesObtener(int id, int usuarioId, int jefeUsuarioId)
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
                comandoSQL.Parameters.AddWithValue("@JefeUsuarioId", jefeUsuarioId);
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
                            obj.JefeUsuarioId = Convert.ToInt32(item["JefeUsuarioId"].ToString());
                            obj.AusentismoTipoId = Convert.ToInt32(item["AusentismoTipoId"].ToString());
                            obj.AusentismoTipoNombre = item["AusentismoTipoNombre"].ToString();
                            obj.FechaInicio = Convert.ToDateTime(item["FechaInicio"].ToString());
                            obj.FechaFin = Convert.ToDateTime(item["FechaFin"].ToString());
                            obj.FechaInicioStr = obj.FechaInicio.ToString("d MMMM yyyy h:mm tt", CultureInfo.CreateSpecificCulture("es-MX"));
                            obj.FechaFinStr = obj.FechaFin.ToString("d MMMM yyyy h:mm tt", CultureInfo.CreateSpecificCulture("es-MX"));
                            obj.Descripcion = item["Descripcion"].ToString();
                            obj.ArchivoRuta = item["ArchivoRuta"].ToString();
                            obj.FechaSolicitud = Convert.ToDateTime(item["FechaSolicitud"].ToString());
                            obj.FechaSolicitudStr = obj.FechaSolicitud.ToString("d MMMM yyyy h:mm tt", CultureInfo.CreateSpecificCulture("es-MX"));
                            obj.JefeEstado = item["JefeEstado"].ToString();
                            obj.JefeEstadoDescripcion = item["JefeEstadoDescripcion"].ToString();
                            if (item["JefeFecha"]!=null)
                            {
                                try
                                {
                                    obj.JefeFecha = Convert.ToDateTime(item["JefeFecha"].ToString());
                                }
                                catch (Exception ex)
                                {
                                    obj.JefeFecha = null;
                                }
                            
                            }
                            obj.JefeUsuarioRegistroId = Convert.ToInt32(item["JefeUsuarioRegistroId"].ToString());
                            obj.JefeObservacion = item["JefeObservacion"].ToString();
                            obj.GhEstado = item["GhEstado"].ToString();
                            obj.GhEstadoDescripcion = item["GhEstadoDescripcion"].ToString();
                            if (item["GhFecha"] != null)
                            {
                                try
                                {
                                    obj.GhFecha = Convert.ToDateTime(item["GhFecha"].ToString());
                                }
                                catch (Exception ex)
                                {
                                    obj.GhFecha = null;
                                }
                            }
                            obj.GhObservacion = item["GhObservacion"].ToString();
                            obj.GhUsuarioRegistroId = Convert.ToInt32(item["GhUsuarioRegistroId"].ToString());
                        
                            //obj.FechaRegistroStr = obj.FechaRegistro.ToString("d MMMM yyyy h:mm tt", CultureInfo.CreateSpecificCulture("es-MX"));
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
                comandoSQL.Parameters.AddWithValue("@Descripcion", model.Descripcion);
                comandoSQL.Parameters.AddWithValue("@ArchivoRuta", model.ArchivoRuta);
                comandoSQL.Parameters.AddWithValue("@JefeEstado", model.JefeEstado);
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
                comandoSQL.Parameters.AddWithValue("@Descripcion", model.Descripcion);
                comandoSQL.Parameters.AddWithValue("@ArchivoRuta", model.ArchivoRuta);
                comandoSQL.Parameters.AddWithValue("@JefeEstado", model.JefeEstado);
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

        public bool AusentismosSolicitudesJefeEditar(AusentismoSolicitud model)
        {
            SqlConnection conexionSQL = new SqlConnection(strConexionSQL);
            SqlCommand comandoSQL = new SqlCommand();

            try
            {
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "sp_ausentismos_solicitudes_jefe_editar";
                comandoSQL.Parameters.AddWithValue("@Id", model.Id);
                comandoSQL.Parameters.AddWithValue("@JefeEstado", model.JefeEstado);
                comandoSQL.Parameters.AddWithValue("@JefeObservacion", model.JefeObservacion);
                comandoSQL.Parameters.AddWithValue("@JefeUsuarioId", model.JefeUsuarioId);
                comandoSQL.Parameters.AddWithValue("@GhEstado", model.GhEstado);
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
