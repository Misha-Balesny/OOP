using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    class Serializer
    {
        private const string _path = "shapes.dat";

        public string Serialize(List<Shape> shapes)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(_path, FileMode.OpenOrCreate))
                formatter.Serialize(fs, shapes);

            return _path;
        }

        public List<Shape> Deserialize(string path)
        {
            if (string.IsNullOrEmpty(path))
                path = _path;

            BinaryFormatter formatter = new BinaryFormatter();
            var list = new List<Shape>();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                list = (List<Shape>)formatter.Deserialize(fs);
            }
            return list;
        }
    }
}
