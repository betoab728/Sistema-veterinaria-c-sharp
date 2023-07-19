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
    public class MenuDAO : IMenu,IDisposable
    {
        string cnx = Conexion.ObtenerConexion();

        public List<MenuSistema> ListaMenu(int idusuario)
        {
            List<MenuSistema> ListadoMenu = new List<MenuSistema>();

            using (MySqlConnection cn = new MySqlConnection(cnx))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_ListarMenu", cn))

                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pIdnivel",  idusuario);

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                       
                        while (dr.Read())
                        {
                            MenuSistema menu = new MenuSistema();
                            
                            menu.idmenu =Convert.ToInt32( dr["idmenu"]);
                            menu.nombre = dr["nombre"].ToString();
                            menu.descripcion = dr["descripcion"].ToString();
                            menu.permiso_menu = dr["permiso_menu"].ToString();

                            ListadoMenu.Add(menu);
                        }

                        return ListadoMenu;
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
        // ~MenuDAO() {
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
