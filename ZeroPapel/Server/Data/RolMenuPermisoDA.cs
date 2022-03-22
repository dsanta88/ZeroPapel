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
    public class RolMenuPermisoDA
    {
        LeerJson objJson = new LeerJson();
        LogEventosDA logDA = new LogEventosDA();
        string strConexionSQL = "";


        public RolMenuPermisoDA()
        {
            strConexionSQL = objJson.GetStrConexion();
        }
        public List<RolMenuPermiso> Obtenet(int rolId)
        {
            DataSet ds = new DataSet();
            SqlConnection conexionSQL = new SqlConnection(strConexionSQL);
            SqlCommand comandoSQL = new SqlCommand();
            SqlDataAdapter adaptadorSQL = new SqlDataAdapter();
            List<RolMenuPermiso> lst = new List<RolMenuPermiso>();

            try
            {
                comandoSQL.Connection = conexionSQL;
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "sp_roles_menu_permisos_obtener";
                comandoSQL.Parameters.AddWithValue("@RolId", rolId);
                adaptadorSQL.SelectCommand = comandoSQL;
                adaptadorSQL.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            RolMenuPermiso obj = new RolMenuPermiso();
                            obj.RolId = Convert.ToInt32(item["RolId"].ToString());
                            obj.MenuId = Convert.ToInt32(item["MenuId"].ToString());
                            obj.MenuPadre = item["MenuPadre"].ToString();
                            obj.MenuHijo = item["MenuHijo"].ToString();
                            obj.RolPermiso = Convert.ToBoolean(item["RolPermiso"].ToString());
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


        public bool Editar(RolMenuPermiso model)
        {
            SqlConnection conexionSQL = new SqlConnection(strConexionSQL);
            SqlCommand comandoSQL = new SqlCommand();

            try
            {
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "sp_roles_menu_permisos_editar";
                comandoSQL.Parameters.AddWithValue("@RolId", model.RolId);
                comandoSQL.Parameters.AddWithValue("@ArrayMenuIds", model.ArrayMenuIds);

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
