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
    public class CargosDA
    {
        LeerJson objJson = new LeerJson();
        LogEventosDA logDA = new LogEventosDA();
        string strConexionSQL = "";


        public CargosDA()
        {
            strConexionSQL = objJson.GetStrConexion();
        }
        public List<Cargo> CargosObtener(int empresaId, int id)
        {
            DataSet ds = new DataSet();
            SqlConnection conexionSQL = new SqlConnection(strConexionSQL);
            SqlCommand comandoSQL = new SqlCommand();
            SqlDataAdapter adaptadorSQL = new SqlDataAdapter();
            List<Cargo> lst = new List<Cargo>();

            try
            {
                comandoSQL.Connection = conexionSQL;
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "sp_cargos_obtener";
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
                            Cargo obj = new Cargo();
                            obj.Id = Convert.ToInt32(item["Id"].ToString());
                            obj.Codigo = item["Codigo"].ToString();
                            obj.Nombre = item["Nombre"].ToString();
                            obj.Estado = Convert.ToBoolean(item["Estado"].ToString());
                            if (obj.Estado)
                            {
                                obj.EstadoDescripcion = "ACTIVO";
                            }
                            else
                            {
                                obj.EstadoDescripcion = "INACTIVO";
                            }
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

        public bool CargosIngresar(Cargo model)
        {
            SqlConnection conexionSQL = new SqlConnection(strConexionSQL);
            SqlCommand comandoSQL = new SqlCommand();

            try
            {
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "sp_cargos_ingresar";
                comandoSQL.Parameters.AddWithValue("@EmpresaId", model.EmpresaId);
                comandoSQL.Parameters.AddWithValue("@Codigo", model.Codigo);
                comandoSQL.Parameters.AddWithValue("@Nombre", model.Nombre);
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

        public bool CargosEditar(Cargo model)
        {
            SqlConnection conexionSQL = new SqlConnection(strConexionSQL);
            SqlCommand comandoSQL = new SqlCommand();

            try
            {
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "sp_cargos_editar";
                comandoSQL.Parameters.AddWithValue("@Id", model.Id);
                comandoSQL.Parameters.AddWithValue("@Codigo", model.Codigo);
                comandoSQL.Parameters.AddWithValue("@Nombre", model.Nombre);
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

        public bool CargosEliminar(int id)
        {
            SqlConnection conexionSQL = new SqlConnection(strConexionSQL);
            SqlCommand comandoSQL = new SqlCommand();

            try
            {
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "sp_cargos_eliminar";

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
