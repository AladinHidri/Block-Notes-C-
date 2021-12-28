using System;
using Notepad.Objects;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Server; 

                                                                        // cette classe permet de gerrer les button fichier , Edition , Format et Affichage 

namespace Notepad.Controls
{
     public class MainMenuStrip : MenuStrip                             //heritage du  MenuStrip qui est deja defini dans visual studion 
    {
        private const String NAME = "MainMenuStrip";                    // attribution d'un nom 
        
        private MainForm _form;
        private FontDialog _fontDialog;// objet responsable pour regler la fonte 
        public MainMenuStrip()                      //constructeur 
        {
            Name = NAME;           // definition du nom
            Dock = DockStyle.Top; //  definition de la posittion :notre menu strip se sitera en haut  
                                   
            _fontDialog = new FontDialog();
           
            FileDropDownMenu();                    // definition du menu fichier 
            EditDropDownMenu();                    // definition du menu edition
            FormatDropDownMenu();                  // definition du menu format 
            ViewDropDownMenu();                    // definiton  du menu affichage   


            HandleCreated += (s, e) =>
            {
                _form=FindForm() as MainForm;
            };

         }
        public void FileDropDownMenu()
        {                                      
            
                                // defition du button fichier                                  
           
            var fileDroopDownMenu = new ToolStripMenuItem("Fichier");                               //  pour avoir un bouton "Fichier" dans le menu
            
            var newFile = new ToolStripMenuItem("Nouveau", null, null, Keys.Control | Keys.N);      // pour avoir un bouton "Fichier" null :pour l'image  null : pour le click // pur l'ajout d'un nouveau fichier on appui sur ctrl+N 
            var open = new ToolStripMenuItem("Ouvrir...", null, null, Keys.Control | Keys.O);       // pour avoir un bouton "Ouvrir"
            var save = new ToolStripMenuItem("Enregistrer", null, null, Keys.Control | Keys.S);     // pour avoir un bouton "Enregister"
            var saveAs = new ToolStripMenuItem("Enregistrer sous...", null, null, Keys.Control | Keys.Shift | Keys.N);// pour avoir un bouton "Enregister sous..."
            var quit = new ToolStripMenuItem("Quiter", null, null, Keys.Alt | Keys.F4);             // pour avoir un bouton "Quiter"
                                               
            
                                //  defition du button fichier                                    

            newFile.Click += (s, e) =>
            {
                var tabControl = _form.MainTabControl;
                var tabPagesCount = tabControl.TabPages.Count;
               
                var fileName = $"sans titre {tabPagesCount + 1}";    // incrementer le nombre de pages lors de l'ajout d'un nouveau fichier 
                var file = new TextFile(fileName);
                var rtb = new CustomRichTextBox();
                                
                tabControl.TabPages.Add(file.SafeFileName);
              
                var newTabPage = tabControl.TabPages[tabPagesCount];
                
                newTabPage.Controls.Add(rtb);
                tabControl.SelectedTab = newTabPage;

                _form.Session.TextFiles.Add(file);
                _form.CurrentRtb= rtb;
                _form.CurrentFile= file;
            };
                        // pour pouvoir les afficher dans le menu fichier  
            fileDroopDownMenu.DropDownItems.Add(newFile);
            fileDroopDownMenu.DropDownItems.Add(open);
            fileDroopDownMenu.DropDownItems.Add(save);
            fileDroopDownMenu.DropDownItems.Add(saveAs);
            fileDroopDownMenu.DropDownItems.Add(quit);
            
            Items.Add(fileDroopDownMenu); // pour afficher ce button "Fichier"
        }         // fonction responsable de gestion de fichier

        public void EditDropDownMenu()            // fonction responsable de l'edition 
        {

            var editDroopDown = new ToolStripMenuItem("Edition");// pour avoir un bouton "Edition"

            var undo = new ToolStripMenuItem("Annuler", null, null, Keys.Control | Keys.Z);// pour avoir un bouton "Annuler"
            var redo = new ToolStripMenuItem("Restaurer", null, null, Keys.Control | Keys.Y);// pour avoir un bouton "Restaurer"

            undo.Click +=(s, e) =>                // permet a l'utilisateur d'annuler l'operation si il y'a la possibilité d'annuler 
            {
              if   (_form.CurrentRtb.CanUndo)
                    _form.CurrentRtb.Undo();

            };

            redo.Click +=(s, e) =>                // permet a l'utilisateur de retourner a l'operation si il y'a
                                                     // la possibilité de retourner 
            {
                if (_form.CurrentRtb.CanRedo)
                    _form.CurrentRtb.Redo();

            };

            editDroopDown.DropDownItems.Add(undo);
            editDroopDown.DropDownItems.Add(redo);
            
            Items.Add(editDroopDown); // pour afficher ce button "Edition"

        }

                       
        public void FormatDropDownMenu()
        {

            var formatDroopDown = new ToolStripMenuItem("Format");

            var font = new ToolStripMenuItem("Police...");

            font.Click += (s, e) =>
            {
                _fontDialog.Font = _form.CurrentRtb.Font; // definir la fonte qui est egale la fonte de notre RichTextBox
                _fontDialog.ShowDialog();                     // pour afficher les fontes disponnibles 

                _form.CurrentRtb.Font = _fontDialog.Font; // pour choisir la fonte qui nous convient 
            };
            


            formatDroopDown.DropDownItems.Add(font);
            

            Items.Add(formatDroopDown); 

        }       // fonction responsable de gestion de format 
                    

                      
                    
        public void ViewDropDownMenu()
        {
            var viewDroopDown = new ToolStripMenuItem("Affichage");
            var alwaysOnTop = new ToolStripMenuItem("Toujours devant");    // permet lorsqu'on clique sur un autre fichier ou un autre programme de rester tjs en avant et ne sera pas caché
                        
                                
            var zoomDropDown= new ToolStripMenuItem("zoom");
            var zoomIn = new ToolStripMenuItem("Zoom avant",null, null, Keys.Control | Keys.Add);
            var zoomOut = new ToolStripMenuItem("Zoom arrière",null, null, Keys.Control | Keys.Subtract);
            var restoreZoom = new ToolStripMenuItem("Restaurer le zoom par défaut",null, null, Keys.Control | Keys.Divide);

            zoomIn.ShortcutKeyDisplayString = "Ctrl+Num +";                     // pour l'affichage en avant 
            zoomOut.ShortcutKeyDisplayString = "Ctrl+Num -";                    // pour l'affichage en arriére 
            restoreZoom.ShortcutKeyDisplayString = "Ctrl+Num /";                // pour l'affichage par defaut 

            alwaysOnTop.Click += (s, e) =>                // pour voir si le button 
            {                                             //Toujours devant est appuyé ou non 
                if (alwaysOnTop.Checked)
                {
                    alwaysOnTop.Checked = false;
                    Program._form.TopMost = false;
                }
                else
                {
                    alwaysOnTop.Checked = true;
                    Program._form.TopMost = true;
                }
            };

            zoomIn.Click += (s, e) =>                     // pour pouvoir faire le zoom en avant
            {
                if (_form.CurrentRtb.ZoomFactor < 3F) // pour connaitre si on a atteint la limite maximum du zoom
                {
                    _form.CurrentRtb.ZoomFactor += 0.3F; // on peut ajouter du zoom avec 30%
                }
            };

            zoomOut.Click += (s, e) =>                      // pour pouvoir faire le zoom en avant
            {
                if (_form.CurrentRtb.ZoomFactor > 0.7F) // pour connaitre si on a atteint la limite minimum du zoom 
                {
                    _form.CurrentRtb.ZoomFactor -= 0.3F; // on peut minimiser lu zoom avec 30%
                }
            };

            restoreZoom.Click += (s, e) => { _form.CurrentRtb.ZoomFactor = 1F; };



            zoomDropDown.DropDownItems.AddRange(new ToolStripItem[] { zoomIn, zoomOut, restoreZoom });

            viewDroopDown.DropDownItems.Add(alwaysOnTop);
            viewDroopDown.DropDownItems.Add(zoomDropDown);


            Items.Add(viewDroopDown);
        }         // fonction responsable de gestion de l'affichage 
                    

    }


}
