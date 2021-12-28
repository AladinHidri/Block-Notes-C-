
using Notepad.Controls;
using Notepad.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
                                 // formulaire principale 
namespace Notepad
{
    public partial class MainForm : Form
    {
        public  RichTextBox CurrentRtb; // permet d'indiquer quelle richtextbox est active 
        public TextFile CurrentFile;
        public TabControl MainTabControl;
        public Session Session; 
        public MainForm()
        { 
            InitializeComponent();          //genere tout mes composantes lors de l'execution d'une application 

            var  menuStrip = new MainMenuStrip();      // appel a la classe MainMenuStrim  
            MainTabControl = new MainTabControl();     // appel a classe MainTabControl 
            Session = new Session();                   // appel a la classe Session
            CurrentRtb = new CustomRichTextBox();      // appel a la classe CustomRichTextBox

            
            


            Controls.AddRange(new Control[] { MainTabControl, menuStrip});

            

        }

       
    }
}
