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
    public class BoletaDAO : IBoleta,IDisposable
    {
        string cnx = Conexion.ObtenerConexion();

        public int Agregar(Boleta boleta, List<DetalleBoleta> detalleBoletas)
        {
            MySqlConnection cn = new MySqlConnection(cnx);
            cn.Open();
            MySqlTransaction transaccion = cn.BeginTransaction();
            int r = 0;
            int idboleta = 0;

            using (MySqlCommand cmd = new MySqlCommand("sp_RegistrarBoleta", cn, transaccion)) //1 REGISTRA boleta
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pSerie", boleta.serie);
                cmd.Parameters.AddWithValue("pNumero", boleta.numero);
                cmd.Parameters.AddWithValue("pIdventa", boleta.Idventa);
                cmd.Parameters.AddWithValue("pTotal", boleta.Total);
               
                cmd.Parameters.Add("pIdboleta", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                r = cmd.ExecuteNonQuery();
                idboleta = Convert.ToInt32(cmd.Parameters["pIdboleta"].Value);
            }

            if (r > 0) //2 REGISTRA DETALLE boleta
            {

                DetalleBoletaDAO db = new DetalleBoletaDAO();

                foreach (DetalleBoleta detalleBoleta  in detalleBoletas)
                {
                    detalleBoleta.Idboleta = idboleta;

                    r = db.Agregar(detalleBoleta, ref cn, ref transaccion);
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

            return idboleta;


        }

        public DataTable BuscarBoletaApellidos(string apellido)
        {
            throw new NotImplementedException();
        }

        public DataTable BuscarBoletaFechas(DateTime desde, DateTime hasta)
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_BuscarBoletaFechas", cn))

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

        public Boleta Correlativo()
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_CorrelativoBoleta", cn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        Boleta boleta = new Boleta();

                        while (dr.Read())
                        {
                            boleta.serie = dr["serie_boleta"].ToString();
                            boleta.numero = Convert.ToInt32(dr["numeroboleta"]);

                        }

                        return boleta;
                    }
                }
            }
        }

        public DataTable DetalleBoleta(int idboleta)
        {
            throw new NotImplementedException();
        }

        public DataTable ImprimiBoleta(int idboleta)
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_ImprimirBoleta", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pIdboleta", idboleta);
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
        // ~BoletaDAO() {
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
