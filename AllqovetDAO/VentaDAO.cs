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
  public class VentaDAO : IVenta,IDisposable
    {
        string cnx = Conexion.ObtenerConexion();

        public int Agregar(Venta venta, List<DetalleVenta> detalleVentas, List<ProductoVitrina> productoVitrinas, Movimiento movimiento, List<Salida> salidas)
            //orden: se registra la venta ,  detalle venta, Actualiza Stock, registra movimiento, detalle movimiento como salida 
        {
            MySqlConnection cn = new MySqlConnection(cnx);
            cn.Open();
            MySqlTransaction transaccion = cn.BeginTransaction();
            int r = 0;
            int idventa = 0;
            int idmov = 0;


            using (MySqlCommand cmd = new MySqlCommand("sp_RegistrarVenta", cn, transaccion)) //1 REGISTRA VENTA
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pSerie", venta.serie);
                cmd.Parameters.AddWithValue("pNumero", venta.numero);
                cmd.Parameters.AddWithValue("pIdcliente", venta.Idcliente);
                cmd.Parameters.AddWithValue("pIdtrabajador", venta.Idtrabajador);
                cmd.Parameters.AddWithValue("pTotal", venta.Total);
                cmd.Parameters.AddWithValue("pUtilidad", venta.Utilidad);
                cmd.Parameters.AddWithValue("pIdcajachica", venta.idcajachica);

                cmd.Parameters.Add("pIdventa", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                r = cmd.ExecuteNonQuery();
                idventa = Convert.ToInt32(cmd.Parameters["pIdventa"].Value);
            }

            if (r > 0) //2 REGISTRA DETALLE VENTA
            {
                   
                    DetalleVEntaDAO db = new DetalleVEntaDAO();

                    foreach (DetalleVenta detalleVenta in detalleVentas)
                    {
                        detalleVenta.Idventa = idventa;

                        r = db.Agregar(detalleVenta, ref cn, ref transaccion);
                        if (r != 1)
                        {

                            break;
                        }

                    }

            }

            if (r >0) //3 ACTUALIZA STOCK
            {
                    ProductoVitrinaDAO db = new ProductoVitrinaDAO();
                    foreach (ProductoVitrina productoVitrina in productoVitrinas)
                    {
                        r = db.ActualizaStockSalida(productoVitrina, ref cn, ref transaccion);
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
                    movimiento.Idventa = idventa;
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
                SalidaDAO db = new SalidaDAO();

                foreach (Salida salida in salidas)
                {
                    salida.Idmovimiento = idmov;

                    r = db.Agregar(salida, ref cn, ref transaccion);
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

                return idventa;
            
        }

        public Venta Correlativo()
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_CorrelativoVenta", cn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                
                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        Venta venta = new Venta();

                        while (dr.Read())
                        {
                            venta.serie = dr["serie_venta"].ToString();
                            venta.numero = Convert.ToInt32(dr["numeroventa"]);
                           
                        }

                        return venta;
                    }
                }
            }
        }

        public DataTable ImprimirVenta(int idventa)
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_ImpresionVenta", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pidventa", idventa);
                   
                    cn.Open();
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        return dt;
                    }
                }
            }
        }

        public DataTable BuscarVentaFechas(DateTime desde, DateTime hasta)
        {

            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_BuscarVentaFechas", cn))

                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("fdesde", desde);
                    cmd.Parameters.AddWithValue("fhasta", hasta);
                    cn.Open();
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        return dt;
                    }
                }
            }
        }

        public DataTable ReporteVentas(DateTime desde, DateTime hasta)
        {

            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_ReporteVentas", cn))

                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("fdesde", desde);
                    cmd.Parameters.AddWithValue("fhasta", hasta);
                    cn.Open();
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        return dt;
                    }
                }
            }
        }
        public DataTable BuscarVentaApellidos(string apellido)
        {

            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_BuscarVentaApellidos", cn))

                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pbuscar", apellido);

                    cn.Open();
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        return dt;
                    }
                }
            }
        }

        public DataTable DetalleVenta(int idventa)
        {

            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_DetalleVenta", cn))

                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pIdventa", idventa);

                    cn.Open();
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        return dt;
                    }
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
        // ~VentaDAO() {
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
