using System;
using System.Collections.Generic;
using System.Text;
using WpfApp2;

namespace WpfApp2
{
    [Serializable]
    public class Line : Shape
    {
        public Line(MainWindow main, int x1, int y1, int x2, int y2, System.Windows.Media.Brush colorFill, System.Windows.Media.Brush colorBorder) : base(main, x1, y1, x2, y2, colorFill, colorBorder)
        {
            mainWindow = main;
        }
        public override List<System.Windows.Shapes.Shape> Draw()
        {
            var elements = new List<System.Windows.Shapes.Shape>();

            var tin = new System.Windows.Thickness();
            tin.Left = this.x1 < this.x2 ? this.x1 : this.x2;
            tin.Top = this.y1 < this.y2 ? this.y1 : this.y2;
            var rect = new System.Windows.Shapes.Line();
            rect.Stroke = this.colorBorder;
            rect.Fill = this.colorFill;
            rect.X1 = this.x1;
            rect.X2 = this.x2;
            rect.Y1 = this.y1;
            rect.Y2 = this.y2;

            //mainWindow.can.Children.Add(rect);
            elements.Add(rect);
            return elements;
        }
    }
}
