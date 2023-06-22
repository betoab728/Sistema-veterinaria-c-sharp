using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Interfaces;
using MySql.Data.MySqlClient;

namespace AllqovetDAO
{
    public class PedidoDAO : IPedido, IDisposable
    {
        string cnx = Conexion.ObtenerConexion();
        public int Agregar(Pedido pedido, List<DetallePedido> detallepedido, List<ProductoVitrina> productoVitrinas, Movimiento movimiento, List<Entrada> entrada)
        {
            MySqlConnection cn = new MySqlConnection(cnx);
            cn.Open();
            MySqlTransaction transaccion = cn.BeginTransaction();
            int r = 0;
            int idPedido = 0;
            int idmov = 0;


            using (MySqlCommand cmd = new MySqlCommand("sp_RegistrarIngresoProducto", cn, transaccion)) //1 REGISTRA INGRESO
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pFecha", pedido.Fecha);
                cmd.Parameters.AddWithValue("pSerie", pedido.Serie);
                cmd.Parameters.AddWithValue("pNumero", pedido.Numero);
                cmd.Parameters.AddWithValue("pIdproveedor", pedido.idproveedor);
                cmd.Parameters.AddWithValue("pTotal", pedido.Total);


                cmd.Parameters.Add("pIdpedido", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                r = cmd.ExecuteNonQuery();
                idPedido = Convert.ToInt32(cmd.Parameters["pIdpedido"].Value);
            }

            if (r > 0) //2 REGISTRA DETALLE PEDIDO
            {

                DetallePedidoDAO db = new DetallePedidoDAO();

                foreach (DetallePedido detallePedido in detallepedido)
                {
                    detallePedido.Idpedido= idPedido;

                    r = db.Agregar(detallePedido, ref cn, ref transaccion);
                    if (r != 1)
                    {

                        break;
                    }

                }

            }

            if (r > 0) //3 ACTUALIZA STOCK
            {
                ProductoVitrinaDAO db = new ProductoVitrinaDAO();
                foreach (ProductoVitrina productoVitrina in productoVitrinas)
                {
                    r = db.ActualizaStockEntrada(productoVitrina, ref cn, ref transaccion);
                    if (r != 1)
                    {
                        break;
                    }
                }
            }

            if (r > 0) //4 REGSISTRA MOVIMIENTO
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_RegistrarMovimiento", cn, transaccion))
                {
                    movimiento.Idpedido = idPedido;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pTipo", movimiento.Tipo);
                    cmd.Parameters.AddWithValue("pIdventa", movimiento.Idventa);
                    cmd.Parameters.AddWithValue("pIdcausa", movimiento.idcausa);
                    cmd.Parameters.AddWithValue("pCantidad", movimiento.cantidad);

                    cmd.Parameters.Add("pIdmov", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    r = cmd.ExecuteNonQuery();

                    idmov = Convert.ToInt32(cmd.Parameters["pIdmov"].Value);
                }
            }

            if (r > 0) //5 REGSISTRA MOVIMIENTO SALIDA
            {
                EntradaDAO db = new EntradaDAO();

                foreach (Entrada Entrada in entrada)
                {
                    Entrada.Idmovimiento = idmov;

                    r = db.Agregar(Entrada, ref cn, ref transaccion);
                    if (r != 1)
                    {

                        break;
                    }

                }
            }


            if (r == 1) //6 EJECUTA TRANSACCION
            {
                transaccion.Commit();
                cn.Close();
            }
            else
            {

                transaccion.Rollback();
            }

            return idPedido;


            throw new NotImplementedException();
        }
           

        public DataTable DetallePedido(int idPedido)
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
        // ~PedidoDAO() {
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
