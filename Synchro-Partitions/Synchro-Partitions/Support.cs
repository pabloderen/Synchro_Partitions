using System;
using System.Collections.Generic;
using System.Data;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using System.Windows.Forms;

namespace Synchro_Partitions
{
    public class RevitElement
    {
        public Element element { get; set; }
        public int id { get; set; }
    }

    public class Zone : RevitElement
    {

        public string zone { get; set; }
        public BoundingBoxXYZ bbox { get; set; }
        public Solid geometry { get; set; }
        public List<Element> intersectigObject { get; set; }

        public Zone(Element el)
        {
            element = el;
            bbox = el.get_BoundingBox(el.Document.ActiveView);
            zone = el.Name;
            id = el.Id.IntegerValue;
            intersectigObject = new List<Element>();
        }
    }

    public class BelongElement : RevitElement
    {
        public Element belongTo { get; set; }
        public string zone { get; set; }
        public BoundingBoxXYZ bbox { get; set; }
        public XYZ position { get; set; }

        public BelongElement(Element el)
        {
            element = el;
            bbox = el.get_BoundingBox(el.Document.ActiveView);
            id = el.Id.IntegerValue;
            var x = bbox.Min;
            var y = bbox.Max;
            position = new XYZ((x.X + y.X) / 2, (x.Y + y.Y) / 2, (x.Z + y.Z) / 2);
        }
    }//TODO change name

    public  class CBL_Item
    {
        public List<string> items { get; set; }
        public string selected { get; set; }

    }
    /// <summary>
    /// General tools
    /// </summary>
    public  static class Tools
    {
        public static List<Zone> zones { get; set; }

        public static List<BelongElement> elementsInView { get; set; }

       

        public static void CBLFill(CheckedListBox cb, List<Zone> list)
        {
            var l = new List<string>();
            foreach (var item in list)
            {
                if (item.GetType().Equals(typeof(Zone)))
                {
                    foreach (Parameter p in item.element.Parameters)
                    {
                        if (l.Contains(p.Definition.Name).Equals(false) && p.IsReadOnly == false && p.StorageType == StorageType.String)
                        {
                            l.Add(p.Definition.Name);
                        }
                    }

                }
                else
                {
                    foreach (var i in item.intersectigObject)
                    {
                        foreach (Parameter p in i.Parameters)
                        {
                            if (l.Contains(p.Definition.Name).Equals(false) && p.IsReadOnly == false && p.StorageType == StorageType.String)
                            {
                                l.Add(p.Definition.Name);
                            }
                        }
                    }
                    {

                    }
                }
            }
            l.Sort();
            foreach (var item in l)
            {
               cb.Items.Add(item);
            }    

            
        }


        public static void FillChecklistbox(CheckedListBox cb, List<string> l)
        {
            TaskDialog.Show("Show", l.Count.ToString());
            try
            {
                foreach (var item in l)
                {
                    cb.Items.Add(item);
                }
            }
                catch (Exception e )
            {
                
            }
        }
        
        
        
        
        //public void elementsInZones(List<Zone> zo)
        //{
        //    var element = zones.FirstOrDefault().element;
        //    FilteredElementCollector Collector = new FilteredElementCollector(element.Document);
        //    // Only accept element instances
        //    Collector.WhereElementIsNotElementType();
        //    // Exclude intersections with itself
        //    List<ElementId> excludedElements = new List<ElementId>();
        //    foreach (var e in zo)
        //    {
        //        excludedElements.Add(e.element.Id);
        //    }

        //    ExclusionFilter exclusionFilter = new ExclusionFilter(excludedElements);
        //    Collector.WherePasses(exclusionFilter);

        //    foreach (var z in zo)
        //    {
        //        Solid sol = getSolid(z.element);
        //        //First make solid intersection detection.
        //        if (sol != null)
        //        {
        //            ElementIntersectsSolidFilter intersectionFilter = new ElementIntersectsSolidFilter(sol);
        //            Collector.WherePasses(intersectionFilter);
        //            z.intersectigObject = Collector.ToElements() as List<Element>;
        //        }
        //        //If element has no solids use boundingbox detection
        //        else
        //        {
        //            foreach (var el in Collector.ToElements())
        //            {

        //                var be = new BelongElement(el);
        //                if (belongsTo(z, be))
        //                {
        //                    z.intersectigObject.Add(el);
        //                }
        //            }

        //        }
        //    }
        //}

        //public Solid getSolid(Element e)
        //{
        //    Autodesk.Revit.DB.Options opt = new Options();
        //    Autodesk.Revit.DB.GeometryElement geomElem = e.get_Geometry(opt);
        //    Solid geomSolid = null;
        //    foreach (GeometryObject geomObj in geomElem)
        //    {
        //        geomSolid = geomObj as Solid;

        //    }
        //    return geomSolid;
        //}



        //https://forums.autodesk.com/t5/revit-api-forum/check-to-see-if-a-point-is-inside-bounding-box/td-p/4354446	

        const double _eps = 1.0e-9;

        public static bool IsZero(double a, double tolerance)
        {
            return tolerance > Math.Abs(a);
        }

        public static bool IsZero(double a)
        {
            return IsZero(a, _eps);
        }

        public static bool IsEqual(double a, double b)
        {
            return IsZero(b - a);
        }

        public static int Compare(double a, double b)
        {
            return IsEqual(a, b) ? 0 : (a < b ? -1 : 1);
        }

        public static int Compare(XYZ p, XYZ q)
        {
            int d = Compare(p.X, q.X);

            if (0 == d)
            {
                d = Compare(p.Y, q.Y);

                if (0 == d)
                {
                    d = Compare(p.Z, q.Z);
                }
            }
            return d;
        }

        public static bool IsEqual(XYZ p, XYZ q)
        {
            return 0 == Compare(p, q);
        }

        public static bool belongsTo(Zone z, BelongElement b)
        {
            try
            {
                return 0 < Compare(z.bbox.Min, b.position) && 0 < Compare(z.bbox.Max, b.position);
            }
            catch
            {
                return false;
            }

        }

    }
}
