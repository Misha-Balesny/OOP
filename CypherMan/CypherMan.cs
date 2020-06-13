using System;
using System.IO;
using System.Security.Cryptography;
using System.Collections.Generic;

namespace CypherMan
{
    public class CypherMan
    {
        public string Save(string sourceFile)
        {
            string sypherFile = "temp.s";           
            var inparr = System.IO.File.ReadAllBytes(sourceFile);
            var list = new List<byte>();
            foreach(var item in inparr)
            {
                list.Add((byte)(item+1));
            }
            File.WriteAllBytes(sypherFile, list.ToArray());
            return sypherFile;
        }

        public string Load(string sourceFile)
        {
            if (sourceFile == "")
                sourceFile = "temp.s";
            string deSypherFile = "temp.ds";
            var inparr = System.IO.File.ReadAllBytes(sourceFile);
            var list = new List<byte>();
            foreach (var item in inparr)
            {
                list.Add((byte)(item - 1));
            }
            File.WriteAllBytes(deSypherFile, list.ToArray());
            return deSypherFile;
        }

    }
}
