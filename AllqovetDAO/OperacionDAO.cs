using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Interfaces;
using MySql.Data.MySqlClient;
using System.Data;


namespace AllqovetDAO
{
    public class OperacionDAO : IOperacion, IDisposable
    {
        string cnx = Conexion.ObtenerConexion();

        public int Agregar(Operacion operacion)
        {
            throw new NotImplementedException(); 
        }

        public int  AgregarPagoVenta  (Operacion operacion)
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_RegistrarPagoVenta", cn))
                {
                    cn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pConcepto", operacion.Concepto);
                    cmd.Parameters.AddWithValue("ptipo", operacion.Tipo);
                    cmd.Parameters.AddWithValue("pIdmediopago", operacion.Idmediopago);
                    cmd.Parameters.AddWithValue("pImporte", operacion.Importe);
                    cmd.Parameters.AddWithValue("pDigitostarjeta", operacion.Digitostarjeta);
                    cmd.Parameters.AddWithValue("pIdventa", operacion.Idventa);
                    cmd.Parameters.AddWithValue("pIdcajachica", operacion.Idcajachica);
                    cmd.Parameters.AddWithValue("pIdtipo", operacion.idtipo);

                    int r = cmd.ExecuteNonQuery();

                    return r;
                }
            }
        }

        public int AgregarMovimiento(Operacion operacion)
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("RegistrarMovimientoCaja", cn))
                {
                    cn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pFecha", operacion.fecha);
                    cmd.Parameters.AddWithValue("pConcepto", operacion.Concepto);
                    cmd.Parameters.AddWithValue("pTipo", operacion.Tipo);
                    cmd.Parameters.AddWithValue("pIdmediopago", operacion.Idmediopago);
                    cmd.Parameters.AddWithValue("pImporte", operacion.Importe);
                    cmd.Parameters.AddWithValue("pIdcajachica", operacion.Idcajachica);
                    cmd.Parameters.AddWithValue("pIdtipo", operacion.idtipo);
                    cmd.Parameters.AddWithValue("pIddocumento", operacion.iddocumento);
                    cmd.Parameters.AddWithValue("pSerie", operacion.serie);
                    cmd.Parameters.AddWithValue("pNumero", operacion.numero);


                    int r = cmd.ExecuteNonQuery();

                    return r;
                }
            }
        }


        public int ActualizarMovimientoCaja(Operacion operacion)
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_ActualizarMovimientoCaja", cn))
                {
                    cn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pFecha", operacion.fecha);
                    cmd.Parameters.AddWithValue("pConcepto", operacion.Concepto);
                    cmd.Parameters.AddWithValue("pTipo", operacion.Tipo);
                    cmd.Parameters.AddWithValue("pIdmediopago", operacion.Idmediopago);
                    cmd.Parameters.AddWithValue("pImporte", operacion.Importe);
                    cmd.Parameters.AddWithValue("pIdcajachica", operacion.Idcajachica);
                    cmd.Parameters.AddWithValue("pIdtipo", operacion.idtipo);
                    cmd.Parameters.AddWithValue("pIddocumento", operacion.iddocumento);
                    cmd.Parameters.AddWithValue("pSerie", operacion.serie);
                    cmd.Parameters.AddWithValue("pNumero", operacion.numero);
                    cmd.Parameters.AddWithValue("pIdoperacion", operacion.Idoperacion);


                    int r = cmd.ExecuteNonQuery();

                    return r;
                }
            }
        }

        public DataTable BuscarMovCajaFechas(DateTime desde,DateTime hasta , int idmediopago,int idtipoOperacion)
        {


            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_BuscarMovCajaFechas", cn))

                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("desde", desde);
                    cmd.Parameters.AddWithValue("hasta", hasta);
                    cmd.Parameters.AddWithValue("pIdmediopago", idmediopago);
                    cmd.Parameters.AddWithValue("pIdtipoOperacion", idtipoOperacion);

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

        public DataTable BuscarMovCajaActual(int idcajachica,int idmediopago,int idTipoOperacion)
        {


            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_BuscarMovCajaActual", cn))

                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pIdcajachica", idcajachica);
                    cmd.Parameters.AddWithValue("pIdmediopago", idmediopago);
                    cmd.Parameters.AddWithValue("pIdtipoOperacion", idTipoOperacion);

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

        public Operacion MostrarRegistro(int idopereacion)
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_BuscarOperacion", cn))

                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pIdoperacion", idopereacion);
                   

                    cn.Open();

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        Operacion operacion  = new Operacion();

                        while (dr.Read())
                        {

                              operacion.fecha = Convert.ToDateTime(dr["fecha"]);
                              operacion.Concepto = dr["Concepto"].ToString();
                              operacion.Tipo = dr["Tipo"].ToString();
                              operacion.Idmediopago = Convert.ToInt32( dr["Idmediopago"]);
                              operacion.Importe =Convert.ToDouble(dr["Importe"]);
                              operacion.idtipo = Convert.ToInt32( dr["idtipo"]);
                              operacion.iddocumento = Convert.ToInt32(dr["iddocumento"]);
                              operacion.serie = dr["serie"].ToString();
                              operacion.numero = Convert.ToInt32( dr["numero"]);


                        }

                        return operacion;
                    }
                }
            }
        }
        

        public int Anular(int Idoperacion)
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_AnularMovcaja", cn))
                {
                    cn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pIdoperacion", Idoperacion);
                 
                    int r = cmd.ExecuteNonQuery();

                    return r;
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
        // ~OperacionDAO() {
        //   // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
        //   Dispose(false);
        // }

        // Este código se agrega para implementar correctamente el patrón descartable.
        void IDisposable.Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
            Dispose(true);
            // TODO: quite la marca de comentario de la siguiente línea si el finalizador se ha reemplazado antes.
             GC.SuppressFinalize(this);
        }
        #endregion
    }
}
