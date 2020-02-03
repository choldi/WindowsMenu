using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsMenu
{
    class OpcioMenu
    {
        string fileName;
        string fileIcon;
        string label;
        string preExec;
        string postExec;
    }

    class ConfigMenu
    {
        int rows;
        int columns;
        string defaultPreExec;
        string defaultPostExec;
        List<OpcioMenu> opcions;
        bool exitOnExit;
    }
}
