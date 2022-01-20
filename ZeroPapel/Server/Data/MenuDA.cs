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
    public class MenuDA
    {
        LeerJson objJson = new LeerJson();
        LogEventosDA logDA = new LogEventosDA();
        string strConexionSQL = "";


        public MenuDA()
        {
            strConexionSQL = objJson.GetStrConexion();
        }
        public List<Menu> MenuObtener(int empresaId, int id)
        {
            DataSet ds = new DataSet();
            SqlConnection conexionSQL = new SqlConnection(strConexionSQL);
            SqlCommand comandoSQL = new SqlCommand();
            SqlDataAdapter adaptadorSQL = new SqlDataAdapter();
            List<Menu> lst = new List<Menu>();

            try
            {
                comandoSQL.Connection = conexionSQL;
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "sp_menu_obtener";
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
                            Menu obj = new Menu();
                            obj.Id = Convert.ToInt32(item["Id"].ToString());
                            obj.PadreId =Convert.ToInt32(item["PadreId"].ToString());
                            obj.PadreNombre = item["PadreNombre"].ToString();
                            obj.Nombre = item["Nombre"].ToString();
                            obj.Orden = Convert.ToInt32(item["Orden"].ToString());
                            obj.Link = item["Link"].ToString();
                            obj.Estado =Convert.ToBoolean( item["Estado"].ToString());
                            obj.Icono = item["Icono"].ToString();
                            obj.UsuarioRegistroId = Convert.ToInt32(item["UsuarioRegistroId"].ToString());
                            obj.FechaRegistro = Convert.ToDateTime(item["FechaRegistro"].ToString());
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



        public bool CargosEditar(Cargo model)
        {
            SqlConnection conexionSQL = new SqlConnection(strConexionSQL);
            SqlCommand comandoSQL = new SqlCommand();

            try
            {
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "sp_cargos_editar";
                comandoSQL.Parameters.AddWithValue("@Id", model.Id);
                comandoSQL.Parameters.AddWithValue("@Nombre", model.Nombre);

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
