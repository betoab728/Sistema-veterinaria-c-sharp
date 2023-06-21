using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Interfaces;
using AllqovetDAO;
using System.Data;

namespace AllqovetBLL
{
    public class BoletaBLL : IBoleta,IDisposable
    {
        BoletaDAO db = new BoletaDAO();
        public int Agregar(Boleta boleta, List<DetalleBoleta> detalleBoletas)
        {
            return db.Agregar(boleta,detalleBoletas);
        }

        public DataTable BuscarBoletaApellidos(string apellido)
        {
            throw new NotImplementedException();
        }

        public DataTable BuscarBoletaFechas(DateTime desde, DateTime hasta)
        {
            throw new NotImplementedException();
        }

        public Boleta Correlativo()
        {
            return db.Correlativo();
        }

        public DataTable DetalleBoleta(int idboleta)
        {
            throw new NotImplementedException();
        }

        public DataTable ImprimiBoleta(int idboleta)
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
        // ~BoletaBLL() {
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
