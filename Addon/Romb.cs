using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using WpfApp2;

namespace Addon
{
    [Serializable]
    class Romb : Shape
    {
        public Romb(MainWindow main, int x1, int y1, int x2, int y2, System.Windows.Media.Brush colorFill, System.Windows.Media.Brush colorBorder) : base(main, x1, y1, x2, y2, colorFill, colorBorder)
        {
            mainWindow = main;
        }

        public override List<System.Windows.Shapes.Shape> Draw()
        {
            var elements = new List<System.Windows.Shapes.Shape>();

            if (this.x1 > this.x2)
            {
                int buf = this.x2;
                this.x2 = this.x1;
                this.x1 = buf;
            }
            if (this.y1 > this.y2)
            {
                int buf = this.y2;
                this.y2 = this.y1;
                this.y1 = buf;
            }

            var tin = new System.Windows.Thickness();
            tin.Left = this.x1 < this.x2 ? this.x1 : this.x2;
            tin.Top = this.y1 < this.y2 ? this.y1 : this.y2;
            var rect = new System.Windows.Shapes.Line();
            rect.Stroke = this.colorBorder;
            rect.Fill = this.colorFill;
            rect.X1 = this.x1;
            rect.X2 = (this.x2 - this.x1) / 2 + this.x1;
            rect.Y1 = this.y1;
            rect.Y2 = this.y1;
            elements.Add(rect);

            var rect1 = new System.Windows.Shapes.Line();
            rect1.Stroke = this.colorBorder;
            rect1.Fill = this.colorFill;
            rect1.X1 = (this.x2 - this.x1) / 2 + this.x1;
            rect1.X2 = this.x2;
            rect1.Y1 = this.y1;
            rect1.Y2 = this.y2;
            elements.Add(rect1);

            var rect2 = new System.Windows.Shapes.Line();
            rect2.Stroke = this.colorBorder;
            rect2.Fill = this.colorFill;
            rect2.X1 = this.x2;
            rect2.X2 = (this.x2 - this.x1) / 2 + this.x1;
            rect2.Y1 = this.y2;
            rect2.Y2 = this.y2;
            elements.Add(rect2);

            var rect3 = new System.Windows.Shapes.Line();
            rect3.Stroke = this.colorBorder;
            rect3.Fill = this.colorFill;
            rect3.X1 = this.x1;
            rect3.X2 = (this.x2 - this.x1) / 2 + this.x1;
            rect3.Y1 = this.y1;
            rect3.Y2 = this.y2;
            elements.Add(rect3);

            return elements;
        }
    }
}
