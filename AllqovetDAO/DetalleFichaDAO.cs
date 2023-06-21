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
    class DetalleFichaDAO : IDetalleFicha,IDisposable
    {
        public int Agregar(DetalleFicha detalleFicha, ref MySqlConnection con, ref MySqlTransaction transaction)
        {
            using (MySqlCommand cmd = new MySqlCommand("sp_RegistrarDetalleFicha", con, transaction))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pIdficha", detalleFicha.idficha);
                cmd.Parameters.AddWithValue("pFecha", detalleFicha.fecha);
                cmd.Parameters.AddWithValue("pDescripcion", detalleFicha.descripcion);
                cmd.Parameters.AddWithValue("pTemperatura", detalleFicha.temperatura);
                cmd.Parameters.AddWithValue("pProxcita", detalleFicha.proxcita);

                return cmd.ExecuteNonQuery();
            }
        }

        public DataTable BuscarDetallea(int idficha)
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
        // ~DetalleFichaDAO() {
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
