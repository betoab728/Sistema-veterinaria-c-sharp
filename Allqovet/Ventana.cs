using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Allqovet
{
  public  class Ventana
    {
        private Form formActual;

        public void AbrirFormHijo(Form frm)
        {
            frmMenu menu = Application.OpenForms.OfType<frmMenu>().SingleOrDefault();

            formActual = frm;
            frm.TopLevel = false;
            //frm.Dock = DockStyle.Fill;
            menu.panelEscritorio.Controls.Add(frm);
            menu.panelEscritorio.Tag = frm;
            frm.BringToFront();
            frm.SetDesktopLocation((menu.panelEscritorio.Width - frm.Width) / 2, (menu.panelEscritorio.Height - frm.Height) / 2);
            frm.Show();
        }
    }
}
