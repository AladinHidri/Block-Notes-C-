using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
                                    // cette classe d'ouvrir un nouveau fichier, de le fermer 
namespace Notepad.Controls
{
    public class TabControlContextMenuStrip : ContextMenuStrip         // heritage du contextMenuStrip
    {
        private const string NAME = "TabControlContextMenuStrip";      // definition du nom 
        public TabControlContextMenuStrip()
        {
            Name = NAME;

            var closeTab = new ToolStripMenuItem("Fermer");                                                                    // pour fermer le fichier en cours
            var closeAllTabExceptThis = new ToolStripMenuItem("Fermer tout sauf ce fichier");                                  // pour fermertout sauf ce fichier 
            var openFileInExplorer = new ToolStripMenuItem("ouvrir le répectoire du fichier en cours dans l'explorateur");     //  pour ouvrir le fichier dans le repectoire courant

            Items.AddRange(new ToolStripItem[] { closeTab, closeAllTabExceptThis, openFileInExplorer });                       // Ajout des methodes closetab, closeAllTabExceptThis, openFileInZxplorer
        }
    }
}
