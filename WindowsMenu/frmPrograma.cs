using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsMenu
{
    public partial class frmPrograma : Form
    {
        ConfigMenu cf;
        OpcioMenu om;
        int posicio;
        bool edit;
        public frmPrograma()
        {
            InitializeComponent();
        }

        public frmPrograma(ConfigMenu cf, int posicio, bool edit = false) : this()
        {
            this.cf = cf;
            this.posicio = posicio;
            this.edit = edit;
            lblPosition.Text = posicio.ToString();
        }
        public frmPrograma(ConfigMenu cf, OpcioMenu opc, int posicio, bool edit = true) : this(cf,posicio,true)
        {
            this.om = opc;
            txtPrograma.Text = opc.fileName;
            txtIcono.Text = opc.fileIcon;
            txtPre.Text = opc.preExec;
            txtPost.Text = opc.postExec;
            cbDefault.Checked = opc.execDefaultPreExec;

        }
        private string GetFile(string label, string filter,TextBox tb)
        {
            ofd1.FileName = "";
            ofd1.Title = label;
            ofd1.Filter = filter;
            var result = ofd1.ShowDialog();
            if (result == DialogResult.OK)
            {
                tb.Text = ofd1.FileName;
            }
            return ofd1.FileName;

        }
        private void btnPrograma_Click(object sender, EventArgs e)
        {
            GetFile("Programa", "Executable|*.exe;*.bat;*.cmd|All Files|*.*", txtPrograma);
        }

        private void btnIcono_Click(object sender, EventArgs e)
        {
            GetFile("Icono", "images|*.jpg;*.png;*.gif|All Files|*.*", txtIcono);
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            GetFile("Pre Executable", "Executable|*.exe;*.bat;*.cmd|All Files|*.*", txtPre);
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            GetFile("Post Executable", "Executable|*.exe;*.bat;*.cmd|All Files|*.*", txtPost);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtPrograma.Text == "")
            {
                MessageBox.Show("Nom de fitxer buit");
                txtPrograma.Focus();
                return;
            }
            if (this.edit)
            {
                cf.RemoveOpcio(om.dynId);
            }
            cf.addProgram(txtPrograma.Text, txtIcono.Text, txtLabel.Text, txtPre.Text, txtPost.Text, int.Parse(lblPosition.Text), cbDefault.Checked);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
