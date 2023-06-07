using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AllqovetDAO
{
  public static class Conexion
    {
        private static string Cadenaconexion()
        {
            return AllqovetDAO.Properties.Settings.Default.cnx;
        }

        private  class DatosConexion
        {
            public string server { get; set; }
            public string user { get; set; }
            public string password { get; set; }
        }

        public static String ObtenerConexion()
        {
            String cnx = "";
            String cd = "Server=grupoctc.ddns.net;Database=allqovet; Uid=admin;Pwd=Utp+Integrador#37646*;";
            try
            {
                // Ruta del archivo JSON
                string filePath = @"C:\integrador.json";

                // Leer el contenido del archivo JSON
                string jsonString = File.ReadAllText(filePath);

                // Deserializar el JSON a un objeto
                DatosConexion datos = JsonConvert.DeserializeObject<DatosConexion>(jsonString);

                cnx = Cadenaconexion().Replace("SERVER", datos.server);
                cnx = cnx.Replace("USER", datos.user);
                cnx = cnx.Replace("PASSWORD", datos.password);
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al leer el archivo JSON: " + ex.Message);
            }

            return cd;
        }


    }
}
