using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ZeroPapel.Server.Helper;
using ZeroPapel.Shared;
using System.Globalization;

namespace ZeroPapel.Server.Data
{
    public class DocumentosDA
    {
        LeerJson objJson = new LeerJson();
        LogEventosDA logDA = new LogEventosDA();
        string strConexionSQL = "";


        public DocumentosDA()
        {
            strConexionSQL = objJson.GetStrConexion();
        }
        public List<Documento> DocumentosPendientesObtener(int empresaId, int id,int usuarioId)
        {
            DataSet ds = new DataSet();
            SqlConnection conexionSQL = new SqlConnection(strConexionSQL);
            SqlCommand comandoSQL = new SqlCommand();
            SqlDataAdapter adaptadorSQL = new SqlDataAdapter();
            List<Documento> lst = new List<Documento>();

            try
            {
                comandoSQL.Connection = conexionSQL;
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "sp_documentos_pendientes_obtener";
                comandoSQL.Parameters.AddWithValue("@EmpresaId", empresaId);
                comandoSQL.Parameters.AddWithValue("@Id", id);
                comandoSQL.Parameters.AddWithValue("@usuarioId", usuarioId);
                adaptadorSQL.SelectCommand = comandoSQL;
                adaptadorSQL.Fill(ds);
     
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            Documento obj = new Documento();
                            obj.Id = Convert.ToInt32(item["Id"].ToString());
                            obj.EmpresaId = Convert.ToInt32(item["EmpresaId"].ToString());
                            obj.CentroCostoId = item["CentroCostoId"].ToString();
                            obj.CentroCostoNombre = item["CentroCostoNombre"].ToString();
                            obj.DocumentoTipoId = Convert.ToInt32(item["DocumentoTipoId"].ToString());
                            obj.DocumentoTipoNombre = item["DocumentoTipoNombre"].ToString();
                            obj.MonedaId = Convert.ToInt32(item["MonedaId"].ToString());
                            obj.MonedaNombre = item["MonedaNombre"].ToString();
                            obj.ProveedorNit = item["ProveedorNit"].ToString();
                            obj.FechaRecepcion = Convert.ToDateTime(item["FechaRecepcion"].ToString());
                            obj.ProveedorNombre = item["ProveedorNombre"].ToString();
                            obj.DocumentoPrefijo = item["DocumentoPrefijo"].ToString();
                            obj.DocumentoNumero = Convert.ToInt32(item["DocumentoNumero"].ToString());
                            obj.DocumentoPrefijoNumero = item["DocumentoPrefijoNumero"].ToString();
                            obj.FechaExpedicion = Convert.ToDateTime(item["FechaExpedicion"].ToString());
                            obj.FechaVencimiento = Convert.ToDateTime(item["FechaVencimiento"].ToString());
                            obj.Valor = Convert.ToDecimal(item["Valor"].ToString());
                            obj.ArchivoRuta = item["ArchivoRuta"].ToString();
                            obj.AnexoRuta = item["AnexoRuta"].ToString();
                            obj.Observacion = item["Observacion"].ToString();
                            obj.UsuarioRegistroId = Convert.ToInt32(item["UsuarioRegistroId"].ToString());
                            obj.FechaRegistro = Convert.ToDateTime(item["FechaRegistro"].ToString());
                            obj.JerarquiaOrden = Convert.ToInt32(item["JerarquiaOrden"].ToString());
                            obj.ResponsableActualCargo = item["ResponsableActualCargo"].ToString();
                            obj.EstadoActualId = Convert.ToInt32(item["EstadoActualId"].ToString());
                            obj.EstadoActual = item["EstadoActual"].ToString();


                            obj.FechaRecepcionStr = obj.FechaRecepcion.ToString("d MMMM yyyy", CultureInfo.CreateSpecificCulture("es-MX"));
                            obj.FechaExpedicionStr = obj.FechaExpedicion.ToString("d MMMM yyyy", CultureInfo.CreateSpecificCulture("es-MX"));
                            obj.FechaVencimientoStr = obj.FechaVencimiento.ToString("d MMMM yyyy", CultureInfo.CreateSpecificCulture("es-MX"));
                            obj.FechaRegistroStr = obj.FechaRegistro.ToString("d MMMM yyyy h:mm tt", CultureInfo.CreateSpecificCulture("es-MX"));
                           


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

        public List<Documento> DocumentosHistorico(int documentoId)
        {
            DataSet ds = new DataSet();
            SqlConnection conexionSQL = new SqlConnection(strConexionSQL);
            SqlCommand comandoSQL = new SqlCommand();
            SqlDataAdapter adaptadorSQL = new SqlDataAdapter();
            List<Documento> lst = new List<Documento>();

            try
            {
                comandoSQL.Connection = conexionSQL;
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "sp_documentos_historico";
                comandoSQL.Parameters.AddWithValue("@DocumentoId", documentoId);
                adaptadorSQL.SelectCommand = comandoSQL;
                adaptadorSQL.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            Documento obj = new Documento();
                            obj.Id = Convert.ToInt32(item["Id"].ToString());
                            obj.EmpresaId = Convert.ToInt32(item["EmpresaId"].ToString());
                            obj.CentroCostoId = item["CentroCostoId"].ToString();
                            obj.CentroCostoNombre = item["CentroCostoNombre"].ToString();
                            obj.DocumentoTipoId = Convert.ToInt32(item["DocumentoTipoId"].ToString());
                            obj.DocumentoTipoNombre = item["DocumentoTipoNombre"].ToString();
                            obj.MonedaId = Convert.ToInt32(item["MonedaId"].ToString());
                            obj.MonedaNombre = item["MonedaNombre"].ToString();
                            obj.ProveedorNit = item["ProveedorNit"].ToString();
                            obj.FechaRecepcion = Convert.ToDateTime(item["FechaRecepcion"].ToString());
                            obj.ProveedorNombre = item["ProveedorNombre"].ToString();
                            obj.DocumentoPrefijo = item["DocumentoPrefijo"].ToString();
                            obj.DocumentoNumero = Convert.ToInt32(item["DocumentoNumero"].ToString());
                            obj.DocumentoPrefijoNumero = item["DocumentoPrefijoNumero"].ToString();
                            obj.FechaExpedicion = Convert.ToDateTime(item["FechaExpedicion"].ToString());
                            obj.FechaVencimiento = Convert.ToDateTime(item["FechaVencimiento"].ToString());
                            obj.Valor = Convert.ToDecimal(item["Valor"].ToString());
                            obj.ArchivoRuta = item["ArchivoRuta"].ToString();
                            obj.AnexoRuta = item["AnexoRuta"].ToString();
                            obj.Observacion = item["Observacion"].ToString();
                            obj.UsuarioRegistroId = Convert.ToInt32(item["UsuarioRegistroId"].ToString());
                            obj.FechaRegistro = Convert.ToDateTime(item["FechaRegistro"].ToString());
                            obj.JerarquiaOrden = Convert.ToInt32(item["JerarquiaOrden"].ToString());
                            obj.ResponsableActualCargo = item["ResponsableActualCargo"].ToString();
                            obj.EstadoActualId = Convert.ToInt32(item["EstadoActualId"].ToString());
                            obj.EstadoActual = item["EstadoActual"].ToString();


                            obj.FechaRecepcionStr = obj.FechaRecepcion.ToString("d MMMM yyyy", CultureInfo.CreateSpecificCulture("es-MX"));
                            obj.FechaExpedicionStr = obj.FechaExpedicion.ToString("d MMMM yyyy", CultureInfo.CreateSpecificCulture("es-MX"));
                            obj.FechaVencimientoStr = obj.FechaVencimiento.ToString("d MMMM yyyy", CultureInfo.CreateSpecificCulture("es-MX"));
                            obj.FechaRegistroStr = obj.FechaRegistro.ToString("d MMMM yyyy h:mm tt", CultureInfo.CreateSpecificCulture("es-MX"));



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

        public bool DocumentosIngresar(Documento model)
        {
            SqlConnection conexionSQL = new SqlConnection(strConexionSQL);
            SqlCommand comandoSQL = new SqlCommand();

            try
            {

                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "sp_documentos_ingresar";
                comandoSQL.Parameters.AddWithValue("@EmpresaId", model.EmpresaId);
                comandoSQL.Parameters.AddWithValue("@CentroCostoId", model.CentroCostoId);
                comandoSQL.Parameters.AddWithValue("@DocumentoTipoId", model.DocumentoTipoId);
                comandoSQL.Parameters.AddWithValue("@MonedaId", model.MonedaId);
                comandoSQL.Parameters.AddWithValue("@ProveedorNit", model.ProveedorNit);
                comandoSQL.Parameters.AddWithValue("@FechaRecepcion", model.FechaRecepcion);
                comandoSQL.Parameters.AddWithValue("@DocumentoPrefijo", model.DocumentoPrefijo);
                comandoSQL.Parameters.AddWithValue("@DocumentoNumero", model.DocumentoNumero);
                comandoSQL.Parameters.AddWithValue("@FechaExpedicion", model.FechaExpedicion);
                comandoSQL.Parameters.AddWithValue("@FechaVencimiento", model.FechaVencimiento);
                comandoSQL.Parameters.AddWithValue("@Valor", model.Valor);
                comandoSQL.Parameters.AddWithValue("@ArchivoRuta", model.ArchivoRuta);
                comandoSQL.Parameters.AddWithValue("@AnexoRuta", model.AnexoRuta);
                comandoSQL.Parameters.AddWithValue("@Observacion", model.Observacion);
                comandoSQL.Parameters.AddWithValue("@UsuarioRegistroId", model.UsuarioRegistroId);
                comandoSQL.Connection = conexionSQL;
                comandoSQL.Connection.Open();
                comandoSQL.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                DocumentosEliminar(model);
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

        public bool DocumentosEditar(Documento model)
        {
            SqlConnection conexionSQL = new SqlConnection(strConexionSQL);
            SqlCommand comandoSQL = new SqlCommand();

            try
            {
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "sp_documentos_editar";
                comandoSQL.Parameters.AddWithValue("@Id", model.Id);
                comandoSQL.Parameters.AddWithValue("@CentroCostoId", model.CentroCostoId);
                comandoSQL.Parameters.AddWithValue("@DocumentoTipoId", model.DocumentoTipoId);
                comandoSQL.Parameters.AddWithValue("@MonedaId", model.MonedaId);
                comandoSQL.Parameters.AddWithValue("@ProveedorNit", model.ProveedorNit);
                comandoSQL.Parameters.AddWithValue("@FechaRecepcion", model.FechaRecepcion);
                comandoSQL.Parameters.AddWithValue("@DocumentoPrefijo", model.DocumentoPrefijo);
                comandoSQL.Parameters.AddWithValue("@DocumentoNumero", model.DocumentoNumero);
                comandoSQL.Parameters.AddWithValue("@FechaExpedicion", model.FechaExpedicion);
                comandoSQL.Parameters.AddWithValue("@FechaVencimiento", model.FechaVencimiento);
                comandoSQL.Parameters.AddWithValue("@Valor", model.Valor);
                comandoSQL.Parameters.AddWithValue("@ArchivoRuta", model.ArchivoRuta);
                comandoSQL.Parameters.AddWithValue("@AnexoRuta", model.AnexoRuta);
                comandoSQL.Parameters.AddWithValue("@Observacion", model.Observacion);
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

        public bool DocumentosEliminar(Documento model)
        {
            SqlConnection conexionSQL = new SqlConnection(strConexionSQL);
            SqlCommand comandoSQL = new SqlCommand();

            try
            {

                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "sp_documentos_eliminar";
                comandoSQL.Parameters.AddWithValue("@CentroCostoId", model.CentroCostoId);
                comandoSQL.Parameters.AddWithValue("@DocumentoTipoId", model.DocumentoTipoId);
                comandoSQL.Parameters.AddWithValue("@ProveedorNit", model.ProveedorNit); 
                comandoSQL.Parameters.AddWithValue("@DocumentoPrefijo", model.DocumentoPrefijo);
                comandoSQL.Parameters.AddWithValue("@DocumentoNumero", model.DocumentoNumero);            
                comandoSQL.Parameters.AddWithValue("@Valor", model.Valor);
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
