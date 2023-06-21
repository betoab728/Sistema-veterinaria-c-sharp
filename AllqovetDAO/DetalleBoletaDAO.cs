using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Entidades;
using System.Data;
using MySql.Data.MySqlClient;

namespace AllqovetDAO
{
    public class DetalleBoletaDAO : IDetalleBoleta
    {
        public int Agregar(DetalleBoleta detalleBoleta, ref MySqlConnection con, ref MySqlTransaction transaction)
        {
            using (MySqlCommand cmd = new MySqlCommand("sp_RegistrarDetalleBoleta", con, transaction))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pIdventa", detalleBoleta.Idboleta);
                cmd.Parameters.AddWithValue("pIdproducto", detalleBoleta.Idproducto);
                cmd.Parameters.AddWithValue("pDescripcion", detalleBoleta.Descripcion);
                cmd.Parameters.AddWithValue("pCantidad", detalleBoleta.Cantidad);
                cmd.Parameters.AddWithValue("pPrecio", detalleBoleta.Precio);
               

                return cmd.ExecuteNonQuery();
            }
        }
    }
}
