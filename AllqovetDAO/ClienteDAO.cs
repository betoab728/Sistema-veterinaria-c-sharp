using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Entidades;
using System.Data;
using MySql.Data.MySqlClient;

namespace AllqovetDAO
{
    public class ClienteDAO : ICliente , IDisposable
    {

        string cnx = Conexion.ObtenerConexion();

        public int Agregar(Cliente cliente)
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd=new MySqlCommand("sp_RegistrarCliente",cn))
                {
                    cn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pdni",cliente.DNI );
                    cmd.Parameters.AddWithValue("pApepaterno", cliente.ApellidoPaterno);
                    cmd.Parameters.AddWithValue("pApematerno", cliente.ApellidoMaterno);
                    cmd.Parameters.AddWithValue("pNombres", cliente.Nombres);
                    cmd.Parameters.AddWithValue("pDireccion", cliente.Direccion);
                    cmd.Parameters.AddWithValue("ptelefono",cliente.Telefono );
                    cmd.Parameters.AddWithValue("pcorreo",cliente.Telefono );

                    int r = cmd.ExecuteNonQuery();

                    return r;
                }
            }
        }

        public DataTable BuscarApellidos(Cliente cliente)
        {

            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_BuscarClienteNombre", cn))

                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pbuscar", cliente.ApellidoPaterno);

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

        public DataTable BuscarDni(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public int Editar(Cliente nivelacceso)
        {
            throw new NotImplementedException();
        }

        public DataTable Listar()
        {
            throw new NotImplementedException();
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
        // ~ClienteDAO() {
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
