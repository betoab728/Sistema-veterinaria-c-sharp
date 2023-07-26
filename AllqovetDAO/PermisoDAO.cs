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
    public class PermisoDAO : IPermiso,IDisposable
    {
        string cnx = Conexion.ObtenerConexion();

        public int ActualizarPermisoMenu(PermisoMenu permiso,PermisoSubMenu permisoSub)
        {
            MySqlConnection cn = new MySqlConnection(cnx);
            cn.Open();
            MySqlTransaction transaccion = cn.BeginTransaction();
            int r = 0;

           
                using (MySqlCommand cmd = new MySqlCommand("sp_ActualizarPermisosMenu", cn, transaccion))
                {
                  
                  
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pIdnivel", permiso.idnivel);
                    cmd.Parameters.AddWithValue("pValor1", permiso.valor1);
                    cmd.Parameters.AddWithValue("pValor2", permiso.valor2);
                    cmd.Parameters.AddWithValue("pValor3", permiso.valor3);
                    cmd.Parameters.AddWithValue("pValor4", permiso.valor4);
                    cmd.Parameters.AddWithValue("pValor5", permiso.valor5);
                    cmd.Parameters.AddWithValue("pValor6", permiso.valor6);
                    cmd.Parameters.AddWithValue("pValor7", permiso.valor7);
                    cmd.Parameters.AddWithValue("pValor8", permiso.valor8);
                    cmd.Parameters.AddWithValue("pValor9", permiso.valor9);

                   r=  cmd.ExecuteNonQuery();

                }

            if (r > 0)
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_ActualizarPermisosSubMenu", cn, transaccion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pIdnivel", permisoSub.idnivel);
                    cmd.Parameters.AddWithValue("pValor1", permisoSub.valor1);
                    cmd.Parameters.AddWithValue("pValor2", permisoSub.valor2);
                    cmd.Parameters.AddWithValue("pValor3", permisoSub.valor3);
                    cmd.Parameters.AddWithValue("pValor4", permisoSub.valor4);
                    cmd.Parameters.AddWithValue("pValor5", permisoSub.valor5);
                    cmd.Parameters.AddWithValue("pValor6", permisoSub.valor6);
                    cmd.Parameters.AddWithValue("pValor7", permisoSub.valor7);
                    cmd.Parameters.AddWithValue("pValor8", permisoSub.valor8);
                    cmd.Parameters.AddWithValue("pValor9", permisoSub.valor9);
                    cmd.Parameters.AddWithValue("pValor10", permisoSub.valor10);
                    cmd.Parameters.AddWithValue("pValor11", permisoSub.valor11);
                    cmd.Parameters.AddWithValue("pValor12", permisoSub.valor12);
                    cmd.Parameters.AddWithValue("pValor13", permisoSub.valor13);
                    cmd.Parameters.AddWithValue("pValor14", permisoSub.valor14);
                    cmd.Parameters.AddWithValue("pValor15", permisoSub.valor15);
                    cmd.Parameters.AddWithValue("pValor16", permisoSub.valor16);
                    cmd.Parameters.AddWithValue("pValor17", permisoSub.valor17);
                    cmd.Parameters.AddWithValue("pValor18", permisoSub.valor18);
                    cmd.Parameters.AddWithValue("pValor19", permisoSub.valor19);
                    cmd.Parameters.AddWithValue("pValor20", permisoSub.valor20);
                    cmd.Parameters.AddWithValue("pValor21", permisoSub.valor21);
                    cmd.Parameters.AddWithValue("pValor22", permisoSub.valor22);
                    cmd.Parameters.AddWithValue("pValor23", permisoSub.valor23);
                    cmd.Parameters.AddWithValue("pValor24", permisoSub.valor24);
                    cmd.Parameters.AddWithValue("pValor25", permisoSub.valor25);
                    cmd.Parameters.AddWithValue("pValor26", permisoSub.valor26);
                    cmd.Parameters.AddWithValue("pValor27", permisoSub.valor27);
                    cmd.Parameters.AddWithValue("pValor28", permisoSub.valor28);
                    cmd.Parameters.AddWithValue("pValor29", permisoSub.valor29);
                    cmd.Parameters.AddWithValue("pValor30", permisoSub.valor30);
                    cmd.Parameters.AddWithValue("pValor31", permisoSub.valor31);

                    r = cmd.ExecuteNonQuery();
                }
            }

                if (r > 0) //6 EJECUTA TRANSACCION
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

        public int ActualizarPermisoSubMenu(PermisoMenu permiso)
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_ActualizarPermisosMenu", cn))
                {

                    cn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pIdnivel", permiso.idnivel);
                    cmd.Parameters.AddWithValue("pValor1", permiso.valor1);
                    cmd.Parameters.AddWithValue("pValor2", permiso.valor2);
                    cmd.Parameters.AddWithValue("pValor3", permiso.valor3);
                    cmd.Parameters.AddWithValue("pValor4", permiso.valor4);
                    cmd.Parameters.AddWithValue("pValor5", permiso.valor5);
                    cmd.Parameters.AddWithValue("pValor6", permiso.valor6);
                    cmd.Parameters.AddWithValue("pValor7", permiso.valor7);
                    cmd.Parameters.AddWithValue("pValor8", permiso.valor8);
                    cmd.Parameters.AddWithValue("pValor9", permiso.valor9);

                    return cmd.ExecuteNonQuery();

                }
            }
        }


        public DataTable LeerPermisos(Usuario usuario)
        {
            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_LeerPermisos", cn))
                {

                 
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pidnivel", usuario.Idnivelacceso);
                 
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
        // ~PermisoDAO() {
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
