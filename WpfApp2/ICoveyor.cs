using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    interface ICoveyor
    {
        string Forward(string path);

        string Back(string path);
    }
}
