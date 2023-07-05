using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllqovetDAO;
using Entidades;
using Interfaces;

namespace AllqovetBLL
{
    public class CitaBLL : ICita, IDisposable
    {
        CitaDAO db = new CitaDAO();

        public int Agregar(Cita cita)
        {
            return db.Agregar(cita);
        }

        public int Editar(Cita cita)
        {
            return db.Editar(cita);
        }

        public int Eliminar(Cita cita)
        {
            return db.Eliminar(cita);
        }

        public DataTable Listar()
        {
            return db.Listar();
        }

        public DataTable ListarCitaFecha(DateTime fecha)
        {
            return db.ListarCitaFecha(fecha);
        }

        public int AtenderCita(int idcita)
        {
            return db.AtenderCita(idcita);
        }
        public int AnularCita(int idcita)
        {
            return db.AnularCita(idcita);
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
        // ~CitaBLL() {
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
