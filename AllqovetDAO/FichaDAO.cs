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
    public class FichaDAO : IFicha,IDisposable
    {
        string cnx = Conexion.ObtenerConexion();

        public int Agregar(Ficha ficha, List<DetalleFicha> detalleFichas)
        {
            MySqlConnection cn = new MySqlConnection(cnx);
            cn.Open();
            MySqlTransaction transaccion = cn.BeginTransaction();
            int r = 0;
            int idficha = 0;



            using (MySqlCommand cmd = new MySqlCommand("sp_RegistrarFicha", cn, transaccion))
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pNumero", ficha.numero);
                cmd.Parameters.AddWithValue("pIdmascota", ficha.Idmascota);
                cmd.Parameters.AddWithValue("pIdcliente", ficha.Idcliente);

                cmd.Parameters.Add("pIdficha", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                r = cmd.ExecuteNonQuery();

                if (r > 0)
                {
                    idficha = Convert.ToInt32(cmd.Parameters["pIdficha"].Value);
                    DetalleFichaDAO db = new DetalleFichaDAO();

                    foreach (DetalleFicha detalleFicha in detalleFichas)
                    {
                        detalleFicha.idficha = idficha;

                        r = db.Agregar(detalleFicha, ref cn, ref transaccion);
                        if (r != 1)
                        {

                            break;
                        }

                    }


                }


                if (r == 1)
                {
                    transaccion.Commit();
                    cn.Close();
                }
                else
                {

                    transaccion.Rollback();
                }

                return idficha;
            }
        }

        public DataTable Buscar(Ficha ficha)
        {
            throw new NotImplementedException();
        }

        public int Editar(Ficha ficha, List<DetalleFicha> detalleFichas)
        {
            MySqlConnection cn = new MySqlConnection(cnx);
            cn.Open();
            MySqlTransaction transaccion = cn.BeginTransaction();
            int r = 0;


            using (MySqlCommand cmd = new MySqlCommand("sp_EditarFicha", cn, transaccion))
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pIdficha", ficha.Idficha);
                cmd.Parameters.AddWithValue("pIdmascota", ficha.Idmascota);
                cmd.Parameters.AddWithValue("pIdcliente", ficha.Idcliente);

                r = cmd.ExecuteNonQuery();

                if (r > 0)
                {

                    DetalleFichaDAO db = new DetalleFichaDAO();

                    foreach (DetalleFicha detalleFicha in detalleFichas)
                    {
                        detalleFicha.idficha = ficha.Idficha;

                        r = db.Agregar(detalleFicha, ref cn, ref transaccion);
                        if (r != 1)
                        {

                            break;
                        }

                    }


                }


                if (r == 1)
                {
                    transaccion.Commit();
                    cn.Close();
                }
                else
                {

                    transaccion.Rollback();
                }

                return r;
            }
        }

        public DataTable Imprimir(int idficha)
        {

            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_ImprimirFicha", cn))

                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pIdficha", idficha);

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

        public string CorrelativoFicha()
        {
            string numero = "";
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                cn.Open();
                using (MySqlCommand cmd = new MySqlCommand("sp_CorrelativoFicha", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            numero = dr["numeroficha"].ToString();
                        }

                        return numero;
                    }
                }
            }
        }

        public DataTable Listar()
        {
            throw new NotImplementedException();
        }

        public DataTable BuscarFichaApellido(string apellido)
        {

            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_BuscarFichaApellido", cn))

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

        public DataTable BuscarFichaDNI(string dni)
        {

            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_BuscarFichaDNI", cn))

                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pbuscar", dni);

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

        public DataTable BuscarFichaFechas(DateTime desde, DateTime hasta)
        {

            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_BuscarFichaFechas", cn))

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
        public DataTable BuscarFichaID(int idficha)
        {

            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_BuscarFichaID", cn))

                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pIdficha", idficha);

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
        // ~FichaDAO() {
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
