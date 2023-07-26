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
  public  class FacturaDAO : IFactura,IDisposable
    {
        string cnx = Conexion.ObtenerConexion();

        public int Agregar(Factura factura, List<DetalleFactura> detalleFacturas)
        {
            MySqlConnection cn = new MySqlConnection(cnx);
            cn.Open();
            MySqlTransaction transaccion = cn.BeginTransaction();
            int r = 0;
            int idfactura = 0;

            using (MySqlCommand cmd = new MySqlCommand("sp_RegistrarFactura", cn, transaccion)) //1 REGISTRA factura
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pSerie", factura.Serie);
                cmd.Parameters.AddWithValue("pNumero", factura.Numero);
                cmd.Parameters.AddWithValue("pIdventa", factura.Idventa);
                cmd.Parameters.AddWithValue("pTotal", factura.Total);
                cmd.Parameters.AddWithValue("pRuc", factura.ruc);
                cmd.Parameters.AddWithValue("pRazon", factura.razon);
                cmd.Parameters.AddWithValue("pDireccion", factura.direccion);

                cmd.Parameters.Add("pIdfactura", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                r = cmd.ExecuteNonQuery();
                idfactura = Convert.ToInt32(cmd.Parameters["pIdfactura"].Value);
            }

            if (r > 0) //2 REGISTRA DETALLE boleta
            {

                DetalleFacturaDAO db = new DetalleFacturaDAO();

                foreach (DetalleFactura detalleFactura in detalleFacturas)
                {
                    detalleFactura.Idfactura = idfactura;

                    r = db.Agregar(detalleFactura, ref cn, ref transaccion);
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

            return idfactura;
        }

        public DataTable BuscarFacturaFechas(DateTime desde, DateTime hasta)
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_BuscarFacturaFechas", cn))

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

        public DataTable BuscarFacturaRazon(string apellido)
        {
            throw new NotImplementedException();
        }

        public Factura Correlativo()
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_CorrelativoFactura", cn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        Factura factura = new Factura();

                        while (dr.Read())
                        {
                            factura.Serie = dr["serie_factura"].ToString();
                            factura.Numero = Convert.ToInt32(dr["numerofactura"]);

                        }

                        return factura;
                    }
                }
            }
        }

        public DataTable DetalleFactura(int idfactura)
        {
            throw new NotImplementedException();
        }

        public DataTable ImprimiFactura(int idfactura)
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_ImprimirFactura", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pIdFactura", idfactura);

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
        // ~FacturaDAO() {
        //   // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
        //   Dispose(false);
        // }

        // Este código se agrega para implementar correctamente el patrón descartable.
        public void Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
            Dispose(true);
            // TODO: quite la marca de comentario de la siguiente línea si el finalizador se ha reemplazado antes.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
