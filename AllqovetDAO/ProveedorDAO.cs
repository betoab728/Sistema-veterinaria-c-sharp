using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Interfaces;
using MySql.Data.MySqlClient;
using Interfaces;
using System.Net;
using Newtonsoft.Json;

namespace AllqovetDAO
{
    public class ProveedorDAO : IProveedor, IDisposable
    {
        string cnx = Conexion.ObtenerConexion();

        public int Agregar(Proveedor proveedor)
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_RegistrarProveedor", cn))
                {
                    cn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pRuc", proveedor.Ruc);
                    cmd.Parameters.AddWithValue("pRazonSocial", proveedor.RazonSocial);
                    cmd.Parameters.AddWithValue("pDireccion", proveedor.Direccion);
                    cmd.Parameters.AddWithValue("pTelefono", proveedor.Telefono);
                    cmd.Parameters.AddWithValue("pCorreo", proveedor.Correo);
                    cmd.Parameters.AddWithValue("pContacto1", proveedor.Contacto1);
                    cmd.Parameters.AddWithValue("pContacto2", proveedor.Contacto2);
                    cmd.Parameters.AddWithValue("pContacto3", proveedor.Contacto3);

                    int r = cmd.ExecuteNonQuery();

                    return r;
                }
            }
        }

        public DataTable BuscarRazonSocial(Proveedor proveedor)
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_BuscarProveedorRazonSocial", cn))

                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pbuscar", proveedor.RazonSocial);

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

        public DataTable BuscarRuc(Proveedor proveedor)
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_BuscarProveedorRUC", cn))

                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pbuscar", proveedor.Ruc);

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

        public int ContarNumProveedores(Proveedor proveedor)
        {
            throw new NotImplementedException();
        }

        public int Editar(Proveedor proveedor)
        {
            throw new NotImplementedException();
        }

        public DataTable Listar()
        {
            throw new NotImplementedException();
        }

        public Proveedor ConsultaRUC(string ruc)
        {

            string token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6ImFsYmVydG9hbGVncmViYXJhem9yZGFAZ21haWwuY29tIn0." +
                "hXidRgKKMbxHKoctqJB4Baa_p7ISmxlkbPOL0OIZKeA";

            var url = "https://dniruc.apisperu.com/api/v1/ruc/" + ruc + "?token=" + token;
            WebClient wc = new WebClient();
            var datos = wc.DownloadString(url);

            ConsultaRUC consulta = JsonConvert.DeserializeObject<ConsultaRUC>(datos);
            Proveedor proveedor = new Proveedor();
            proveedor.RazonSocial = consulta.RazonSocial;
            proveedor.Direccion = consulta.direccion;


            return proveedor;

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
        // ~ProveedorDAO() {
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
