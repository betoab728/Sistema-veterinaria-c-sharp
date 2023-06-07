using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using AllqovetDAO;
using Interfaces;
using System.Data;

namespace AllqovetBLL
{
    public class UsuarioBLL : IUsuario , IDisposable
    {
        UsuarioDAO db = new UsuarioDAO();
        public int Agregar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public int Editar()
        {
            throw new NotImplementedException();
        }

        public DataTable Listar()
        {
            throw new NotImplementedException();
        }

        public DataTable Login(Usuario usuario)
        {
            return db.Login(usuario);
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
        // ~UsuarioBLL() {
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
