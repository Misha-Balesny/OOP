using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp2
{
    [Serializable]
    public class Oval : Shape
    {
        public Oval(MainWindow main, int x1, int y1, int x2, int y2, System.Windows.Media.Brush colorFill, System.Windows.Media.Brush colorBorder) : base(main, x1, y1, x2, y2, colorFill, colorBorder)
        {
            mainWindow = main;
        }


        public override List<System.Windows.Shapes.Shape> Draw()
        {
            var elements = new List<System.Windows.Shapes.Shape>();

            var tin = new System.Windows.Thickness();
            tin.Left = this.x1 < this.x2 ? this.x1 : this.x2;
            tin.Top = this.y1 < this.y2 ? this.y1 : this.y2;
            var rect = new System.Windows.Shapes.Ellipse();
            rect.Stroke = this.colorBorder;
            rect.Fill = this.colorFill;
            rect.Margin = tin;
            rect.Width = Math.Abs(this.x2 - this.x1);
            rect.Height = Math.Abs(this.y2 - this.y1);
            elements.Add(rect);
            return elements;
        }
    }
}
