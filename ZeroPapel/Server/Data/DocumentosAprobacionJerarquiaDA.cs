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
    public class DocumentosAprobacionJerarquiaDA
    {
        LeerJson objJson = new LeerJson();
        LogEventosDA logDA = new LogEventosDA();
        string strConexionSQL = "";


        public DocumentosAprobacionJerarquiaDA()
        {
            strConexionSQL = objJson.GetStrConexion();
        }
        public List<DocumentoAprobacionJerarquia> DocumentosAprobacionJerarquiaObtener(int empresaId, int id, int documentoTipoId)
        {
            DataSet ds = new DataSet();
            SqlConnection conexionSQL = new SqlConnection(strConexionSQL);
            SqlCommand comandoSQL = new SqlCommand();
            SqlDataAdapter adaptadorSQL = new SqlDataAdapter();
            List<DocumentoAprobacionJerarquia> lst = new List<DocumentoAprobacionJerarquia>();

            try
            {
                comandoSQL.Connection = conexionSQL;
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "sp_documentos_aprobacion_jerarquia_obtener";
                comandoSQL.Parameters.AddWithValue("@EmpresaId", empresaId);
                comandoSQL.Parameters.AddWithValue("@Id", id);
                comandoSQL.Parameters.AddWithValue("@DocumentoTipoId", documentoTipoId);
                adaptadorSQL.SelectCommand = comandoSQL;
                adaptadorSQL.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            DocumentoAprobacionJerarquia obj = new DocumentoAprobacionJerarquia();
                            obj.Id = Convert.ToInt32(item["Id"].ToString());
                            obj.JerarquiaOrden = Convert.ToInt32(item["JerarquiaOrden"].ToString());
                            obj.DocumentoTipoId = Convert.ToInt32(item["DocumentoTipoId"].ToString());
                            obj.DocumentoTipoNombre = item["DocumentoTipoNombre"].ToString();
                            obj.CargoId = Convert.ToInt32(item["CargoId"].ToString());
                            obj.CargoNombre = item["CargoNombre"].ToString();
                            obj.ApruebaValorDocumento = Convert.ToBoolean(item["ApruebaValorDocumento"].ToString());
                            obj.ApruebaValorDocumentoDescripcion = item["ApruebaValorDocumentoDescripcion"].ToString();
                            obj.ValorMinimo = Convert.ToDecimal(item["ValorMinimo"].ToString());
                            obj.ValorMaximo = Convert.ToDecimal(item["ValorMaximo"].ToString());
                            obj.Estado = Convert.ToBoolean(item["Estado"].ToString());                  
                            obj.EstadoDescripcion = item["EstadoDescripcion"].ToString();

                            obj.ValorMinimoStr = "$" + String.Format(CultureInfo.InvariantCulture, "{0:0,0}", obj.ValorMinimo);
                            obj.ValorMaximoStr = "$" + String.Format(CultureInfo.InvariantCulture, "{0:0,0}", obj.ValorMaximo);

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

        public bool DocumentosAprobacionJerarquiaIngresar(DocumentoAprobacionJerarquia model)
        {
            SqlConnection conexionSQL = new SqlConnection(strConexionSQL);
            SqlCommand comandoSQL = new SqlCommand();

            try
            {

                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "sp_documentos_aprobacion_jerarquia_ingresar";
                comandoSQL.Parameters.AddWithValue("@EmpresaId", model.EmpresaId);
                comandoSQL.Parameters.AddWithValue("@JerarquiaOrden", model.JerarquiaOrden);
                comandoSQL.Parameters.AddWithValue("@DocumentoTipoId", model.DocumentoTipoId);
                comandoSQL.Parameters.AddWithValue("@CargoId", model.CargoId);
                comandoSQL.Parameters.AddWithValue("@Estado", model.Estado);
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

        public bool DocumentosAprobacionJerarquiaEditar(DocumentoAprobacionJerarquia model)
        {
            SqlConnection conexionSQL = new SqlConnection(strConexionSQL);
            SqlCommand comandoSQL = new SqlCommand();

            try
            {
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "sp_documentos_aprobacion_jerarquia_editar";
                comandoSQL.Parameters.AddWithValue("@Id", model.Id);
                comandoSQL.Parameters.AddWithValue("@JerarquiaOrden", model.JerarquiaOrden);
                comandoSQL.Parameters.AddWithValue("@DocumentoTipoId", model.DocumentoTipoId);
                comandoSQL.Parameters.AddWithValue("@CargoId", model.CargoId);
                comandoSQL.Parameters.AddWithValue("@Estado", model.Estado);
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

        public bool DocumentosAprobacionJerarquiaEliminar(int id)
        {
            SqlConnection conexionSQL = new SqlConnection(strConexionSQL);
            SqlCommand comandoSQL = new SqlCommand();

            try
            {
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "sp_documentos_aprobacion_jerarquia_eliminar";

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

        public Validacion DocumentosAprobacionJerarquiaValidarOrden(int empresaId,int documentoTipoId, int jeraquiaOrden)
        {
            DataSet ds = new DataSet();
            SqlConnection conexionSQL = new SqlConnection(strConexionSQL);
            SqlCommand comandoSQL = new SqlCommand();
            SqlDataAdapter adaptadorSQL = new SqlDataAdapter();
            Validacion obj = new Validacion();

            try
            {
                comandoSQL.Connection = conexionSQL;
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "sp_documentos_aprobacion_jerarquia_validar_orden";
                comandoSQL.Parameters.AddWithValue("@EmpresaId", empresaId);
                comandoSQL.Parameters.AddWithValue("@DocumentoTipoId", documentoTipoId);
                comandoSQL.Parameters.AddWithValue("@JeraquiaOrden", jeraquiaOrden);
                adaptadorSQL.SelectCommand = comandoSQL;
                adaptadorSQL.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            obj.Mensaje = item["Mensaje"].ToString();
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

            return obj;
        }

        public bool LogEventosIngresar(Exception ex)
        {
            logDA.LogEventoIngresar(ex);
            return true;
        }
    }
}
