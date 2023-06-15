using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Interfaces;
using AllqovetDAO;
using static AllqovetDAO.DashboardDAO;

namespace AllqovetBLL
{
    public class DashboardBLL : IDashboard, IDisposable

    {
        DashboardDAO db = new DashboardDAO ();

        public int ContarNumClientes()
        {
            return db.ContarNumClientes();
        }

        public int ContarNumProductos()
        {
            return db.ContarNumProductos();
        }

        public int ContarNumProveedores()
        {
            return db.ContarNumProveedores();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public DataTable Stock()
        {
            return db.Stock();
        }

        public DataTable TopProd(DashBoard dashBoard)
        {
            return db.TopProd(dashBoard);
        }
    }
}
