using System.Collections.Generic;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using System.Linq;
using System;
using Autodesk.Revit.UI.Selection;

using static Synchro_Partitions.Tools;

namespace Synchro_Partitions
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class Synchro_Partitions : IExternalCommand
    {
        static AddInId appId = new AddInId(new Guid("7BD1D2E1-2152-40F9-A42B-04C90918A888"));

        /// <summary>
        /// Main solution
        /// </summary>
        /// <param name="commandData"></param>
        /// <param name="message"></param>
        /// <param name="elementSet"></param>
        /// <returns></returns>
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elementSet)
        {
            Document doc = commandData.Application.ActiveUIDocument.Document;
            UIDocument uidoc = commandData.Application.ActiveUIDocument;

            //TODO clean initiated list of zones and elements
            zones = new List<Zone>();
            elementsInView = new List<BelongElement>();


            var selection = uidoc.Selection.PickObjects(ObjectType.Element);
            if (selection.Count() != 0)
            {
                foreach (var element in selection)
                {
                    //Create a new RevitElement to iterate later.
                    var rz = new Zone(doc.GetElement(element.ElementId));
                    zones.Add(rz);
                }
            }

            FilteredElementCollector coll = new FilteredElementCollector(doc, doc.ActiveView.Id).WhereElementIsNotElementType();

            foreach (var element in coll.ToElements())
            {
                var re = new BelongElement(element);
                elementsInView.Add(re);
            }

            foreach (var z in zones)
            {
                foreach (var e in elementsInView)
                {
                    if (Tools.belongsTo(z, e))
                    {
                        z.intersectigObject.Add(e.element);
                    }
                }
            }

            TaskDialog.Show("output", String.Format("Boxes {0} \n\r Elements {1}", zones.Count(),zones[0].intersectigObject.Count()));
            using (MainForm thisform = new MainForm())
            {
                thisform.ShowDialog();
                if (thisform.DialogResult == System.Windows.Forms.DialogResult.OK)
                {

                    return 0;
                }

            }

            return 0;
        }
    }

}