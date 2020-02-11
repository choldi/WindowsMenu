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
        private string fileName;
        private PictureBox[] icons;

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
            this.configMenu = cfMenu;
            this.fileName = fileConfig;

        }
        private PictureBox CreatePicture(int posicio)
        {
            Logger.Info("Posicion {0}", posicio);
            int y = ((int)((posicio - 1) / configMenu.columns));
            int x = ((posicio - 1) % configMenu.columns);
            Logger.Info("Creando picture {0},{1}", x,y );
            PictureBox pic = new PictureBox();
            float ample = this.Size.Width / configMenu.columns;
            float alt = this.Size.Height / configMenu.rows;
            Size midaImg = new Size((int)ample - 2, (int)alt - 2);
            pic.Size = midaImg;
            pic.Location = new Point((int)ample * x + 1, (int)alt * y + 1);
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            return pic;
        }

        private PictureBox setEmptyPicture(int posicio)
        {
            Logger.Info("Añadiendo elemento vacio en posicion {0}", posicio);
            PictureBox pic = CreatePicture(posicio);
            pic.Image = Properties.Resources.no_program;
            ToolTip tt = new ToolTip();
            tt.SetToolTip(pic, $"Posicion {posicio}: Sin programa");
            pic.Tag = new { posicio = posicio, commandLine = "", id = 0 };
            pic.MouseClick += new MouseEventHandler((s, ev) => {
                MessageBox.Show("Hola " + (ev.Button == MouseButtons.Left ? "Left" : "Right"));
                if (ev.Button == MouseButtons.Right)
                {
                    PictureBox picx = s as PictureBox;
                    dynamic tag = picx.Tag;
                    Logger.Info("Pulsado boton derecho en {0}", tag.posicio);
                    frmPrograma prg = new frmPrograma(configMenu, tag.posicio);
                    Logger.Info("Iniciando dialogo para añadir elemento");
                    if (prg.ShowDialog() == DialogResult.OK)
                    {
                        Logger.Info("Grabando configuracion");
                        configMenu.Save(fileName);
                    }
                }
            });

            return pic;
        }
        private PictureBox setPicture(OpcioMenu om, int posicio)
        {
            Logger.Info("Añadiendo elemento en posicion {0}", posicio);
            PictureBox pic = CreatePicture(posicio);
            ToolTip tt = new ToolTip();
            if (om.fileIcon == null || !File.Exists(om.fileIcon))
                pic.Image = Properties.Resources.programDefault;
            else
                pic.Image = Image.FromFile(om.fileIcon);
            if (om.label == null)
                tt.SetToolTip(pic, $"Executable: {om.fileName}");
            else
                tt.SetToolTip(pic, om.label);
            pic.Tag = new { posicio = posicio, commandLine = om.fileName, id = om.dynId };
            pic.MouseClick += new MouseEventHandler((s, ev) => {
                MessageBox.Show("Hola " + (ev.Button == MouseButtons.Left ? "Left" : "Right"));
                if (ev.Button == MouseButtons.Left)
                {
                    PictureBox picx = s as PictureBox;
                    dynamic tag = picx.Tag;
                    System.Diagnostics.Process.Start(tag.commandLine);
                }
                if (ev.Button == MouseButtons.Right)
                {
                    PictureBox picx = s as PictureBox;
                    dynamic tag = picx.Tag;
                    OpcioMenu omx = configMenu.getProgram(tag.posicio);
                    frmPrograma prg = new frmPrograma(configMenu, omx, tag.posicio);
                    if (prg.ShowDialog() == DialogResult.OK)
                    {
                        configMenu.Save(fileName);
                    }
                }
            });
            return pic;
        }
        private void createIcons()
        {
            PictureBox[] pics = new PictureBox[configMenu.columns * configMenu.rows];
            for (int i = 0; i < configMenu.rows; i++)
                for (int j = 0; j < configMenu.columns; j++)
                {
                    int posicio = i * configMenu.columns + j + 1;
                    var findElem = configMenu.getProgram(posicio);
                    if (findElem == null)
                    {
                        PictureBox pic = setEmptyPicture(posicio);
                        pics[configMenu.columns * i + j] = pic;
                    }
                    else
                    {
                        PictureBox pic = setPicture(findElem, posicio);
                        pics[configMenu.columns * i + j] = pic;
                    }

                }
            this.icons = pics;

        }

        private void RemovePictureBox()
        {
            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i].GetType() == typeof(PictureBox))
                {
                    this.Controls.Remove(this.Controls[i]);
                }
            }
        }
        private void AddPictureBox()
        {
            createIcons();
            for (int i = 0; i < this.icons.Count(); i++)
            {
                this.Controls.Add(this.icons[i]);
            }
        }

        private void refreshPictures()
        {
            RemovePictureBox();
            AddPictureBox();
        }
        private void createIcons2()
        {
            float ample = this.Size.Width / configMenu.columns;
            float alt = this.Size.Height / configMenu.rows;
            Size midaImg = new Size((int)ample - 2, (int)alt - 2);
            PictureBox[] pics = new PictureBox[configMenu.columns * configMenu.rows];
            for (int i = 0; i < configMenu.rows; i++)
                for (int j = 0; j < configMenu.columns; j++)
                {
                    int posicio = i * configMenu.columns + j + 1;
                    pics[configMenu.columns * i + j] = new PictureBox();
                    pics[configMenu.columns * i + j].Size = midaImg;
                    ToolTip tt = new ToolTip();
                    pics[configMenu.columns * i + j].Location = new Point((int)ample * j + 1, (int)alt * i + 1);
                    pics[configMenu.columns * i + j].SizeMode = PictureBoxSizeMode.StretchImage;
                    var findElem = configMenu.getProgram(posicio);
                    if (findElem != null)
                    {
                        if (findElem.fileIcon == null || !File.Exists(findElem.fileIcon))
                            pics[configMenu.columns * i + j].Image = Properties.Resources.programDefault;
                        else
                            pics[configMenu.columns * i + j].Image = Image.FromFile(findElem.fileIcon);
                        if (findElem.label == null)
                            tt.SetToolTip(pics[configMenu.columns * i + j], $"Executable: {findElem.fileName}");
                        else
                            tt.SetToolTip(pics[configMenu.columns * i + j], findElem.label);
                        pics[configMenu.columns * i + j].Tag = new { fila = i + 1, columna = j + 1, posicio = posicio, commandLine = findElem.fileName, id = findElem.dynId };
                        pics[configMenu.columns * i + j].MouseClick += new MouseEventHandler((s, ev) => {
                            MessageBox.Show("Hola " + (ev.Button == MouseButtons.Left ? "Left" : "Right"));
                            if (ev.Button == MouseButtons.Left)
                            {
                                PictureBox pic = s as PictureBox;
                                dynamic tag = pic.Tag;
                                System.Diagnostics.Process.Start(tag.commandLine);
                            }
                            if (ev.Button == MouseButtons.Right)
                            {
                                PictureBox pic = s as PictureBox;
                                dynamic tag = pic.Tag;
                                OpcioMenu om = configMenu.getProgram(tag.posicio);
                                frmPrograma prg = new frmPrograma(configMenu, om, tag.posicio);
                                if (prg.ShowDialog() == DialogResult.OK)
                                {
                                    configMenu.Save(fileName);
                                    refreshPictures();
                                }
                            }
                        });
                    }
                    else
                    {
                        pics[configMenu.columns * i + j].Image = Properties.Resources.no_program;
                        tt.SetToolTip(pics[configMenu.columns * i + j], $"Posicion {posicio}: Sin programa");
                        pics[configMenu.columns * i + j].Tag = new { fila = i + 1, columna = j + 1, posicio = posicio, commandLine = "", id = 0 };
                        pics[configMenu.columns * i + j].MouseClick += new MouseEventHandler((s, ev) => {
                            MessageBox.Show("Hola " + (ev.Button == MouseButtons.Left ? "Left" : "Right"));
                            if (ev.Button == MouseButtons.Right)
                            {
                                PictureBox pic = s as PictureBox;
                                dynamic tag = pic.Tag;
                                frmPrograma prg = new frmPrograma(configMenu, tag.posicio);
                                if (prg.ShowDialog() == DialogResult.OK)
                                {
                                    configMenu.Save(fileName);
                                    refreshPictures();
                                }
                            }
                        });

                    }

                   // this.Controls.Add(pics[configMenu.columns * i + j]);

                }
            this.icons = pics;

        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            configLog();
            loadConfig();
            createIcons();
            
        }
        private void frmMain_Shown(object sender, EventArgs e)
        {

            float ample = this.Size.Width / configMenu.columns;
            float alt = this.Size.Height / configMenu.rows;
            Graphics gdi = this.CreateGraphics();
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            for (int i = 1; i <= configMenu.columns; i++)
                gdi.DrawLine(pen, ample * i, 0, ample * i, this.Size.Height);
            for (int i = 1; i <= configMenu.rows; i++)
                gdi.DrawLine(pen, 0, alt * i, this.Size.Width, alt * i);
            foreach (PictureBox p in this.icons)
            {
                this.Controls.Add(p);
            }
        }

        private void frmMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Right)
            {
                MessageBox.Show("Hola en form");
            }
        }
        private void Add_Programa(object sender, ConfigMenu menu)
        {
            PictureBox pic = sender as PictureBox;
            dynamic tag = pic.Tag;
            string str = $"Coordenadas [{tag.fila},{tag.columna}]";
            MessageBox.Show(str);
            var frmPrograma = new frmPrograma();

        }
    }
}
