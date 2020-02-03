using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JsonConfig;


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
            string programa;
            string[] args = Environment.GetCommandLineArgs();
            programa = System.IO.Path.GetFileNameWithoutExtension(args[0]);
            string defaultConfig = programa + ".conf";
            if (args.Length < 2) {
                MessageBox.Show("Sin parámetros:" + args.Length, programa);
                dynamic config = Config.Default;
                Properties.Settings settings = Properties.Settings.Default;
                ConfigMenu cfMenu = new ConfigMenu();
                cfMenu.SetMatrix(settings.Rows, settings.Columns);
                config.Menu = cfMenu;
                config.Save(); 
                MessageBox.Show("Sin parámetros:" + args.Length, programa);



            }
        }
        private void frmMain_Shown(object sender, EventArgs e)
        {
            Properties.Settings settings = Properties.Settings.Default;
            float ample = this.Size.Width / settings.Columns;
            float alt = this.Size.Height / settings.Rows;
            Size midaImg = new Size((int) ample-2,(int) alt-2);
            PictureBox[] pics = new PictureBox[settings.Columns * settings.Rows];
            for (int i = 0; i < settings.Rows - 1; i++)
                for (int j = 0; j < settings.Columns; j++)
                {
                    pics[settings.Columns * i + j] = new PictureBox();
                    pics[settings.Columns * i + j].Size = midaImg;
                    pics[settings.Columns * i + j].Location = new Point((int)ample * j + 1, (int)alt * i + 1);
                    pics[settings.Columns * i + j].Image = Image.FromFile("e:\\aena.png");
                    pics[settings.Columns * i + j].SizeMode = PictureBoxSizeMode.StretchImage;
                    pics[settings.Columns * i + j].MouseClick += new MouseEventHandler((s, ev) => {
                        MessageBox.Show("Hola " + (ev.Button == MouseButtons.Left ? "Left" : "Right")); 
                        if (ev.Button == MouseButtons.Left)
                        {
                            PictureBox pic = (PictureBox)s;
                            dynamic tag = pic.Tag;
                            System.Diagnostics.Process.Start( tag.commandLine);
                        }
                    });
                    pics[settings.Columns * i + j].Tag = new { fila = i, columna = j, commandLine = "notepad.exe" };
                    this.Controls.Add(pics[settings.Columns * i + j]);
                    
                }
            Graphics gdi = this.CreateGraphics();
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            for (int i = 1; i <= settings.Columns; i++)
                gdi.DrawLine(pen, ample * i, 0, ample * i, this.Size.Height);
            for (int i = 1; i <= settings.Rows; i++)
                gdi.DrawLine(pen, 0, alt * i, this.Size.Width, alt * i);
        }

        private void frmMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Right)
            {
                MessageBox.Show("Hola en form");
            }
        }
    }
}
