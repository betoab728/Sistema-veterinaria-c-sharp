using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Allqovet
{
    public partial class frmBackup : Form
    {
        public frmBackup()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string database = "allqovet";
            string user = "adming";
            string passw = "Utp+Integrador#37646*";
            string server = "grupoctc.ddns.net";
            string destino = @"C:\Users\ELIAS\Desktop\loginpage-main";

            BackupDatabase(database, destino, user, passw, server);

        }

        private void BackupDatabase(string databaseName, string backupFilePath, string username, string password, string serverAddress )
        {
            try
            {
                string mysqldumpPath = @"C:\Users\ELIAS\Documents\bin\mysqldump.exe"; // Ruta completa del archivo mysqldump.exe
                string arguments = $"--user={username} --password={password} --host={serverAddress} --protocol=tcp --port=3306 --default-character-set=utf8 --result-file=\"{backupFilePath}\" --databases {databaseName}";

                ProcessStartInfo psi = new ProcessStartInfo(mysqldumpPath, arguments)
                {
                    RedirectStandardInput = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    UseShellExecute = false
                };

                Process process = new Process
                {
                    StartInfo = psi
                };

                process.Start();
                process.WaitForExit();
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir durante el proceso de respaldo.
                MessageBox.Show("Error al realizar el backup: " + ex.Message);
               // Console.WriteLine("Error al realizar el backup: " + ex.Message);
            }
        }

}
}
