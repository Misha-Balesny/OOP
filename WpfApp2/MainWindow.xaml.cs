using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using Microsoft.Win32;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Stream fs;
        public static List<Shape> List = new List<Shape>();
        private static Dictionary<string, Type> types = new Dictionary<string, Type>();
        private static List<List<System.Windows.Shapes.Shape>> MainElements = new List<List<System.Windows.Shapes.Shape>>();


        public MainWindow()
        {         
            InitializeComponent();
            types.Add("Circle", typeof(Circle));
            types.Add("Line", typeof(Line));
            types.Add("Oval", typeof(Oval));
            types.Add("Rectangle", typeof(Rectangle));
            types.Add("Sqare", typeof(Square));
            types.Add("Triangle", typeof(Triangle));
            Selector.ItemsSource = types.Keys;
        }
        private void LoadNewClass()
        {           
            try
            {
                var dllName = Pathfinder.Text;
                var assembly = Assembly.LoadFrom($"{dllName}");
                var classType = assembly.GetTypes().Single();
                types.Add(classType.Name.ToLower(), classType);

            }
            catch (Exception)
            {
                Pathfinder.Text = ("Whoops!");
            }
        }
        
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            var drawer = new Drawer(this);
            drawer.Clear();
            List.Clear();
        }

        private void RedFill_Click(object sender, RoutedEventArgs e)
        {
            Drawer.ColorFill = System.Windows.Media.Brushes.Red;
        }

        private void YellowFill_Click(object sender, RoutedEventArgs e)
        {
            Drawer.ColorFill = System.Windows.Media.Brushes.Yellow;
        }

        private void GreenFill_Click(object sender, RoutedEventArgs e)
        {
            Drawer.ColorFill = System.Windows.Media.Brushes.Green;
        }

        private void LBlueFill_Click(object sender, RoutedEventArgs e)
        {
            Drawer.ColorFill = System.Windows.Media.Brushes.LightBlue;
        }

        private void BlueFill_Click(object sender, RoutedEventArgs e)
        {
            Drawer.ColorFill = System.Windows.Media.Brushes.Blue;
        }

        private void PinkFill_Click(object sender, RoutedEventArgs e)
        {
            Drawer.ColorFill = System.Windows.Media.Brushes.HotPink;
        }

        private void BlackFill_Click(object sender, RoutedEventArgs e)
        {
            Drawer.ColorFill = System.Windows.Media.Brushes.Black;
        }

        private void WhiteFill_Click(object sender, RoutedEventArgs e)
        {
            Drawer.ColorFill = System.Windows.Media.Brushes.White;
        }

        private void Red_Click(object sender, RoutedEventArgs e)
        {
            Drawer.ColorBorder = System.Windows.Media.Brushes.Red;
        }

        private void Yellow_Click(object sender, RoutedEventArgs e)
        {
            Drawer.ColorBorder = System.Windows.Media.Brushes.Yellow;
        }

        private void Green_Click(object sender, RoutedEventArgs e)
        {
            Drawer.ColorBorder = System.Windows.Media.Brushes.Green;
        }

        private void LBlue_Click(object sender, RoutedEventArgs e)
        {
            Drawer.ColorBorder = System.Windows.Media.Brushes.LightBlue;
        }

        private void Blue_Click(object sender, RoutedEventArgs e)
        {
            Drawer.ColorBorder = System.Windows.Media.Brushes.Blue;
        }

        private void Pink_Click(object sender, RoutedEventArgs e)
        {
            Drawer.ColorBorder = System.Windows.Media.Brushes.HotPink;
        }

        private void Black_Click(object sender, RoutedEventArgs e)
        {
            Drawer.ColorBorder = System.Windows.Media.Brushes.Black;
        }

        private void White_Click(object sender, RoutedEventArgs e)
        {
            Drawer.ColorBorder = System.Windows.Media.Brushes.White;
        }

        private void DeSerialize_Click(object sender, RoutedEventArgs e)        
        {
            List.Clear();

            var dataHandler = new DataHandler();
            List = dataHandler.HandleLoad();

            MainElements.Clear();
            foreach (Shape item in List)
            {
                item.mainWindow = this;
                item.colorBorder = System.Windows.Media.Brushes.HotPink;
                MainElements.Add(item.Draw());
            }
            var drawer = new Drawer(this);
            drawer.AddToCanvas(MainElements);
        }

        private void Serialize_Click(object sender, RoutedEventArgs e)
        {
            var dataHandler = new DataHandler();
            dataHandler.HandleSave(List);
            List.Clear();
        }

        private void Draw_Click(object sender, RoutedEventArgs e)
        {
            var instance = Activator.CreateInstance(types[Selector.Text], this, int.Parse(X1.Text), int.Parse(Y1.Text), int.Parse(X2.Text), int.Parse(Y2.Text), Drawer.ColorFill, Drawer.ColorBorder);
            var temp = instance as Shape;
            MainElements.Add(temp.Draw()); // add to Main elements
            var drawer = new Drawer(this);
            drawer.AddToCanvas(MainElements); // Main elements
            List.Add(temp);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            LoadNewClass();
        }

        private void Path_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Pathfinder.Text = openFileDialog.FileName;
            }
        }

        private void AddF_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dllName = Pathfinder.Text;
                var assembly = Assembly.LoadFrom($"{dllName}");
                var classType = assembly.GetTypes().Single();
                DataHandler.conveyor.Add(classType);
            }
            catch (Exception)
            {
                Pathfinder.Text = ("Whoops!");
            }
        }
    }
}
