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
        string fileName;
        string fileIcon;
        string label;
        string preExec;
        string postExec;
        bool execDefaultPreExec;
        int position;

        public OpcioMenu(string fileName, string fileIcon, string label, string preExec, string postExec, int position,bool execDefault=false)
        {
            this.fileName = fileName;
            this.fileIcon = fileIcon;
            this.label = label;
            this.preExec = preExec;
            this.postExec = postExec;
            this.position = position;
            this.execDefaultPreExec = execDefault;
        }
    }

    public class ConfigMenu
    {
        List<OpcioMenu> opcions;
        public int rows { get; private set; }
        public int columns { get; private set; }
        public string defaultPreExec { get; private set; }
        public string defaultPostExec { get; private set; }
        public bool exitOnExit { get; private set; }

        

        private string getStringValue(XmlNode elem, string key)
        {
            var child = elem[key];
            if (child !=null ) return child.InnerText; else return "";
        }
        private int getIntValue(XmlNode elem, string key)
        {
            var child = elem[key];
            if (child !=null ) return int.Parse(child.InnerText); else return 0;
        }
        public ConfigMenu()
        {
        }
        public ConfigMenu(string fileconfig)
        {
            string filepath=Path.GetFileName(fileconfig);
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

            string filepath=Path.GetFileName(fileconfig);
            var settings = new XmlWriterSettings() 
            {
                Indent = true,
                IndentChars = "    "
            };
            using (XmlWriter writer = XmlWriter.Create(filepath,settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("General");
                writer.WriteElementString("Rows", this.rows.ToString());
                writer.WriteElementString("Columns", this.columns.ToString());
                writer.WriteElementString("defaultPreExec", this.defaultPreExec);
                writer.WriteElementString("defaultPostExec", this.defaultPostExec);
                writer.WriteElementString("exitOnExit", this.exitOnExit ? "1" : "0");

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
                writer.WriteEndElement();
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
        public bool loadMain(XmlNode opc)
        {
            var pre = getStringValue(opc,"PreExecDefault");
            var pos = getStringValue(opc,"PostExecDefault");
            var rows = getIntValue(opc,"Rows");
            var columns = getIntValue(opc,"Columns");
            var exit = getIntValue(opc,"ExitOnLaunch") == 1 ? true : false;
            this.columns=columns;
            this.rows=rows;
            this.defaultPreExec=pre;
            this.defaultPostExec=pos;
            this.exitOnExit = exit;
            return true;
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
