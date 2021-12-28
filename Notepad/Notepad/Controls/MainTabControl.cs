using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad.Controls
{
    public class MainTabControl : TabControl                // geritage de TabControl deja existant 
    {
        private const string NAME = "MainTabControl";
        private ContextMenuStrip _contextMenuStrip;
        public MainTabControl()
        {
            _contextMenuStrip = new TabControlContextMenuStrip();
            Name = NAME;
            ContextMenuStrip = _contextMenuStrip;
            Dock = DockStyle.Fill; // permet de remplir tout l'espace qui reste sur notre formulaire 
        }
    }
}
 