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
  public  class TrabajadorDAO : ITrabajador,IDisposable
    {
        string cnx = Conexion.ObtenerConexion();

        public int Agregar(Trabajador trabajador)
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_RegistrarTrabajador", cn))
                {

                    cn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pdni", trabajador.DNI);
                    cmd.Parameters.AddWithValue("pApepaterno", trabajador.ApellidoPaterno);
                    cmd.Parameters.AddWithValue("pApematerno", trabajador.ApellidoMaterno);
                    cmd.Parameters.AddWithValue("pNombres", trabajador.Nombres);
                    cmd.Parameters.AddWithValue("psexo", trabajador.sexo);
                    cmd.Parameters.AddWithValue("pFechaNac", trabajador.FechaNacimiento);
                    cmd.Parameters.AddWithValue("pFechaIng", trabajador.FechaIngreso);
                    cmd.Parameters.AddWithValue("piddcargo", trabajador.idcargo);
                    cmd.Parameters.AddWithValue("pfechacese", trabajador.FechaCese);
                    cmd.Parameters.AddWithValue("pDireccion", trabajador.direccion);
                    cmd.Parameters.AddWithValue("ptelefono", trabajador.telefono);
                    cmd.Parameters.AddWithValue("pcorreo", trabajador.correo);
                                       
                    return cmd.ExecuteNonQuery();
                    
                }
            }
        }

        public int Editar(Trabajador trabajador)
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_EditarTrabajador", cn))
                {

                    cn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pdni", trabajador.DNI);
                    cmd.Parameters.AddWithValue("pApepaterno", trabajador.ApellidoPaterno);
                    cmd.Parameters.AddWithValue("pApematerno", trabajador.ApellidoMaterno);
                    cmd.Parameters.AddWithValue("pNombres", trabajador.Nombres);
                    cmd.Parameters.AddWithValue("pDireccion", trabajador.direccion);
                    cmd.Parameters.AddWithValue("ptelefono", trabajador.telefono);
                    cmd.Parameters.AddWithValue("pcorreo", trabajador.correo);
                    cmd.Parameters.AddWithValue("pidtrabajador", trabajador.Idtrabajador);
                    cmd.Parameters.AddWithValue("pEstado", trabajador.estado);

                    cmd.Parameters.AddWithValue("psexo", trabajador.sexo);
                    cmd.Parameters.AddWithValue("pFechaNac", trabajador.FechaNacimiento);
                    cmd.Parameters.AddWithValue("pFechaIng", trabajador.FechaIngreso);
                    cmd.Parameters.AddWithValue("pidcargo", trabajador.idcargo);
                    cmd.Parameters.AddWithValue("pfechacese", trabajador.FechaCese);
                   
                  
                  
                 

                    return cmd.ExecuteNonQuery();

                }
            }
        }

        public DataTable Listar()
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_ListarTrabajadores", cn))

                {
                    cmd.CommandType = CommandType.StoredProcedure;
                  
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

        public DataTable ListarNombres()
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_ListarNombresTrabajador", cn))

                {
                    cmd.CommandType = CommandType.StoredProcedure;

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
        // ~TrabajadorDAO() {
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
