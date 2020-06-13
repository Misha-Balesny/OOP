using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    class Adapter : ICoveyor
    {
        private readonly Type type;

        public Adapter(Type type)
        {
            this.type = type;
        }

        public string Back(string path)
        {
            var obj = Activator.CreateInstance(type);

            var method = type.GetMethod("Load");

            var result = method.Invoke(obj, new object[] { path });

            return result as string;
        }

        public string Forward(string path)
        {
            var obj = Activator.CreateInstance(type);

            var method = type.GetMethod("Save");

            var result = method.Invoke(obj, new object[] { path });

            return result as string;
        }
    }
}
