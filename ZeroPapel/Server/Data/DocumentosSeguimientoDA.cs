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
    public class DocumentosSeguimientoDA
    {

        LeerJson objJson = new LeerJson();
        LogEventosDA logDA = new LogEventosDA();
        string strConexionSQL = "";


        public DocumentosSeguimientoDA()
        {
            strConexionSQL = objJson.GetStrConexion();
        }


        public List<DocumentoSeguimiento> DocumentoSeguimientoObtener(int documentoId)
        {
            DataSet ds = new DataSet();
            SqlConnection conexionSQL = new SqlConnection(strConexionSQL);
            SqlCommand comandoSQL = new SqlCommand();
            SqlDataAdapter adaptadorSQL = new SqlDataAdapter();
            List<DocumentoSeguimiento> lst = new List<DocumentoSeguimiento>();

            try
            {
                comandoSQL.Connection = conexionSQL;
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "sp_documentos_seguimiento_obtener";
                comandoSQL.Parameters.AddWithValue("@DocumentoId", documentoId);
                adaptadorSQL.SelectCommand = comandoSQL;
                adaptadorSQL.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            DocumentoSeguimiento obj = new DocumentoSeguimiento();
                            obj.FechaRegistro = Convert.ToDateTime(item["FechaRegistro"].ToString());
                            obj.FechaRegistroStr = obj.FechaRegistro.ToString("d MMMM yyyy hh:mm tt", CultureInfo.CreateSpecificCulture("es-MX"));
                            obj.UsuarioNombre = item["UsuarioNombre"].ToString();
                            obj.EstadoDescripcion = item["EstadoDescripcion"].ToString();
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


        public bool DocumentoSeguimientoIngresar(DocumentoSeguimiento model)
        {
            SqlConnection conexionSQL = new SqlConnection(strConexionSQL);
            SqlCommand comandoSQL = new SqlCommand();

            try
            {
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "sp_documentos_seguimiento_ingresar";
                comandoSQL.Parameters.AddWithValue("@DocumentoId", model.DocumentoId);
                comandoSQL.Parameters.AddWithValue("@DocumentoEstadoId", model.DocumentoEstadoId);
                comandoSQL.Parameters.AddWithValue("@JerarquiaOrden", model.JerarquiaOrden);
                comandoSQL.Parameters.AddWithValue("@Comentario", model.Comentario);
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

        public bool LogEventosIngresar(Exception ex)
        {
            logDA.LogEventoIngresar(ex);
            return true;
        }
    }
}
