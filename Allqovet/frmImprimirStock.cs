using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Allqovet
{
    public partial class frmImprimirStock : Form
    {
        public frmImprimirStock()
        {
            InitializeComponent();
        }

        private void frmImprimirStock_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
