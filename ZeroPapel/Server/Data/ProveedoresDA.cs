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
    public class ProveedoresDA
    {
        LeerJson objJson = new LeerJson();
        LogEventosDA logDA = new LogEventosDA();
        string strConexionSQL = "";


        public ProveedoresDA()
        {
            strConexionSQL = objJson.GetStrConexion();
        }
        public List<Proveedor> ProveedoresObtener()
        {
            DataSet ds = new DataSet();
            SqlConnection conexionSQL = new SqlConnection(strConexionSQL);
            SqlCommand comandoSQL = new SqlCommand();
            SqlDataAdapter adaptadorSQL = new SqlDataAdapter();
            List<Proveedor> lst = new List<Proveedor>();

            try
            {
                comandoSQL.Connection = conexionSQL;
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "sp_proveedores_obtener";
                adaptadorSQL.SelectCommand = comandoSQL;
                adaptadorSQL.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            Proveedor obj = new Proveedor();
                            obj.Nit = item["Nit"].ToString();
                            obj.RazonSocial = item["RazonSocial"].ToString();
                            obj.Sucursal = item["Sucursal"].ToString();
                            obj.SucursalDescripcion = item["SucursalDescripcion"].ToString();
                            obj.Telefono = item["Telefono"].ToString();
                            obj.Email = item["Email"].ToString();
                            obj.RazonSocialSucursal = item["RazonSocialSucursal"].ToString();
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

        public bool LogEventosIngresar(Exception ex)
        {
            logDA.LogEventoIngresar(ex);
            return true;
        }

    }
}
