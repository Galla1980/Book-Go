using BLL_327LG;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_327LG.GUI_Gestion_Usuarios
{
    public partial class FormBackupRestore_327LG : Form
    {
        BLLBackUpRestore_327LG bllBackUpRestore_327LG = new BLLBackUpRestore_327LG();

        public FormBackupRestore_327LG()
        {
            InitializeComponent();
        }

        private void FormBackupRestore_327LG_Load(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#0c7689");
            lblTitulo.ForeColor = Color.White;
        }

        private void btnElegirRuta_Click(object sender, EventArgs e)
        {
            try
            {
                using (FolderBrowserDialog folderBrowser = new FolderBrowserDialog())
                {
                    if (folderBrowser.ShowDialog() == DialogResult.OK)
                    {
                        txtBackup.Text = folderBrowser.SelectedPath;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en la ruta elegida.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBackup.Text.IsNullOrEmpty()) throw new Exception("Debe seleccionar una ruta.");
                bllBackUpRestore_327LG.HacerBackUp_327LG(txtBackup.Text);
                MessageBox.Show($"BackUp creado exitosamente en la ruta {txtBackup.Text}", "BackUp Creado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al hacer el backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtRestore.Text.IsNullOrEmpty()) throw new Exception("Debe seleccionar un archivo para restaurar.");
                bllBackUpRestore_327LG.HacerRestore_327LG(txtRestore.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al restaurar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnElegirArchivo_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog folderBrowser = new OpenFileDialog())
                {
                    folderBrowser.Filter = "SQL";
                    if (folderBrowser.ShowDialog() == DialogResult.OK) 
                    {
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
