using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Media;

namespace WpfApp2
{
    class Drawer
    {
        private delegate void Drawers();

        private Dictionary<string, Type> types = new Dictionary<string, Type>();
        private readonly Dictionary<string, Drawers> drawers = new Dictionary<string, Drawers>();

        public static MainWindow mainWindow { get; set; }

        public static System.Windows.Media.Brush ColorFill { get; set; }

        public static System.Windows.Media.Brush ColorBorder { get; set; }
       
        public Drawer(MainWindow main)
        {
            mainWindow = main;            
        }

        public void AddToCanvas(List<List<System.Windows.Shapes.Shape>> shapes)
        {
            //mainWindow.can.Children.Clear();
            foreach (var shape in shapes)
            {
                foreach (var item in shape)
                { 
                    mainWindow.can.Children.Add(item);
                }
            }
        }

        public void Clear() 
        {
            mainWindow.can.Children.Clear();
            MainWindow.List.Clear();
        }

        public static ArrayList List { get; set; }

        public static void AddToList(Shape item) 
        {
            ArrayList List = new ArrayList();
            List.Add(item);
        }       
    }
}
