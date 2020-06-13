using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace WpfApp2
{
    [Serializable]
    public class Triangle : Shape
    {
        
        public Triangle(MainWindow main, int x1, int y1, int x2, int y2, System.Windows.Media.Brush colorFill, System.Windows.Media.Brush colorBorder) : base(main, x1, y1, x2, y2, colorFill, colorBorder)
        {
            mainWindow = main;
        }

        public override List<System.Windows.Shapes.Shape> Draw()
        {
            var elements = new List<System.Windows.Shapes.Shape>();

            var tin = new System.Windows.Thickness();
            tin.Left = this.x1 < this.x2 ? this.x1 : this.x2;
            tin.Top = this.y1 < this.y2 ? this.y1 : this.y2;
            var rect = new System.Windows.Shapes.Polygon();
            rect.Stroke = this.colorBorder;
            rect.Fill = this.colorFill;
            System.Windows.Point Point1 = new System.Windows.Point(this.x1, this.y1);
            System.Windows.Point Point2 = new System.Windows.Point(this.x2, this.y2);
            System.Windows.Point Point3 = new System.Windows.Point(this.x1, this.y2);

            PointCollection myPointCollection = new PointCollection();

            myPointCollection.Add(Point1);
            myPointCollection.Add(Point2);
            myPointCollection.Add(Point3);
            rect.Points = myPointCollection;

            elements.Add(rect);
            return elements;
        }
    }
}
//x1    x3
//      /\
//     /  \
//x4  /____\x2

