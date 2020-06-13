using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    class DataHandler
    {
        public static List<Type> conveyor = new List<Type>();

        public void HandleSave(List<Shape> shapes)
        {
            string buffer = "";

            var serializer = new Serializer();
            buffer = serializer.Serialize(shapes);

            foreach (var item in conveyor)
            {
                var adapter = new Adapter(item);
                buffer = adapter.Forward(buffer);
            }
        }

        public List<Shape> HandleLoad()
        {
            string buffer = "";

            try 
            { 
                for (int i = conveyor.Count - 1; i >= 0; i--)
                {
                    var adapter = new Adapter(conveyor[i]);
                    buffer = adapter.Back(buffer);
                }
            }
            catch (Exception)
            {
                // Bad ((((
            }

            var serializer = new Serializer();
            return serializer.Deserialize(buffer);
        }
    }
}
