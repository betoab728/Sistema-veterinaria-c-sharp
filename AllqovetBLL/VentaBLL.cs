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
    public class VentaBLL : IVenta,IDisposable
    {
        VentaDAO db = new VentaDAO();
        public int Agregar(Venta venta, List<DetalleVenta> detalleVentas, List<ProductoVitrina> productoVitrinas, Movimiento movimiento, List<Salida> salidas)
        {
           return db.Agregar(venta, detalleVentas, productoVitrinas, movimiento, salidas) ;
        }

        public Venta Correlativo()
        {
           return db.Correlativo();
        }

        public DataTable ImprimirVenta(int idventa)
        {
            return db.ImprimirVenta(idventa);
        }

        public DataTable BuscarVentaFechas(DateTime desde, DateTime hasta)
        {
            return db.BuscarVentaFechas(desde, hasta);
        }
        public DataTable BuscarVentaApellidos(string apellido)
        {
            return db.BuscarVentaApellidos(apellido);
        }
        public DataTable DetalleVenta(int idventa)
        {
            return db.DetalleVenta(idventa);
        }

        public DataTable ReporteVentas(DateTime desde, DateTime hasta)
        {

            return db.ReporteVentas(desde,hasta);
        }


        public int AnularVenta(Venta venta, List<ProductoVitrina> listado)
        {
            return db.AnularVenta(venta, listado);
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
        // ~VentaBLL() {
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
