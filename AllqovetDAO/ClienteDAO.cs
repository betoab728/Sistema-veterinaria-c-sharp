using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Entidades;
using System.Data;
using MySql.Data.MySqlClient;
using System.Net;
using Newtonsoft.Json;

namespace AllqovetDAO
{
    public class ClienteDAO : ICliente , IDisposable
    {

        string cnx = Conexion.ObtenerConexion();

        public int Agregar(Cliente cliente, List<Mascota> mascotas)
        {
            MySqlConnection cn = new MySqlConnection(cnx);
            cn.Open();
            MySqlTransaction transaccion = cn.BeginTransaction();
            int r = 0;
            int idcliente = 0;



            using (MySqlCommand cmd = new MySqlCommand("sp_RegistrarCliente", cn, transaccion))
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pdni", cliente.DNI);
                cmd.Parameters.AddWithValue("pApepaterno", cliente.ApellidoPaterno);
                cmd.Parameters.AddWithValue("pApematerno", cliente.ApellidoMaterno);
                cmd.Parameters.AddWithValue("pNombres", cliente.Nombres);
                cmd.Parameters.AddWithValue("pDireccion", cliente.Direccion);
                cmd.Parameters.AddWithValue("ptelefono", cliente.Telefono);
                cmd.Parameters.AddWithValue("pcorreo", cliente.Telefono);

                cmd.Parameters.Add("pIdcliente", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                r = cmd.ExecuteNonQuery();

                if (r > 0)
                {
                    idcliente = Convert.ToInt32(cmd.Parameters["pIdcliente"].Value);
                    MascotaDAO db = new MascotaDAO();

                    foreach (Mascota mascota in mascotas)
                    {
                        mascota.idcliente = idcliente;

                        r = db.Agregar(mascota,ref cn,ref transaccion);
                        if (r != 1)
                        {

                            break;
                        }

                    }


                }


                if (r == 1)
                {
                    transaccion.Commit();
                    cn.Close();
                }
                else
                {

                    transaccion.Rollback();
                }

                return r;
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

        public Cliente ConsultaDNI(string dni)
        {

            string token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6ImFsYmVydG9hbGVncmViYXJhem9yZGFAZ21haWwuY29tIn0." +
                "hXidRgKKMbxHKoctqJB4Baa_p7ISmxlkbPOL0OIZKeA";

            var url = "https://dniruc.apisperu.com/api/v1/dni/" + dni + "?token=" +token;
            WebClient wc = new WebClient();
            var datos = wc.DownloadString(url);

            ConsultaDNI consulta = JsonConvert.DeserializeObject<ConsultaDNI>(datos);
            Cliente cliente = new Cliente();
            cliente.Nombres = consulta.nombres;
            cliente.ApellidoPaterno = consulta.apellidoPaterno;
            cliente.ApellidoMaterno = consulta.apellidoMaterno;

            return cliente;

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
