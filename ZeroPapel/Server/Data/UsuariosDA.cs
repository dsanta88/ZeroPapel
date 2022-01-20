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
    public class UsuariosDA
    {
        LeerJson objJson = new LeerJson();
        LogEventosDA logDA = new LogEventosDA();
        string strConexionSQL = "";


        public UsuariosDA()
        {
            strConexionSQL = objJson.GetStrConexion();
        }
        public List<Usuario> UsuariosObtener(int empresaId, int id)
        {
            DataSet ds = new DataSet();
            SqlConnection conexionSQL = new SqlConnection(strConexionSQL);
            SqlCommand comandoSQL = new SqlCommand();
            SqlDataAdapter adaptadorSQL = new SqlDataAdapter();
            List<Usuario> lst = new List<Usuario>();

            try
            {
                comandoSQL.Connection = conexionSQL;
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "sp_usuarios_obtener";
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

                            Usuario obj = new Usuario();
                            obj.Id= Convert.ToInt32(item["Id"].ToString());
                            obj.EmpresaId = Convert.ToInt32(item["EmpresaId"].ToString());
                            obj.CargoId = Convert.ToInt32(item["CargoId"].ToString());
                            obj.CargoNombre = item["CargoNombre"].ToString();
                            obj.JefeUsuarioId = Convert.ToInt32(item["JefeUsuarioId"].ToString());
                            obj.Apellidos = item["Apellidos"].ToString();
                            obj.Nombres = item["Nombres"].ToString();
                            obj.NombreCompleto = obj.Apellidos + " " + obj.Nombres;
                            obj.Identificacion = item["Identificacion"].ToString();
                            obj.FechaNacimiento =Convert.ToDateTime(item["FechaNacimiento"].ToString());
                            obj.CodigoInterno = item["CodigoInterno"].ToString();
                            obj.Sexo = item["Sexo"].ToString();
                            if (obj.Sexo=="M")
                            {
                                obj.SexoDescripcion = "MASCULINO";
                            }
                            else
                            {
                                obj.SexoDescripcion = "FEMENINO";
                            }

                            obj.Estado =Convert.ToBoolean(item["Estado"].ToString());
                            if (obj.Estado)
                            {
                                obj.EstadoDescripcion = "ACTIVO";
                            }
                            else
                            {
                                obj.EstadoDescripcion = "INACTIVO";
                            }
                            obj.NivelUsuario = Convert.ToInt32(item["NivelUsuario"].ToString());
                            obj.FotoUrl = item["FotoUrl"].ToString();
                            obj.Celular = item["Celular"].ToString();
                            obj.Email = item["Email"].ToString();
                            obj.Clave = item["Clave"].ToString();
                            obj.Direccion = item["Direccion"].ToString();
                            obj.Observacion = item["Observacion"].ToString();
                            obj.FechaIngreso = Convert.ToDateTime(item["FechaIngreso"].ToString());
                            obj.FechaRetiro = Convert.ToDateTime(item["FechaRetiro"].ToString());
                            obj.Salario = Convert.ToDecimal(item["Salario"].ToString());
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

        public bool UsuariosIngresar(Usuario model)
        {
            SqlConnection conexionSQL = new SqlConnection(strConexionSQL);
            SqlCommand comandoSQL = new SqlCommand();

            try
            {


        //public int  { get; set; }
        //public DateTime FechaRegistro { get; set; }

        comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "sp_usuarios_ingresar";
                comandoSQL.Parameters.AddWithValue("@EmpresaId", model.EmpresaId);
                comandoSQL.Parameters.AddWithValue("@CargoId", model.CargoId);
                comandoSQL.Parameters.AddWithValue("@JefeUsuarioId", model.JefeUsuarioId);
                comandoSQL.Parameters.AddWithValue("@Apellidos", model.Apellidos);
                comandoSQL.Parameters.AddWithValue("@Nombres", model.Nombres);
                comandoSQL.Parameters.AddWithValue("@Identificacion", model.Identificacion);
                comandoSQL.Parameters.AddWithValue("@FechaNacimiento", model.FechaNacimiento);
                comandoSQL.Parameters.AddWithValue("@CodigoInterno", model.CodigoInterno);
                comandoSQL.Parameters.AddWithValue("@Sexo", model.Sexo);
                comandoSQL.Parameters.AddWithValue("@Estado", model.Estado);
                comandoSQL.Parameters.AddWithValue("@NivelUsuario", model.NivelUsuario);
                comandoSQL.Parameters.AddWithValue("@FotoUrl", model.FotoUrl);
                comandoSQL.Parameters.AddWithValue("@Celular", model.Celular);
                comandoSQL.Parameters.AddWithValue("@Email", model.Email);
                comandoSQL.Parameters.AddWithValue("@Clave", model.Clave);
                comandoSQL.Parameters.AddWithValue("@Direccion", model.Direccion);
                comandoSQL.Parameters.AddWithValue("@Observacion", model.Observacion);
                comandoSQL.Parameters.AddWithValue("@FechaIngreso", model.FechaIngreso);
                comandoSQL.Parameters.AddWithValue("@FechaRetiro", model.FechaRetiro);
                comandoSQL.Parameters.AddWithValue("@Salario", model.Salario);
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

        public bool UsuariosEditar(Usuario model)
        {
            SqlConnection conexionSQL = new SqlConnection(strConexionSQL);
            SqlCommand comandoSQL = new SqlCommand();

            try
            {
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "sp_usuarios_editar";
                comandoSQL.Parameters.AddWithValue("@Id", model.Id);
                comandoSQL.Parameters.AddWithValue("@EmpresaId", model.EmpresaId);
                comandoSQL.Parameters.AddWithValue("@CargoId", model.CargoId);
                comandoSQL.Parameters.AddWithValue("@JefeUsuarioId", model.JefeUsuarioId);
                comandoSQL.Parameters.AddWithValue("@Apellidos", model.Apellidos);
                comandoSQL.Parameters.AddWithValue("@Nombres", model.Nombres);
                comandoSQL.Parameters.AddWithValue("@Identificacion", model.Identificacion);
                comandoSQL.Parameters.AddWithValue("@FechaNacimiento", model.FechaNacimiento);
                comandoSQL.Parameters.AddWithValue("@CodigoInterno", model.CodigoInterno);
                comandoSQL.Parameters.AddWithValue("@Sexo", model.Sexo);
                comandoSQL.Parameters.AddWithValue("@Estado", model.Estado);
                comandoSQL.Parameters.AddWithValue("@NivelUsuario", model.NivelUsuario);
                comandoSQL.Parameters.AddWithValue("@FotoUrl", model.FotoUrl);
                comandoSQL.Parameters.AddWithValue("@Celular", model.Celular);
                comandoSQL.Parameters.AddWithValue("@Email", model.Email);
                comandoSQL.Parameters.AddWithValue("@Clave", model.Clave);
                comandoSQL.Parameters.AddWithValue("@Direccion", model.Direccion);
                comandoSQL.Parameters.AddWithValue("@Observacion", model.Observacion);
                comandoSQL.Parameters.AddWithValue("@FechaIngreso", model.FechaIngreso);
                comandoSQL.Parameters.AddWithValue("@FechaRetiro", model.FechaRetiro);
                comandoSQL.Parameters.AddWithValue("@Salario", model.Salario);
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

        public bool UsuariosEliminar(int id)
        {
            SqlConnection conexionSQL = new SqlConnection(strConexionSQL);
            SqlCommand comandoSQL = new SqlCommand();

            try
            {
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "sp_usuarios_eliminar";

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
