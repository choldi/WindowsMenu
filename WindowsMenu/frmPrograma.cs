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

        public frmPrograma()
        {
            InitializeComponent();
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
            GetFile("Post Executable", "Executable|*.exe;*.bat;*.cmd|All Files|*.*", txtPre);
        }

    }
}
