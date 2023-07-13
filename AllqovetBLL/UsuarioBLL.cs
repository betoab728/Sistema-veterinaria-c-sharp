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
            return db.Agregar(usuario);
        }

        public int Editar(Usuario usuario)
        {
            return db.Editar(usuario);
        }

        public DataTable Listar()
        {
            return db.Listar();
        }

        public DataTable Login(Usuario usuario)
        {
            return db.Login(usuario);
        }
        public Usuario BuscarUsuario(int id)
        {
            return db.BuscarUsuario(id);
        }

        public  Usuario PermisoAnulacion(string clave)
        {
            return db.PermisoAnulacion(clave);
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
