using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Mail;

namespace Allqovet
{
    public partial class frmImprimirBoleta : Form
    {
        public string ruta;

        private string emailorigen = "centroveterinarioallqovet@gmail.com";
        private string passw = "vwydcsejgelyuahf";

        public frmImprimirBoleta()
        {
            InitializeComponent();
        }

        private void frmImprimirBoleta_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void EnviarCorreo()
        {
            if (txtcorreo.Text.Length == 0)
            {
                MessageBox.Show("el correo electronico del cliente no es valido");
                return;
            }
            try
            {
               
                File.WriteAllBytes(ruta, reportViewer1.LocalReport.Render("PDF"));

                DialogResult dialogResult = MessageBox.Show("¿Enviar por correo electronico al cliente?", "Enviar comprobante", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {

                    string path = ruta;
                    MailMessage mensaje = new MailMessage(emailorigen, txtcorreo.Text, "Su boleta electronica", "Gracias por su compra");
                    mensaje.Attachments.Add(new Attachment(path));
                    SmtpClient mismtp = new SmtpClient("smtp.gmail.com");
                    mismtp.EnableSsl = true;
                    mismtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    mismtp.UseDefaultCredentials = false;
                    mismtp.Port = 587;
                    mismtp.Credentials = new System.Net.NetworkCredential(emailorigen, passw);

                    mismtp.Send(mensaje);
                    mismtp.Dispose();
                    MessageBox.Show("Enviado");

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EnviarCorreo();
        }
    }
}
