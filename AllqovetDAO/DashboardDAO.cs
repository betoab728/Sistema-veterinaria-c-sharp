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
    public class DashboardDAO : IDashboard, IDisposable
    {

        string cnx = Conexion.ObtenerConexion();

        public int ContarNumClientes()
        {
            int numClientes = 0;

            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_ContarNumClientes", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    //El sp devuelve un único valor entero 
                    numClientes = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }


            return numClientes;
        }

        public int ContarNumProductos()
        {
            int numProductos = 0;

            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_ContarNumMascotas", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    //El sp devuelve un único valor entero 
                    numProductos = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            return numProductos;
        }

        public int ContarNumProveedores()
        {
            int numProveedores = 0;

            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_ContarNumProveedores", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    //El sp devuelve un único valor entero 
                    numProveedores = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            return numProveedores;
        }

        public void Dispose()
        {
            // No se requiere ninguna operación para liberar/recuperar recursos en este caso
        }

        public DataTable Stock()
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_BajoStock", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();

                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        public DataTable TopProductos(DateTime fromDate, DateTime toDate)
        {
            DataTable dataTable = new DataTable();
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_TopProductos", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("fromDate", fromDate);
                    cmd.Parameters.AddWithValue("toDate", toDate);
                    cn.Open();

                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dataTable);
                    }   
                }
            }

            return dataTable;
        }
    }
}
