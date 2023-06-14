using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Interfaces;
using MySql.Data.MySqlClient;
using System.Data;

namespace AllqovetDAO
{
    class MascotaDAO : IMascota,IDisposable
    {
        public int Agregar(Mascota mascota, ref MySqlConnection con, ref MySqlTransaction transaction)
        {
            using (MySqlCommand cmd = new MySqlCommand("sp_RegistrarMascota", con, transaction))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pNombre", mascota.Nombre);
                cmd.Parameters.AddWithValue("pFecha", mascota.FechaNacimiento);
                cmd.Parameters.AddWithValue("pRaza", mascota.Raza);
                cmd.Parameters.AddWithValue("pEspecie", mascota.Especie);
                cmd.Parameters.AddWithValue("pSexo", mascota.Sexo);
                cmd.Parameters.AddWithValue("pCapa", mascota.Capa);
                cmd.Parameters.AddWithValue("pObs", mascota.Observacion);
                cmd.Parameters.AddWithValue("pIdcliente", mascota.idcliente);


                return cmd.ExecuteNonQuery();
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
        // ~MascotaDAO() {
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
