using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

                                            // c'est la classe responsable pour effecuer les acion  : cut ; copy ; paste ; selectAll 
namespace Notepad.Controls
{
  public class RichTextBoxContextMenuStrip : ContextMenuStrip               //heritage 
    {
        private RichTextBox _richtextBox;
        private const string NAME = "RtbContextMenuStrip";

        public RichTextBoxContextMenuStrip(RichTextBox richText)
        {
            _richtextBox = richText; 
            var cut = new ToolStripMenuItem("Couper");                                  // pour couper le texte le texte  
            var copy = new ToolStripMenuItem("Copier");                                 // pour copier le texte
            var paste = new ToolStripMenuItem("Coller");                                // pour coller le texte
            var selectAll = new ToolStripMenuItem("Sélectionner tout");                 // pour selectionner tout 

            cut.Click += (s, e) => _richtextBox.Cut();                                  // defintion de l'evenement click pour Cut
            copy.Click += (s, e) => _richtextBox.Copy();                                // definition de l'evenement click pour copy
            paste.Click += (s, e) => _richtextBox.Paste();                              // defintion de l'evenement click pour paste
            selectAll.Click += (s, e) => _richtextBox.SelectAll();                      // defition de l'evenement click pour SelectAll


            Items.AddRange(new ToolStripItem[] { cut, copy, paste, selectAll });        // ajout des evenements 

        }
    }
}
