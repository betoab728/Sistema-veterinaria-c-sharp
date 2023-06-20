using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Interfaces;
using MySql.Data.MySqlClient;

namespace AllqovetDAO
{
  public  class UsuarioDAO : IUsuario,IDisposable
    {

        string cnx = Conexion.ObtenerConexion();

        public int Agregar(Usuario usuario)
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_RegistrarUsuario", cn))
                {
                    string clave_encriptada = Encriptar(usuario.Contraseña);

                    cn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pNombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("pClave", clave_encriptada);
                    cmd.Parameters.AddWithValue("pIdtrabajador", usuario.Idtrabajador);
                    cmd.Parameters.AddWithValue("pIdnivel", usuario.Idnivelacceso);

                    return cmd.ExecuteNonQuery();

                }
            }
        }

        public int Editar(Usuario usuario)
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_EditarUsuario", cn))
                {
                    string clave_encriptada = Encriptar(usuario.Contraseña);

                    cn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pNombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("pClave", clave_encriptada);
                    cmd.Parameters.AddWithValue("pIdtrabajador", usuario.Idtrabajador);
                    cmd.Parameters.AddWithValue("pIdnivel", usuario.Idnivelacceso);
                    cmd.Parameters.AddWithValue("pIdusuario", usuario.Idusuario);

                    return cmd.ExecuteNonQuery();

                }
            }
        }

        public DataTable Listar()
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_ListarUsuario", cn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cn.Open();
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        return dt;
                    }
                }
            }
        }

        public DataTable Login(Usuario usuario)
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_Login", cn))
                {
                   
                    string clave_encriptada = Encriptar(usuario.Contraseña);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pidnivel",usuario.Idnivelacceso);
                    cmd.Parameters.AddWithValue("pnombre",usuario.Nombre);
                    cmd.Parameters.AddWithValue("pclave", clave_encriptada);


                    cn.Open();
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        return dt;
                    }
                }
            }
        }

        public Usuario BuscarUsuario(int id)
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("BuscarUsuario", cn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pIdusuario", id);
                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        Usuario usuario = new Usuario();

                        while (dr.Read())
                        {
                            usuario.Nombre = dr["Nombre"].ToString();
                            usuario.Idtrabajador = Convert.ToInt32(dr["Idtrabajador"]);
                            usuario.Idnivelacceso = Convert.ToInt32(dr["Idnivelacceso"]);
                            usuario.estado = Convert.ToInt32(dr["estado"]);

                        }

                        return usuario;
                    }
                }
            }
        }

        private string Encriptar(string clave)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] claveBytes = Encoding.UTF8.GetBytes(clave);
                byte[] claveHashBytes = sha256.ComputeHash(claveBytes);
                string claveEncriptada = Convert.ToBase64String(claveHashBytes);
                return claveEncriptada;
            }
        }

       



        #region IDisposable Support
        private bool disposedValue = false; // Para detectar llamadas redundantes

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: elimine el estado administrado (objetos administrados).
                }

                // TODO: libere los recursos no administrados (objetos no administrados) y reemplace el siguiente finalizador.
                // TODO: configure los campos grandes en nulos.

                disposedValue = true;
            }
        }

        // TODO: reemplace un finalizador solo si el anterior Dispose(bool disposing) tiene código para liberar los recursos no administrados.
        // ~UsuarioDAO() {
        //   // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
        //   Dispose(false);
        // }

        // Este código se agrega para implementar correctamente el patrón descartable.
        public void Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
            Dispose(true);
            // TODO: quite la marca de comentario de la siguiente línea si el finalizador se ha reemplazado antes.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
