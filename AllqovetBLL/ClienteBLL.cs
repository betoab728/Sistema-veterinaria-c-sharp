using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Interfaces;
using AllqovetDAO;

namespace AllqovetBLL
{
    public class ClienteBLL : ICliente, IDisposable
    {
        ClienteDAO db = new ClienteDAO();
       
        public int Agregar(Cliente cliente, List<Mascota> mascotas)
        {
           return db.Agregar(cliente, mascotas);
        }

        public DataTable BuscarApellidos(Cliente cliente)
        {
            return db.BuscarApellidos(cliente);
        }

        public DataTable BuscarDni(Cliente cliente)
        {
            return db.BuscarDni(cliente);
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
            return db.ConsultaDNI(dni);
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
        // ~ClienteBLL() {
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
