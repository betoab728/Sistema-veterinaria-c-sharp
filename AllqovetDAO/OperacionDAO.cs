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
    public class OperacionDAO : IOperacion, IDisposable
    {
        string cnx = Conexion.ObtenerConexion();

        public int Agregar(Operacion operacion)
        {
            throw new NotImplementedException(); 
        }

        public int  AgregarPagoVenta  (Operacion operacion)
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_RegistrarPagoVenta", cn))
                {
                    cn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pConcepto", operacion.Concepto);
                    cmd.Parameters.AddWithValue("ptipo", operacion.Tipo);
                    cmd.Parameters.AddWithValue("pIdmediopago", operacion.Idmediopago);
                    cmd.Parameters.AddWithValue("pImporte", operacion.Importe);
                    cmd.Parameters.AddWithValue("pDigitostarjeta", operacion.Digitostarjeta);
                    cmd.Parameters.AddWithValue("pIdventa", operacion.Idventa);
                    cmd.Parameters.AddWithValue("pIdcajachica", operacion.Idcajachica);
                    cmd.Parameters.AddWithValue("pIdtipo", operacion.idtipo);

                    int r = cmd.ExecuteNonQuery();

                    return r;
                }
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
        // ~OperacionDAO() {
        //   // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
        //   Dispose(false);
        // }

        // Este código se agrega para implementar correctamente el patrón descartable.
        void IDisposable.Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
            Dispose(true);
            // TODO: quite la marca de comentario de la siguiente línea si el finalizador se ha reemplazado antes.
             GC.SuppressFinalize(this);
        }
        #endregion
    }
}
