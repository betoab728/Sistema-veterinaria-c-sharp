using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;


namespace Interfaces
{
    public interface ICita
    {
        int Agregar(Cita cita );
        DataTable Listar();
        int Editar(Cita cita);
        int Eliminar(Cita cita);
        DataTable ListarCitaFecha(DateTime fecha);
        int AtenderCita(int idcita);
        int AnularCita(int idcita);


    }
}
