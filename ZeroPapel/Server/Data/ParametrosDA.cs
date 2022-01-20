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
    public class ParametrosDA
    {

        LeerJson objJson = new LeerJson();
        LogEventosDA logDA = new LogEventosDA();
        string strConexionSQL = "";


        public ParametrosDA()
        {
            strConexionSQL = objJson.GetStrConexion();
        }
        public List<Parametro> ParametrosObtener(int empresaId, int id, string nombre)
        {
            DataSet ds = new DataSet();
            SqlConnection conexionSQL = new SqlConnection(strConexionSQL);
            SqlCommand comandoSQL = new SqlCommand();
            SqlDataAdapter adaptadorSQL = new SqlDataAdapter();
            List<Parametro> lst = new List<Parametro>();

            try
            {
                comandoSQL.Connection = conexionSQL;
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "sp_parametros_obtener";
                comandoSQL.Parameters.AddWithValue("@EmpresaId", empresaId);
                comandoSQL.Parameters.AddWithValue("@Id", id);
                comandoSQL.Parameters.AddWithValue("@Nombre", nombre);
                adaptadorSQL.SelectCommand = comandoSQL;
                adaptadorSQL.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            Parametro obj = new Parametro();
                            obj.Id = Convert.ToInt32(item["Id"].ToString());
                            obj.Nombre = item["Nombre"].ToString();
                            obj.Valor = item["Valor"].ToString();
                            obj.Descripcion = item["Descripcion"].ToString();
                            obj.TipoDato = item["TipoDato"].ToString();
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


        public bool ParametrosEditar(Parametro model)
        {
            SqlConnection conexionSQL = new SqlConnection(strConexionSQL);
            SqlCommand comandoSQL = new SqlCommand();

            try
            {
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "sp_parametros_editar";
                comandoSQL.Parameters.AddWithValue("@Id", model.Id);
                comandoSQL.Parameters.AddWithValue("@Nombre", model.Nombre);
                comandoSQL.Parameters.AddWithValue("@Valor", model.Valor);
                comandoSQL.Parameters.AddWithValue("@Descripcion", model.Descripcion);
                comandoSQL.Parameters.AddWithValue("@TipoDato", model.TipoDato);

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
