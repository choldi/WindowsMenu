using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace WindowsMenu
{
    public class OpcioMenu
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public System.Guid dynId { get; private set; }
        public string fileName { get; private set; }
        public string fileIcon { get; private set; }
        public string label { get; private set; }
        public string preExec { get; private set; }
        public string postExec { get; private set; }
        public bool execDefaultPreExec { get; private set; }
        public int position { get; private set; }

        public OpcioMenu(string fileName, string fileIcon, string label, string preExec, string postExec, int position,bool execDefault=false)
        {
            this.fileName = fileName;
            this.fileIcon = fileIcon;
            this.label = label;
            this.preExec = preExec;
            this.postExec = postExec;
            this.position = position;
            this.execDefaultPreExec = execDefault;
            this.dynId = Guid.NewGuid();
        }
    }

    public class ConfigMenu
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        List<OpcioMenu> opcions;
        public int rows { get; private set; }
        public int columns { get; private set; }
        public string defaultPreExec { get; private set; }
        public string defaultPostExec { get; private set; }
        public bool exitOnExit { get; private set; }
        public bool readOnly { get; private set; }



        private string getStringValue(XmlNode elem, string key)
        {

            var child = elem[key];
            if (child != null)
            {
                Logger.Info("getStringValue {0} = {1}", key, child.InnerText);
                return child.InnerText;
            }
            else
            {
                Logger.Info("getStringValue {0} = null = \"\"", key);
                return "";
            }
        }
        private int getIntValue(XmlNode elem, string key)
        {
            var child = elem[key];
            if (child != null)
            {
                Logger.Info("getIntValue {0} = {1}", key, int.Parse(child.InnerText));
                return int.Parse(child.InnerText);
            }
            else
            {
                Logger.Info("getStringValue {0} = null = 0", key);
                return 0;
            }
        }
        public ConfigMenu()
        {
        }
        public ConfigMenu(string fileconfig)
        {
            this.opcions = new List<OpcioMenu>();
            string filepath = Path.GetFileName(fileconfig);
            FileInfo info = new FileInfo(filepath);
            if (!info.Exists) {
                throw new InvalidConfigFileException(fileconfig);
            }
            XmlDocument xmlConfig = new XmlDocument();
            xmlConfig.Load(filepath);
            XmlNode nodeGeneral = xmlConfig.SelectSingleNode("//General");
            if (!loadMain(nodeGeneral))
            {
                throw new InvalidConfigFileException(fileconfig);
            }
        }
        public void Save(string fileconfig)
        {

            string filepath = Path.GetFileName(fileconfig);
            var settings = new XmlWriterSettings()
            {
                Indent = true,
                IndentChars = "    "
            };
            using (XmlWriter writer = XmlWriter.Create(filepath, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("General");
                writer.WriteElementString("Rows", this.rows.ToString());
                writer.WriteElementString("Columns", this.columns.ToString());
                writer.WriteElementString("defaultPreExec", this.defaultPreExec);
                writer.WriteElementString("defaultPostExec", this.defaultPostExec);
                writer.WriteElementString("exitOnExit", this.exitOnExit ? "1" : "0");
                writer.WriteElementString("readOnly", this.readOnly ? "1" : "0");
                writer.WriteStartElement("programs");
                if (this.opcions != null)
                    foreach (OpcioMenu om in this.opcions)
                    {
                        writer.WriteStartElement("program");
                        writer.WriteElementString("Executable", om.fileName);
                        writer.WriteElementString("Icon", om.fileIcon);
                        writer.WriteElementString("Label", om.label);
                        writer.WriteElementString("PreExec", om.preExec);
                        writer.WriteElementString("PostExec", om.postExec);
                        writer.WriteElementString("Position", om.position.ToString());
                        writer.WriteElementString("ExecDefault", om.execDefaultPreExec == false ? "0" : "1");

                        writer.WriteEndElement();

                    }

                /*
                                foreach (Employee employee in employees)
                                {
                                    writer.WriteStartElement("Employee");

                                    writer.WriteElementString("ID", employee.Id.ToString());
                                    writer.WriteElementString("FirstName", employee.FirstName);
                                    writer.WriteElementString("LastName", employee.LastName);
                                    writer.WriteElementString("Salary", employee.Salary.ToString());

                                    writer.WriteEndElement();
                                }
                */
                writer.WriteEndElement(); //programs
                writer.WriteEndElement(); //general
                writer.WriteEndDocument();
            }
        }

        public void SetMatrix(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;

        }
        public void AddPreExec(string cmd)
        {
            this.defaultPreExec = cmd;
        }
        public void AddPostExec(string cmd)
        {
            this.defaultPostExec = cmd;
        }
        public void AddOpcio(OpcioMenu opt)
        {
            this.opcions.Add(opt);
        }
        public bool RemoveOpcio(System.Guid id)
        {
            var itemToRemove = this.opcions.SingleOrDefault(r => r.dynId == id);
            if (itemToRemove != null)
            {
                this.opcions.Remove(itemToRemove);
                return true;
            }
            return false;
        }
        public bool loadMain(XmlNode opc)
        {
            var pre = getStringValue(opc, "PreExecDefault");
            var pos = getStringValue(opc, "PostExecDefault");
            var rows = getIntValue(opc, "Rows");
            var columns = getIntValue(opc, "Columns");
            var exit = getIntValue(opc, "ExitOnLaunch") == 1 ? true : false;
            var readOnly = getIntValue(opc, "readOnly") == 1 ? true : false;
            this.columns = columns;
            this.rows = rows;
            this.defaultPreExec = pre;
            this.defaultPostExec = pos;
            this.exitOnExit = exit;
            this.readOnly = readOnly;
            loadPrograms(opc);
            return true;
        }

        public bool loadPrograms(XmlNode opc)
        {
            XmlNode basePrg = opc.SelectSingleNode("//programs");
            XmlNodeList prgs = basePrg.SelectNodes("program");
            foreach (XmlNode prg in prgs)
            {
                loadProgram(prg);
            }
            return true;
        }

        public bool loadProgram(XmlNode prg)
        {
            var program = getStringValue(prg, "Executable");
            var icon = getStringValue(prg, "Icon");
            var label = getStringValue(prg, "Label");
            var pre = getStringValue(prg, "PreExec");
            var post = getStringValue(prg, "PostExec");
            var pos = getIntValue(prg, "Position");
            var execdef = getIntValue(prg, "ExecDefault");
            OpcioMenu om = new OpcioMenu(program, icon, label, pre, post, pos, execdef == 1 ? true : false);
            this.AddOpcio(om);
            return true;
        }

        public bool addProgram(string program, string icon,string label, string pre, string post, int pos, bool execdef)
        {
            Logger.Info("addProgram : Add {0}", program);
            OpcioMenu om = new OpcioMenu(program, icon, label, pre, post, pos, execdef);
            this.opcions.Add(om);
            return true;
        }

        public OpcioMenu getProgram(int x,int y)
        {
            int pos = x + (y - 1) * this.columns;
            return getProgram(pos);
        }

        public OpcioMenu getProgram(int posicio)
        {
            OpcioMenu om = null;
            if (this.opcions != null)
                foreach (OpcioMenu opc in this.opcions)
                {
                    if (opc.position == posicio)
                    {
                        om = opc;
                        break;
                    }
                }
            return om;
        }

    }


    [Serializable]
    class InvalidConfigFileException : Exception
    {
        public InvalidConfigFileException()
        {

        }

    public InvalidConfigFileException(string file)
        : base(String.Format("File reading error: {0}", file))
        {

        }
  
}
}
