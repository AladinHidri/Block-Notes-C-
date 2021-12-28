using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Notepad.Controls
{                                               // classe responsable de l'ecritue dans le block note 
    public class CustomRichTextBox : RichTextBox     // heritage 
    {
        private const string NAME = "RtbTextFileContents" ;
        public CustomRichTextBox()
        {
            Name = NAME ; 
            AcceptsTab = true ;                                         //accepte la tabulation
            Font = new Font("Arial", 12.0F, FontStyle.Regular) ;        // definit la police des caracteres (la taille ...)
            Dock= DockStyle.Fill;                                       //remplir l'espace de notre tab controle 
            BorderStyle = BorderStyle.None;                             //pour empecher les bordures 
            ContextMenuStrip = new RichTextBoxContextMenuStrip(this);   // appel a la classe RichTextBoxContextMenuStrip pour effecuer les operations : cut /copy / paste / SelectAll
        }

        

        private void CustomRichTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
