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
using NLog;


namespace WindowsMenu
{
    public partial class frmMain : Form
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        private ConfigMenu configMenu;

        public frmMain()
        {
            InitializeComponent();
        }
        private void configLog()
        {
            var config = new NLog.Config.LoggingConfiguration();

            // Targets where to log to: File and Console
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "file.txt" };
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");

            // Rules for mapping loggers to targets            
            config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

            // Apply config           
            NLog.LogManager.Configuration = config;

        }

        private void loadConfig()
        {
            string[] args = Environment.GetCommandLineArgs();
            string fileConfig;
            Logger.Info("Numero de parametros: {0}", (args.Length - 1).ToString());
            if (args.Length < 2)
            {
                fileConfig = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(args[0]), System.IO.Path.GetFileNameWithoutExtension(args[0]) + ".xml");
                Logger.Info("Sin parámetros ({0}) : {1}", args.Length, fileConfig);
            }
            else
            {
                fileConfig = args[2];
            }
            ConfigMenu cfMenu;
            FileInfo fi = new FileInfo(fileConfig);
            if (fi.Exists)
            {
                Logger.Info("Cargando fichero {0}", fileConfig);
                cfMenu = new ConfigMenu(fileConfig);
            }
            else
            {
                Logger.Info("Creando fichero {0}", fileConfig);
                Properties.Settings settings = Properties.Settings.Default;
                cfMenu = new ConfigMenu();
                cfMenu.SetMatrix(settings.Rows, settings.Columns);
                cfMenu.Save(fileConfig);
            }
            configMenu = cfMenu;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            configLog();
            loadConfig();
            
        }
        private void frmMain_Shown(object sender, EventArgs e)
        {
            
            float ample = this.Size.Width / configMenu.columns;
            float alt = this.Size.Height / configMenu.rows;
            Size midaImg = new Size((int) ample-2,(int) alt-2);
            PictureBox[] pics = new PictureBox[configMenu.columns * configMenu.rows];
            for (int i = 0; i < configMenu.rows - 1; i++)
                for (int j = 0; j < configMenu.columns; j++)
                {
                    pics[configMenu.columns * i + j] = new PictureBox();
                    pics[configMenu.columns * i + j].Size = midaImg;
                    pics[configMenu.columns * i + j].Location = new Point((int)ample * j + 1, (int)alt * i + 1);
                    pics[configMenu.columns * i + j].Image = Image.FromFile("e:\\aena.png");
                    pics[configMenu.columns * i + j].SizeMode = PictureBoxSizeMode.StretchImage;
                    pics[configMenu.columns * i + j].MouseClick += new MouseEventHandler((s, ev) => {
                        MessageBox.Show("Hola " + (ev.Button == MouseButtons.Left ? "Left" : "Right")); 
                        if (ev.Button == MouseButtons.Left)
                        {
                            PictureBox pic = (PictureBox)s;
                            dynamic tag = pic.Tag;
                            System.Diagnostics.Process.Start( tag.commandLine);
                        }
                    });
                    pics[configMenu.columns * i + j].Tag = new { fila = i, columna = j, commandLine = "notepad.exe" };
                    this.Controls.Add(pics[configMenu.columns * i + j]);
                    
                }
            Graphics gdi = this.CreateGraphics();
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            for (int i = 1; i <= configMenu.columns; i++)
                gdi.DrawLine(pen, ample * i, 0, ample * i, this.Size.Height);
            for (int i = 1; i <= configMenu.rows; i++)
                gdi.DrawLine(pen, 0, alt * i, this.Size.Width, alt * i);
            var frmOpts = new frmOpcions(configMenu);
            var result = frmOpts.ShowDialog();
            if (result == DialogResult.OK)
            {

                MessageBox.Show("OK");

            }
            else
            {
                MessageBox.Show("Cancel");
            }
            var frmPrograma = new frmPrograma();
            frmPrograma.ShowDialog();
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
