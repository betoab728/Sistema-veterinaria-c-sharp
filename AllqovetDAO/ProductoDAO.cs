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
    public class ProductoDAO : IProducto, IDisposable
    {
        String cnx = Conexion.ObtenerConexion();

        public int Agregar(Producto producto,ProductoVitrina productoVitrina)
        {

            MySqlConnection cn = new MySqlConnection(cnx);
            cn.Open();
            MySqlTransaction transaccion = cn.BeginTransaction();
            int r = 0;
            int idproducto = 0;

           
            using (MySqlCommand cmd = new MySqlCommand("sp_RegistrarProducto", cn, transaccion))
            {
               
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pDescripcion", producto.Descripcion);
                cmd.Parameters.AddWithValue("pIdmarca", producto.Idmarca);
                cmd.Parameters.AddWithValue("pIdcategoria", producto.Idcategoria);
                cmd.Parameters.AddWithValue("pPrecioCosto", producto.PrecioCosto);
                cmd.Parameters.AddWithValue("pPrecioVenta", producto.PrecioVenta);
                cmd.Parameters.AddWithValue("pFechaVencimiento", producto.FechaVencimiento);
                cmd.Parameters.AddWithValue("pCodigo", producto.codigo);
                cmd.Parameters.AddWithValue("pManejaStock", producto.Manejastock);
                cmd.Parameters.AddWithValue("pStockMinimo", producto.Stokcminimo);

                cmd.Parameters.Add("pIdproducto", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                r = cmd.ExecuteNonQuery();
                idproducto = Convert.ToInt32(cmd.Parameters["pIdproducto"].Value);


            }
            if (r > 0) //registro la ubicacion del producto
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_RegistrarUbicacion", cn, transaccion))
                {
                
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pIdproducto", idproducto);
                    cmd.Parameters.AddWithValue("pIdvitrina", productoVitrina.Idvitrina);
                    r = cmd.ExecuteNonQuery();

                }
            }
            if (r>0) //6 EJECUTA TRANSACCION
            {
                transaccion.Commit();
                cn.Close();
            }
            else
            {

                transaccion.Rollback();
            }

            return idproducto;


        }

        public int AgregarServicio(Producto producto)
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_RegistrarProducto", cn))
                {
                    int idproducto = 0;
                    cn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pDescripcion", producto.Descripcion);
                    cmd.Parameters.AddWithValue("pIdmarca", producto.Idmarca);
                    cmd.Parameters.AddWithValue("pIdcategoria", producto.Idcategoria);
                    cmd.Parameters.AddWithValue("pPrecioCosto", producto.PrecioCosto);
                    cmd.Parameters.AddWithValue("pPrecioVenta", producto.PrecioVenta);
                    cmd.Parameters.AddWithValue("pFechaVencimiento", producto.FechaVencimiento);
                    cmd.Parameters.AddWithValue("pCodigo", producto.codigo);
                    cmd.Parameters.AddWithValue("pManejaStock", producto.Manejastock);
                    cmd.Parameters.AddWithValue("pStockMinimo", producto.Stokcminimo);

                    cmd.Parameters.Add("pIdproducto", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    int r = cmd.ExecuteNonQuery();
                    idproducto = Convert.ToInt32(cmd.Parameters["pIdproducto"].Value);


                    return idproducto;
                }
            }
        }

        public DataTable Buscar(Producto producto)
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_BuscarProducto", cn))

                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pBuscar", producto.Descripcion);

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
        public DataTable BuscarProductoCodigo(string codigo)
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_BuscarProductoCodigo", cn))

                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pCodigo", codigo);

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

        public DataTable ReporteStock(int idmarca,int idcategoria,int idvitrina,int stock)
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_ReporteStock", cn))

                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pIdmarca", idmarca);
                    cmd.Parameters.AddWithValue("pIdcategoria", idcategoria);
                    cmd.Parameters.AddWithValue("pIdvitrina", idvitrina);
                    cmd.Parameters.AddWithValue("pstock", stock);

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

        public int Editar(Producto producto)
        {
            throw new NotImplementedException();
        }

        public DataTable Listar()
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
        // ~ProductoDAO() {
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
