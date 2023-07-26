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
using System.IO;

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
            string mysqldumpPath = "C:\\bin\\mysqldump.exe"; // Ruta al archivo mysqldump.exe en tu sistema local
            string database = "allqovet";
            string user = "admin";
            string passw = "Utp+Integrador#37646*";
            string server = "grupoctc.ddns.net";
            string fecha = DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ss");
            string destino ="allqovet_" + fecha + ".sql";

            string backupFilePath = Path.Combine(txtruta.Text, destino);
            backupFilePath = Path.GetFullPath(backupFilePath); // Normalizar la ruta

             string destino2 = "C:\\Users\\ELIAS\\Documents\\RiveraBackups\\allqovet_" + fecha+".sql";

            BackupDatabase(mysqldumpPath,database, backupFilePath, user, passw, server);

        }

        private void BackupDatabase(string mysqldumpPath,string databaseName, string backupFilePath, string user, string password, string serverAddress )
        {
            try
            {
                /* string remoteServer = "direccion_ip_servidor"; // Cambia esto por la dirección IP o nombre del servidor remoto
                 string database = "nombre_db";                 // Cambia esto por el nombre de tu base de datos
                 string user = "usuario";                       // Cambia esto por el nombre de usuario de la base de datos remota
                 string password = "contraseña";                // Cambia esto por la contraseña del usuario

                 string mysqldumpPath = "C:\\ruta\\a\\mysqldump.exe"; // Ruta al archivo mysqldump.exe en tu sistema local

                 string backupFileName = "backup.sql"; // Nombre del archivo de respaldo*/
                // Comando para realizar el respaldo utilizando mysqldump.exe
                string command = $"{mysqldumpPath} -u {user} -p{password} -h {serverAddress} {databaseName} > {backupFilePath}";

                // Ejecutar el comando con ProcessStartInfo
                ProcessStartInfo psi = new ProcessStartInfo("cmd.exe", "/C " + command)
                {
                    CreateNoWindow = true,
                    UseShellExecute = false
                };
                Process process = new Process();
                process.StartInfo = psi;
                process.Start();
                process.WaitForExit();

                MessageBox.Show("Copia de seguridad de la base de datos creada correctamente");
            }

            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir durante el proceso de respaldo.
                MessageBox.Show("Error al realizar el backup: " + ex.Message);
               // Console.WriteLine("Error al realizar el backup: " + ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFolder = folderDialog.SelectedPath;
                    txtruta.Text = selectedFolder;
                }
            }
        }
    }
}
