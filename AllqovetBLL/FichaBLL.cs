using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Entidades;
using AllqovetDAO;
using System.Data;

namespace AllqovetBLL
{
    public class FichaBLL : IFicha,IDisposable
    {
        FichaDAO db = new FichaDAO();
        public int Agregar(Ficha ficha, List<DetalleFicha> detalleFichas)
        {
            return db.Agregar(ficha, detalleFichas);
        }

        public DataTable Buscar(Ficha ficha)
        {
            throw new NotImplementedException();
        }

        public int Editar(Ficha ficha, List<DetalleFicha> detalleFichas)
        {
            return db.Editar(ficha, detalleFichas);
        }

        public DataTable Listar()
        {
            throw new NotImplementedException();
        }

        public string CorrelativoFicha()
        {
            return db.CorrelativoFicha();
        }

        public DataTable Imprimir(int idficha)
        {
            return db.Imprimir(idficha);
        }

        public DataTable BuscarFichaApellido(string apellido)
        {
            return db.BuscarFichaApellido(apellido);
        }
        public DataTable BuscarFichaDNI(string dni)
        {
            return db.BuscarFichaDNI(dni);
        }
        public DataTable BuscarFichaFechas(DateTime desde, DateTime hasta)
        {
            return db.BuscarFichaFechas(desde, hasta);
        }

        public DataTable BuscarFichaID(int idficha)
        {
            return db.BuscarFichaID(idficha);
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
        // ~FichaBLL() {
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
