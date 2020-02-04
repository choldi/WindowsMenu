using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsMenu
{
    public partial class frmOpcions : Form
    {
        private ConfigMenu config;
        public frmOpcions()
        {
            InitializeComponent();
        }

        public frmOpcions(ConfigMenu config)
        {
            InitializeComponent();
            this.config = config;
            lblColVal.Text = config.columns.ToString();
            tbColumns.Value = config.columns;
            lblRowVal.Text = config.rows.ToString();
            tbRows.Value = config.rows;
            txtPre.Text = config.defaultPreExec;
            txtPost.Text = config.defaultPostExec;
            cbExit.Checked = config.exitOnExit;


        }
        private void Form1_Load(object sender, EventArgs e)
        {
            lblColVal.Text = tbColumns.Value.ToString();
            lblRowVal.Text = tbRows.Value.ToString();
        }

        private void tbRows_Scroll(object sender, EventArgs e)
        {
            lblRowVal.Text = tbRows.Value.ToString();
        }

        private void tbColumns_Scroll(object sender, EventArgs e)
        {
            lblColVal.Text = tbColumns.Value.ToString();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            bool ok = true;
            if (txtPre.Text != "")
            {
                FileInfo fi = new FileInfo(txtPre.Text);
                ok = ok & fi.Exists;
            }
            if (txtPost.Text != "")
            {
                FileInfo fi = new FileInfo(txtPost.Text);
                ok = ok & fi.Exists;
            }
            if (ok)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Error en fichero ejecutable. No encontrado", "Error");
            }
        }

        private void btnOpenPre_Click(object sender, EventArgs e)
        {
            opfExec.Title = "Comando de preexec";
            var opfResult = opfExec.ShowDialog();
            if (opfResult == DialogResult.OK)
            {
                txtPre.Text = opfExec.FileName;
            }
        }

        private void btnOpenPost_Click(object sender, EventArgs e)
        {
            opfExec.Title = "Comando de postExec";
            var opfResult = opfExec.ShowDialog();
            if (opfResult == DialogResult.OK)
            {
                txtPost.Text = opfExec.FileName;
            }
        }
    }
}
