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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
        private void frmMain_Shown(object sender, EventArgs e)
        {
            Properties.Settings settings = Properties.Settings.Default;
            float ample = this.Size.Width / settings.Columns;
            float alt = this.Size.Height / settings.Rows;
            Graphics gdi = this.CreateGraphics();
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            for (int i = 1; i <= settings.Columns; i++)
                gdi.DrawLine(pen, ample * i,0, ample * i, this.Size.Height);
            for (int i = 1; i <= settings.Rows; i++)
                gdi.DrawLine(pen, 0, alt*i, this.Size.Width, alt*i);

        }
    }
}
