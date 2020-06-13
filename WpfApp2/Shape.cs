using System;
using System.Collections.Generic;

namespace WpfApp2
{
    [Serializable]
    public abstract class Shape
    {
        public int x1;
        public int y1;
        public int y2;
        public int x2;        

        [NonSerialized]
        public System.Windows.Media.Brush colorFill;
        [NonSerialized]
        public System.Windows.Media.Brush colorBorder;
        [NonSerialized]
        public MainWindow mainWindow;

        public Shape(MainWindow main, int x1, int y1, int x2, int y2, System.Windows.Media.Brush colorFill, System.Windows.Media.Brush colorBorder)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.colorFill = colorFill;
            this.colorBorder = colorBorder;
            this.mainWindow = main;            
        }

        public abstract List<System.Windows.Shapes.Shape> Draw();    
    }
}
