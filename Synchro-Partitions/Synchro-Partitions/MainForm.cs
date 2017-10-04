using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using System.Windows.Forms;
using static Synchro_Partitions.Tools;


namespace Synchro_Partitions
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        public MainForm()
        {
            InitializeComponent();
            //TODO cleeeeannn
            
            CBLFill(zoneCheckList,zones);
            CBLFill(zoneCheckList, zones);
        }




        private void zoneCheckList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void okButton_Click(object sender, EventArgs e)
        {
           MainForm.ActiveForm.DialogResult =  DialogResult.OK;
        }

        private void cancleButton_Click(object sender, EventArgs e)
        {
            MainForm.ActiveForm.DialogResult = DialogResult.Cancel;
        }

        private void elementCheckBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
