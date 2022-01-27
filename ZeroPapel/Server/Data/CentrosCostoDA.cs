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
    public class CentrosCostoDA
    {
        LeerJson objJson = new LeerJson();
        LogEventosDA logDA = new LogEventosDA();
        string strConexionSQL = "";


        public CentrosCostoDA()
        {
            strConexionSQL = objJson.GetStrConexion();
        }
        public List<CentroCosto> CentrosCostoObtener()
        {
            DataSet ds = new DataSet();
            SqlConnection conexionSQL = new SqlConnection(strConexionSQL);
            SqlCommand comandoSQL = new SqlCommand();
            SqlDataAdapter adaptadorSQL = new SqlDataAdapter();
            List<CentroCosto> lst = new List<CentroCosto>();

            try
            {
                comandoSQL.Connection = conexionSQL;
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "sp_centros_costo_obtener";
                adaptadorSQL.SelectCommand = comandoSQL;
                adaptadorSQL.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            CentroCosto obj = new CentroCosto();
                            obj.Cia = item["Cia"].ToString();
                            obj.Id = item["Id"].ToString();
                            obj.Descripcion = item["Descripcion"].ToString();
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
