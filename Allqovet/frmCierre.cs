using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AllqovetBLL;

namespace Allqovet
{
    public partial class frmCierre : Form
    {
        public frmCierre()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCierre_Load(object sender, EventArgs e)
        {
           
        }


        private void VentasCierre()
        {
            using (CategoriaBLL db=new CategoriaBLL())
            {
                try
                {
                    dataGridView2.DataSource = db.Listar();

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Detallecobros()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            VentasCierre();
        }
    }
}
