using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllqovetDAO;
using Entidades;
using Interfaces;


namespace AllqovetBLL
{
    public class DashboardBLL : IDashboard, IDisposable
    {
        DashboardDAO db = new DashboardDAO();

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

        public DataTable TopProductos(DateTime fromDate, DateTime toDate)
        {
            return db.TopProductos(fromDate, toDate);
        }
    }
}
