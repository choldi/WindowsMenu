using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        int rows;
        int columns;
        string defaultPreExec;
        string defaultPostExec;
        List<OpcioMenu> opcions;
        bool exitOnExit;

        public ConfigMenu()
        {
        }
        public ConfigMenu(string fileconfig)
        {
            
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

    }

}
